using Indotalent.Administration;
using Indotalent.Web.Modules.Projects.ProjectMaterialRequestDetail.RequestHandlers;
using Serenity;
using Serenity.Abstractions;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<Indotalent.Projects.ProjectMaterialRequestDetailRow>;
using MyRow = Indotalent.Projects.ProjectMaterialRequestDetailRow;

namespace Indotalent.Projects
{
    public interface IProjectMaterialRequestDetailListHandler : IListHandler<MyRow, MyRequest, MyResponse> { }

    public class ProjectMaterialRequestDetailListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IProjectMaterialRequestDetailListHandler
    {
        protected IUserRetrieveService UserRetrieveService { get; }
        protected IUserAccessor UserAccessor { get; }
        private readonly IProjectMaterialRequestDetailPMRIDListHandler _pmrIdListHandler;

        public ProjectMaterialRequestDetailListHandler(
            IRequestContext context,
            IUserRetrieveService userRetrieveService,
            IUserAccessor userAccessor,
            IProjectMaterialRequestDetailPMRIDListHandler pmrIdListHandler)
            : base(context)
        {
            UserRetrieveService = userRetrieveService ?? throw new ArgumentNullException(nameof(userRetrieveService));
            UserAccessor = userAccessor ?? throw new ArgumentNullException(nameof(userAccessor));
            _pmrIdListHandler = pmrIdListHandler ?? throw new ArgumentNullException(nameof(pmrIdListHandler));
        }

        protected override void PrepareQuery(SqlQuery query)
        {
            base.PrepareQuery(query);

            // Extract ProjectMaterialRequestId from the request criteria
            int? projectMaterialRequestId = ExtractProjectMaterialRequestId(Request.Criteria);

            if (projectMaterialRequestId.HasValue)
            {
                // Call the PMRIDListHandler to get the details
                var pmrIdRequest = new ProjectMaterialRequestDetailPMRIDListRequest
                {
                    ProjectMaterialRequestId = projectMaterialRequestId.Value
                };

                var pmrIdResponse = _pmrIdListHandler.GetProjectMaterialRequestId(Connection, pmrIdRequest);

                // Use the response to filter or modify the query
                if (pmrIdResponse.ProjectMaterialRequestDetails != null && pmrIdResponse.ProjectMaterialRequestDetails.Any())
                {
                    var materialIds = pmrIdResponse.ProjectMaterialRequestDetails.Select(x => x.ProjectMaterialRequestId).ToList();
                    query.Where(ProjectMaterialRequestDetailRow.Fields.ProjectMaterialRequestId.In(materialIds));
                }
            }
        }

        private int? ExtractProjectMaterialRequestId(BaseCriteria criteria)
        {
            if (criteria is BinaryCriteria binaryCriteria)
            {
                if (binaryCriteria.Operator == CriteriaOperator.EQ)
                {
                    // Extract the left and right operands
                    var leftOperand = binaryCriteria.LeftOperand;
                    var rightOperand = binaryCriteria.RightOperand;

                    // Check if the left operand is a field criteria and matches the ProjectMaterialRequestId field
                    if (leftOperand is Criteria leftCriteria && leftCriteria.Expression == nameof(ProjectMaterialRequestDetailRow.ProjectMaterialRequestId))
                    {
                        // Extract the value from the right operand
                        if (rightOperand is ValueCriteria valueCriteria)
                        {
                            return Convert.ToInt32(valueCriteria.Value);
                        }
                    }
                }
            }

            return null;
        }
    }
}