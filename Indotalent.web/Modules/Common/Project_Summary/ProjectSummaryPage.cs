using Indotalent.Administration;
using Indotalent.Material;
using Indotalent.Merchandise;
using Indotalent.Projects;
using Indotalent.Web.Modules.Common.Project_Summary.ProjectExpense;
using Indotalent.Web.Modules.Common.Project_Summary.ProjectFundStats;
using Microsoft.AspNetCore.Mvc;
using Serenity;
using Serenity.Abstractions;
using Serenity.Data;
using Serenity.Web;
using System.Collections.Generic;
using System.Linq;
using static MVC.Views.Administration;

namespace Indotalent.Common
{
    [PageAuthorize]
	[ReadPermission("Dashboard:Project")]
	public class ProjectSummaryController : Controller
	{
		protected ISqlConnections SqlConnections { get; }
		protected IUserRetrieveService UserRetrieveService { get; }

		public ProjectSummaryController(ISqlConnections sqlConnections, IUserRetrieveService userRetrieveService)
		{
			SqlConnections = sqlConnections;
			UserRetrieveService = userRetrieveService;
		}

		[Route("Dashboard/Project/{projectId?}")]
		public ActionResult Index(int? projectId)
		{
			var projectSummaryPageModel = new ProjectSummaryModel();
			var user = (UserDefinition)User.GetUserDefinition(UserRetrieveService);

			using (var connection = SqlConnections.NewFor<TenantRow>())
			{
				var tenant = connection.ById<TenantRow>(user.TenantId);
                projectSummaryPageModel.Currency = tenant.Currency;

                projectId ??= 0;
				ViewBag.CurrentProjectId = projectId;

				var projectList = connection.List<ProjectRow>(p => p
										   .SelectTableFields()
										   .Select(ProjectRow.Fields.Id)
										   .Select(ProjectRow.Fields.Name)
										   .Where(ProjectRow.Fields.TenantId == tenant.TenantId.Value)
										   );

				projectList.Insert(0, new ProjectRow { Id = 0, Name = "Select Project" });
				ViewBag.ProjectList = projectList;

				if(projectId.Value > 0 ) 
				{
					var projectFundStatsRowFields = ProjectFundStatsRow.Fields;
					var projectFundStats = connection.TryFirst<ProjectFundStatsRow>(row => row.SelectTableFields()
					.Where(projectFundStatsRowFields.ProjectId == projectId.Value));

					if (projectFundStats != null)
					{
						projectSummaryPageModel.AllocatedFund = projectFundStats.TotalAllocatedFund.Value;
						projectSummaryPageModel.CurrentProjectCost = projectFundStats.TotalExpense.Value;
						projectSummaryPageModel.CurrentBalanceFund = projectFundStats.AvailableFund.Value;
					}
				}
			};

			return View(MVC.Views.Common.Project_Summary.ProjectSummaryIndex, projectSummaryPageModel);
		}

		private static double CalculateMaterialCost(List<IssueDetailRow> materialCost)
		{
			return materialCost.Sum(x => x.PurchasePrice.Value * x.QtyIssue.Value +
				CalculateTax(x.PurchasePrice.Value, x.QtyIssue.Value, x.TaxRatePercentage.Value));
        }

		private static double CalculateTax(double price, double quantity, double taxPercentage)
		{
			return (price * quantity) * (taxPercentage > 0 ? taxPercentage : 1) / 100;
		}
	}
}

