//using Indotalent.Web.Modules.Reminder.SmtpConfiguration;
using Indotalent.Administration;
using Indotalent.Administration.Entities;
using Indotalent.Administration.Repositories;
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
using System.Net;
using MyRow = Indotalent.Reminder.SmtpConfigurationRow;

namespace Indotalent.Reminder.Endpoints
{
    [Route("Services/Reminder/SmtpConfiguration/[action]")]
    [ConnectionKey(typeof(MyRow)), ServiceAuthorize(typeof(MyRow))]
    public class SmtpConfigurationController : ServiceEndpoint
    {
        //private readonly SmtpConfigurationService _smtpService;
        //public SmtpConfigurationController(SmtpConfigurationService smtpService)
        //{
        //    _smtpService = smtpService;
        //}
        [HttpPost, AuthorizeCreate(typeof(MyRow))]
        public SaveResponse Create(IUnitOfWork uow, SaveRequest<MyRow> request,
            [FromServices] ISmtpConfigurationSaveHandler handler)
        {
           // _smtpService.InsertSmtpConfiguration(row);
            return handler.Create(uow, request);
        }

        [HttpPost, AuthorizeUpdate(typeof(MyRow))]
        public SaveResponse Update(IUnitOfWork uow, SaveRequest<MyRow> request,
            [FromServices] ISmtpConfigurationSaveHandler handler)
        {
            return handler.Update(uow, request);
        }
 
        [HttpPost, AuthorizeDelete(typeof(MyRow))]
        public DeleteResponse Delete(IUnitOfWork uow, DeleteRequest request,
            [FromServices] ISmtpConfigurationDeleteHandler handler)
        {
            return handler.Delete(uow, request);
        }

        [HttpPost]
        public RetrieveResponse<MyRow> Retrieve(IDbConnection connection, RetrieveRequest request,
            [FromServices] ISmtpConfigurationRetrieveHandler handler)
        {
            return handler.Retrieve(connection, request);
        }

        [HttpPost]
        public ListResponse<MyRow> List(IDbConnection connection, ListRequest request,
            [FromServices] ISmtpConfigurationListHandler handler, [FromServices] IUserRetrieveService userRetrieveService)
        {
           
            return handler.List(connection, request);
        }

        public FileContentResult ListExcel(IDbConnection connection, ListRequest requests,
            [FromServices] ISmtpConfigurationListHandler handler,
            [FromServices] IExcelExporter exporter, [FromServices] IUserRetrieveService userRetrieveService)
        {
            var data = List(connection,requests, handler,userRetrieveService).Entities;
            var bytes = exporter.Export(data, typeof(Columns.SmtpConfigurationColumns), requests.ExportColumns);
            return ExcelContentResult.Create(bytes, "SmtpConfigurationList_" +
                DateTime.Now.ToString("yyyyMMdd_HHmmss", CultureInfo.InvariantCulture) + ".xlsx");
        }
    }
}