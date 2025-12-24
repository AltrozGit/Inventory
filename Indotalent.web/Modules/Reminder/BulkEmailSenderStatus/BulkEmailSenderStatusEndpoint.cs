using Indotalent.Administration;
using Indotalent.Merchandise;
using Indotalent.Web.Modules.Reminder.BulkEmailSenderStatus;
using Microsoft.AspNetCore.Mvc;
using Serenity;
using Serenity.Abstractions;
using Serenity.Data;
using Serenity.Reporting;
using Serenity.Services;
using Serenity.Web;
using System;
using System.Data;
using System.Globalization;
using System.Linq;
using MyRow = Indotalent.Reminder.BulkEmailSenderStatusRow;

namespace Indotalent.Reminder.Endpoints
{
  
    [Route("Services/Reminder/BulkEmailSenderStatus/[action]")]
    [ConnectionKey(typeof(MyRow)), ServiceAuthorize(typeof(MyRow))]
    public class BulkEmailSenderStatusController : ServiceEndpoint
    {
        protected IUserAccessor UserAccessor { get; }
        private IUserRetrieveService UserRetriever { get; }
        [HttpPost, AuthorizeCreate(typeof(MyRow))]
        public SaveResponse Create(IUnitOfWork uow, SaveRequest<MyRow> request,
            [FromServices] IBulkEmailSenderStatusSaveHandler handler)
        {
            return handler.Create(uow, request);
        }

        [HttpPost, AuthorizeUpdate(typeof(MyRow))]
        public SaveResponse Update(IUnitOfWork uow, SaveRequest<MyRow> request,
            [FromServices] IBulkEmailSenderStatusSaveHandler handler)
        {
            return handler.Update(uow, request);
        }
 
        [HttpPost, AuthorizeDelete(typeof(MyRow))]
        public DeleteResponse Delete(IUnitOfWork uow, DeleteRequest request,
            [FromServices] IBulkEmailSenderStatusDeleteHandler handler)
        {
            return handler.Delete(uow, request);
        }

        [HttpPost]
        public RetrieveResponse<MyRow> Retrieve(IDbConnection connection, RetrieveRequest request,
            [FromServices] IBulkEmailSenderStatusRetrieveHandler handler)
        {
            return handler.Retrieve(connection, request);
        }
        [HttpPost]
        public ListResponse<MyRow> List(IDbConnection connection, BulkEmailSenderStatusRequest request,
            [FromServices] IBulkEmailSenderStatusListHandler handler)
        {


            return handler.List(connection, request);
        }

     


        public FileContentResult ListExcel(IDbConnection connection, BulkEmailSenderStatusRequest request,
            [FromServices] IBulkEmailSenderStatusListHandler handler,
            [FromServices] IExcelExporter exporter)
        {
            var data = List(connection, request, handler).Entities;
            var bytes = exporter.Export(data, typeof(Columns.BulkEmailSenderStatusColumns), request.ExportColumns);
            return ExcelContentResult.Create(bytes, "BulkEmailSenderStatusList_" +
                DateTime.Now.ToString("yyyyMMdd_HHmmss", CultureInfo.InvariantCulture) + ".xlsx");
        }
      
    }
}