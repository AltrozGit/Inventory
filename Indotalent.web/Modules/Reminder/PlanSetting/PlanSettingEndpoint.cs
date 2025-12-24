using Microsoft.AspNetCore.Mvc;
using Serenity;
using Serenity.Abstractions;
using Serenity.Data;
using Serenity.Reporting;
using Serenity.Services;
using Serenity.Web;
using Serilog;
using System;
using System.Data;
using System.Globalization;
using System.Net;
using MyRow = Indotalent.Reminder.PlanSettingRow;

namespace Indotalent.Reminder.Endpoints
{
    [Route("Services/Reminder/PlanSetting/[action]")]
    [ConnectionKey(typeof(MyRow)), ServiceAuthorize(typeof(MyRow))]
    public class PlanSettingController : ServiceEndpoint
    {
        //private readonly IUserPermissionStorage _permissionStorage;
        private readonly IUnitOfWork _unitOfWork;

        public PlanSettingController()
        {
           // _permissionStorage = permissionStorage;
            //_unitOfWork = unitOfWork;
        }

        // Helper method to check if the current user is a tenant admin
       
        [HttpPost, AuthorizeCreate(typeof(MyRow))]
        public SaveResponse Create(IUnitOfWork uow, SaveRequest<MyRow> request,
            [FromServices] IPlanSettingSaveHandler handler)
        {
           
            return handler.Create(uow, request);
        }

        [HttpPost, AuthorizeUpdate(typeof(MyRow))]
        public SaveResponse Update(IUnitOfWork uow, SaveRequest<MyRow> request,
            [FromServices] IPlanSettingSaveHandler handler)
        {
           

            return handler.Update(uow, request);
        }

        [HttpPost, AuthorizeDelete(typeof(MyRow))]
        public DeleteResponse Delete(IUnitOfWork uow, DeleteRequest request,
            [FromServices] IPlanSettingDeleteHandler handler)
        {
           

            return handler.Delete(uow, request);
        }

        [HttpPost]
        public RetrieveResponse<MyRow> Retrieve(IDbConnection connection, RetrieveRequest request,
            [FromServices] IPlanSettingRetrieveHandler handler)
        {
            var result = handler.Retrieve(connection, request);
            Log.Information("Retrieved data: {@Result}", result);
            return result;
        }

        [HttpPost]
        public ListResponse<MyRow> List(IDbConnection connection, ListRequest request,
            [FromServices] IPlanSettingListHandler handler)
        {
            return handler.List(connection, request);
        }

        // Export Excel file with PlanSettings
        public FileContentResult ListExcel(IDbConnection connection, ListRequest request,
            [FromServices] IPlanSettingListHandler handler,
            [FromServices] IExcelExporter exporter)
        {
            var data = List(connection, request, handler).Entities;
            var bytes = exporter.Export(data, typeof(Columns.PlanSettingColumns), request.ExportColumns);
            return ExcelContentResult.Create(bytes, "PlanSettingList_" +
                DateTime.Now.ToString("yyyyMMdd_HHmmss", CultureInfo.InvariantCulture) + ".xlsx");
        }
    }
}
