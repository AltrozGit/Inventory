
using Indotalent.Bills;
using Indotalent.Web.Modules.Bills.BillDetail.RequestHandlers;
using Indotalent.Web.Modules.Purchase.PurchaseOrderDetail.RequestHandlers;
using Microsoft.AspNetCore.Mvc;
using Serenity;
using Serenity.Data;
using Serenity.Reporting;
using Serenity.Services;
using Serenity.Web;
using System;
using System.Data;
using System.Globalization;
using MyRow = Indotalent.Bills.BillDetailRow;

namespace Indotalent.Bills.Endpoints
{
    [Route("Services/Bills/BillDetail/[action]")]
    [ConnectionKey(typeof(MyRow)), ServiceAuthorize(typeof(MyRow))]
    public class BillDetailController : ServiceEndpoint
    {
        [HttpPost, AuthorizeCreate(typeof(MyRow))]
        public SaveResponse Create(IUnitOfWork uow, SaveRequest<MyRow> request,
            [FromServices] IBillDetailSaveHandler handler)
        {
            return handler.Create(uow, request);
        }

        [HttpPost, AuthorizeUpdate(typeof(MyRow))]
        public SaveResponse Update(IUnitOfWork uow, SaveRequest<MyRow> request,
            [FromServices] IBillDetailSaveHandler handler)
        {
            return handler.Update(uow, request);
        }
 
        [HttpPost, AuthorizeDelete(typeof(MyRow))]
        public DeleteResponse Delete(IUnitOfWork uow, DeleteRequest request,
            [FromServices] IBillDetailDeleteHandler handler)
        {
            return handler.Delete(uow, request);
        }

        [HttpPost]
        public RetrieveResponse<MyRow> Retrieve(IDbConnection connection, RetrieveRequest request,
            [FromServices] IBillDetailRetrieveHandler handler)
        {
            return handler.Retrieve(connection, request);
        }

        [HttpPost]
        public ListResponse<MyRow> List(IDbConnection connection, ListRequest request,
            [FromServices] IBillDetailListHandler handler)
        {
            return handler.List(connection, request);
        }

        public FileContentResult ListExcel(IDbConnection connection, ListRequest request,
            [FromServices] IBillDetailListHandler handler,
            [FromServices] IExcelExporter exporter)
        {
            var data = List(connection, request, handler).Entities;
            var bytes = exporter.Export(data, typeof(Columns.BillDetailColumns), request.ExportColumns);
            return ExcelContentResult.Create(bytes, "BillDetailList_" +
                DateTime.Now.ToString("yyyyMMdd_HHmmss", CultureInfo.InvariantCulture) + ".xlsx");
        }
        [HttpPost]
        public BillDetailIsBillPaymentGeneratedResponse CheckBillPaymentGenerated(IDbConnection connection, BillDetailIsBillPaymentGeneratedRequest request,
           [FromServices] IBillDetailIsBillPaymentGeneratedHandler handler)
        {
            return handler.CheckBillPaymentGenerated(connection, request);
        }


        [HttpPost]
        public BillDetailGetQuantityOfBillCreatedResponse GetQuantityOfBillCreated(IDbConnection connection, BillDetailGetQuantityOfBillCreatedRequest request,
         [FromServices] IBillDetailGetQuantityOfBillCreatedHandler handler)
        {
            return handler.GetQuantityOfBillCreated(connection, request);
        }

    }
}