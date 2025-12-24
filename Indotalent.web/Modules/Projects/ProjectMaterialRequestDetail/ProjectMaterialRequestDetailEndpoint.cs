using Indotalent.Web.Modules.Material.Request.RequestHandlers;
using Indotalent.Web.Modules.Projects.ProjectMaterialRequestDetail.RequestHandlers;
using Microsoft.AspNetCore.Mvc;
using Serenity;
using Serenity.Data;
using Serenity.Reporting;
using Serenity.Services;
using Serenity.Web;
using System;
using System.Data;
using System.Globalization;
using System.Net;
using MyRow = Indotalent.Projects.ProjectMaterialRequestDetailRow;

namespace Indotalent.Projects.Endpoints
{
    [Route("Services/Projects/ProjectMaterialRequestDetail/[action]")]
    [ConnectionKey(typeof(MyRow)), ServiceAuthorize(typeof(MyRow))]
    public class ProjectMaterialRequestDetailController : ServiceEndpoint
    {
        [HttpPost, AuthorizeCreate(typeof(MyRow))]
        public SaveResponse Create(IUnitOfWork uow, SaveRequest<MyRow> request,
            [FromServices] IProjectMaterialRequestDetailSaveHandler handler)
        {
            return handler.Create(uow, request);
        }

        [HttpPost, AuthorizeUpdate(typeof(MyRow))]
        public SaveResponse Update(IUnitOfWork uow, SaveRequest<MyRow> request,
            [FromServices] IProjectMaterialRequestDetailSaveHandler handler)
        {
            return handler.Update(uow, request);
        }
 
        [HttpPost, AuthorizeDelete(typeof(MyRow))]
        public DeleteResponse Delete(IUnitOfWork uow, DeleteRequest request,
            [FromServices] IProjectMaterialRequestDetailDeleteHandler handler)
        {
            return handler.Delete(uow, request);
        }

        [HttpPost]
        public RetrieveResponse<MyRow> Retrieve(IDbConnection connection, RetrieveRequest request,
            [FromServices] IProjectMaterialRequestDetailRetrieveHandler handler)
        {
            return handler.Retrieve(connection, request);
        }

        [HttpPost]
        public ListResponse<MyRow> List(IDbConnection connection, ListRequest request,
            [FromServices] IProjectMaterialRequestDetailListHandler handler)
        {
            return handler.List(connection, request);
        }
        [HttpPost]
        public ProjectMaterialRequestDetailPMRIDListResponse GetProjectMaterialRequestId(IDbConnection connection, ProjectMaterialRequestDetailPMRIDListRequest request,
    [FromServices] IProjectMaterialRequestDetailPMRIDListHandler handler)
        {

            return handler.GetProjectMaterialRequestId(connection, request);
        }
        public FileContentResult ListExcel(IDbConnection connection, ListRequest request,
            [FromServices] IProjectMaterialRequestDetailListHandler handler,
            [FromServices] IExcelExporter exporter)
        {
            var data = List(connection, request, handler).Entities;
            var bytes = exporter.Export(data, typeof(Columns.ProjectMaterialRequestDetailColumns), request.ExportColumns);
            return ExcelContentResult.Create(bytes, "ProjectMaterialRequestDetailList_" +
                DateTime.Now.ToString("yyyyMMdd_HHmmss", CultureInfo.InvariantCulture) + ".xlsx");
        }
    }
}