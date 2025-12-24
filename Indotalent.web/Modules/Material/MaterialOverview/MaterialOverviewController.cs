using Microsoft.AspNetCore.Mvc;
using Serenity;
using Serenity.Abstractions;
using Serenity.Data;
using Serenity.Web;
using System;
using Indotalent.Material; // Assuming MaterialRequestRow and MaterialIssueRow are in this namespace
using System.Linq;
using Indotalent.Common;


namespace Indotalent.Web.Modules.Material.MaterialOverview
{
    [PageAuthorize]
    [ReadPermission("Material:MaterialOverview")]
    public class MaterialOverviewController : Controller
    {
        protected ISqlConnections SqlConnections { get; }
        protected IUserRetrieveService UserRetrieveService { get; }

        public MaterialOverviewController(ISqlConnections sqlConnections, IUserRetrieveService userRetrieveService)
        {
            SqlConnections = sqlConnections;
            UserRetrieveService = userRetrieveService;
        }

        [Route("Material/MaterialOverview")]
        public ActionResult Index()
        {
            var MaterialOverviewModel = new MaterialOverviewModel();
            var user = (UserDefinition)User.GetUserDefinition(UserRetrieveService);

            DateTime today = DateTime.Today;
            DateTime startOfMonth = new DateTime(today.Year, today.Month, 1);
            DateTime startOfYear = new DateTime(today.Year, 1, 1);

            // Counting material requests
            using (var connection = SqlConnections.NewFor<Indotalent.Material.RequestRow>())
            {
                // Count material requests today
                MaterialOverviewModel.MaterialRequestsToday = connection.Count<RequestRow>(
                    new Criteria("RequestDate") >= today &
                    new Criteria("TenantId") == user.TenantId);

                // Count material requests this month
                MaterialOverviewModel.MaterialRequestsThisMonth = connection.Count<RequestRow>(
                    new Criteria("RequestDate") >= startOfMonth &
                    new Criteria("TenantId") == user.TenantId);

                //// Count material requests this year
                //MaterialOverviewModel.MaterialRequestsThisYear = connection.Count<Indotalent.Material.RequestRow>(
                //    new Criteria("RequestDate") >= startOfYear &
                //    new Criteria("TenantId") == user.TenantId);

                
                // Material request total count
                MaterialOverviewModel.TotalMaterialRequests = connection.Count<RequestRow>(
           new Criteria("TenantId") == user.TenantId);
            }

            // Counting material issues
            using (var connection = SqlConnections.NewFor<Indotalent.Material.IssueRow>())
            {
                // Count material issues today
                MaterialOverviewModel.MaterialIssuesToday = connection.Count<IssueRow>(
                    new Criteria("IssueDate") >= today &
                    new Criteria("TenantId") == user.TenantId);

                // Count material issues this month
                MaterialOverviewModel.MaterialIssuesThisMonth = connection.Count<Indotalent.Material.IssueRow>(
                    new Criteria("IssueDate") >= startOfMonth &
                    new Criteria("TenantId") == user.TenantId);

                // Count of total material issue
                MaterialOverviewModel.TotalMaterialIssue = connection.Count<Indotalent.Material.IssueRow>(
                  new Criteria("TenantId") == user.TenantId);

                //// Count material issues this year
                //MaterialOverviewModel.MaterialIssuesThisYear = connection.Count<IssueRow>(
                //    new Criteria("IssueDate") >= startOfYear &
                //    new Criteria("TenantId") == user.TenantId);
            }

            using (var connection = SqlConnections.NewFor<Indotalent.Purchase.PurchaseOrderRow>())  // Correct namespace for PurchaseOrderRow
            {
                // Count purchase orders (Months)
                MaterialOverviewModel.PurchaseOrderThisMonth = connection.Count<Indotalent.Purchase.PurchaseOrderRow>(
                    new Criteria("OrderDate") >= startOfMonth &
                    new Criteria("TenantId") == user.TenantId);

                // Count total purchase orders (no date restriction)
                MaterialOverviewModel.TotalPurchaseOrder = connection.Count<Indotalent.Purchase.PurchaseOrderRow>(
                  new Criteria("TenantId") == user.TenantId);


                // total count of month request
                MaterialOverviewModel.TotalRequestMonthCount = MaterialOverviewModel.MaterialRequestsThisMonth +
                                                      MaterialOverviewModel.MaterialIssuesThisMonth +
                                                      MaterialOverviewModel.PurchaseOrderThisMonth;

                // total count of request
                MaterialOverviewModel.TotalRequestCount = MaterialOverviewModel.TotalMaterialRequests+
                                                      MaterialOverviewModel.TotalMaterialIssue +
                                                      MaterialOverviewModel.TotalPurchaseOrder;


            }


            return View("MaterialOverviewIndex", MaterialOverviewModel);

            //return View(MVC.Views.EmailSendingSummary.EmailSendingSummaryIndex, MaterialOverviewModel);
        }
    }
}
