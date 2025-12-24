
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Office2010.Excel;
using Indotalent.Administration;
using Indotalent.Material;
using Indotalent.Projects;
using Serenity;
using Serenity.Abstractions;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Indotalent.Web.Modules.Material.Request.RequestHandlers
{
    public class ProjectMaterialRequestInsertCheckboxRequest : ServiceRequest
    {
        public List<int> ItemIds { get; set; } = new List<int>();
        public int ProjectMaterialRequestId { get; set; }
    }

    public class ProjectMaterialRequestInsertCheckboxResponse : ServiceResponse
    {
        public string MaterialRequestId { get; set; }
    }
    public interface IProjectMaterialRequestInsertCheckboxHandler : IRequestHandler
    {
        ProjectMaterialRequestInsertCheckboxResponse CreateMaterialRequest(IDbConnection connection, ProjectMaterialRequestInsertCheckboxRequest request);
    }
    public class ProjectMaterialRequestInsertCheckboxHandler : IProjectMaterialRequestInsertCheckboxHandler
    {
        protected IUserAccessor UserAccessor { get; }
        private IUserRetrieveService UserRetriever { get; }
        public ProjectMaterialRequestInsertCheckboxHandler(IUserAccessor userAccessor, IUserRetrieveService userRetriever)
        {
            UserAccessor = userAccessor;
            UserRetriever = userRetriever;
        }
        public ProjectMaterialRequestInsertCheckboxResponse CreateMaterialRequest(IDbConnection connection, ProjectMaterialRequestInsertCheckboxRequest request)
        {
            var user = UserAccessor.User?.GetUserDefinition(UserRetriever) as UserDefinition;
            var result = new ProjectMaterialRequestInsertCheckboxResponse();

            if (request.ItemIds == null || request.ItemIds.Count == 0)
                throw new ValidationError("No items selected!");

            var rowFieldsProjectMaterialRequestRow = ProjectMaterialRequestRow.Fields;
            var projectMaterialRequestRow = connection.TryFirst<ProjectMaterialRequestRow>(row => row.SelectTableFields()
                .Where(rowFieldsProjectMaterialRequestRow.Id == request.ItemIds[1]));

            var requestRow = new RequestRow();

            // Retrieve tenant information to generate the serial number
            var tenant = connection.ById<TenantRow>(projectMaterialRequestRow.TenantId);
            if (tenant == null)
            {
                throw new ValidationError("Tenant not found!");
            }

            // Prepare to generate the next serial number for the Material Request
            var numberRequest = new GetNextNumberRequest()
            {
                Prefix = tenant.MaterialRequestNumberUseDate.Value
                    ? tenant.MaterialRequestNumberPrefix + "/" + DateTime.Now.ToString("yyyyMMdd")
                    : tenant.MaterialRequestNumberPrefix,
                Length = tenant.MaterialRequestNumberLength.Value
            };

            // Get the next serial number for the material request
            var response = MultiTenantHelper.GetNextNumber(connection, numberRequest, RequestRow.Fields.Number, tenant.TenantId);
            requestRow.Number = response.Serial;

            requestRow.ProjectId = projectMaterialRequestRow.ProjectId;
            requestRow.RequestDate = projectMaterialRequestRow.RequestDate;
            requestRow.TotalQtyRequest = projectMaterialRequestRow.TotalQtyRequest;
            requestRow.DeliveryDate = projectMaterialRequestRow.DeliveryDate;
            requestRow.InsertDate = projectMaterialRequestRow.InsertDate;
            requestRow.InsertUserId = projectMaterialRequestRow.InsertUserId;
            requestRow.UpdateDate = projectMaterialRequestRow.UpdateDate;
            requestRow.UpdateUserId = projectMaterialRequestRow.UpdateUserId;
            requestRow.TenantId = projectMaterialRequestRow.TenantId;
            requestRow.Total = projectMaterialRequestRow.Total;
            requestRow.ProjectMaterialRequestId = projectMaterialRequestRow.Id;
            requestRow.RequestStatus = (Indotalent.Web.Modules.Material.Request.RequestStatus?)projectMaterialRequestRow.RequestStatus;

            var materialRequestId = connection.InsertAndGetID(requestRow);
            result.MaterialRequestId = requestRow.Number;

            var requestDetailList = new List<RequestDetailRow>();
            var rowFieldsProjectMaterialRequestDetailRow = ProjectMaterialRequestDetailRow.Fields;

            // Insert selected items into request details
            for (int i = 0; i < request.ItemIds.Count; i += 2)
            {
                var productId = request.ItemIds[i];
                var projectMaterialRequestId = request.ItemIds[i + 1];

                var projectMaterialRequestDetailRow = connection.TryFirst<ProjectMaterialRequestDetailRow>(row => row.SelectTableFields()
                    .Where(rowFieldsProjectMaterialRequestDetailRow.ProductId == productId && rowFieldsProjectMaterialRequestDetailRow.ProjectMaterialRequestId == projectMaterialRequestId));

                if (projectMaterialRequestDetailRow == null)
                {
                    continue;
                }

                var requestDetailRow = new RequestDetailRow();

                requestDetailRow.ProductId = projectMaterialRequestDetailRow.ProductId;
                requestDetailRow.QtyRequest = projectMaterialRequestDetailRow.PendingMaterialRequestQty;
                requestDetailRow.MaterialRequestId = (int)materialRequestId;
                requestDetailRow.InsertDate = DateTime.Now;
                requestDetailRow.InsertUserId = projectMaterialRequestDetailRow.InsertUserId;
                requestDetailRow.PurchasePrice = projectMaterialRequestDetailRow.PurchasePrice;
                requestDetailRow.SubTotal = projectMaterialRequestDetailRow.SubTotal;
                requestDetailRow.IsActive = projectMaterialRequestDetailRow.IsActive;
                requestDetailRow.TenantId = projectMaterialRequestDetailRow.TenantId;

                connection.InsertAndGetID(requestDetailRow);

                // Update the IsCompleteMRCreated flag
               // projectMaterialRequestDetailRow.IsCompleteMRCreated = true;
               // projectMaterialRequestDetailRow.PendingMaterialRequestQty = 0;
                //connection.UpdateById(projectMaterialRequestDetailRow);
            }

            return result;
        }
    }
}

