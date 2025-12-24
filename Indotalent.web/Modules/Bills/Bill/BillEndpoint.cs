using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml.Style;
using OfficeOpenXml;
using Serenity;
using Serenity.Data;
using Serenity.Reporting;
using Serenity.Services;
using Serenity.Web;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using MyRow = Indotalent.Bills.BillRow;

namespace Indotalent.Bills.Endpoints
{
    [Route("Services/Bills/Bill/[action]")]
    [ConnectionKey(typeof(MyRow)), ServiceAuthorize(typeof(MyRow))]
    public class BillController : ServiceEndpoint
    {
        [HttpPost, AuthorizeCreate(typeof(MyRow))]
        public SaveResponse Create(IUnitOfWork uow, SaveRequest<MyRow> request,
            [FromServices] IBillSaveHandler handler)
        {
            return handler.Create(uow, request);
        }

        [HttpPost, AuthorizeUpdate(typeof(MyRow))]
        public SaveResponse Update(IUnitOfWork uow, SaveRequest<MyRow> request,
            [FromServices] IBillSaveHandler handler)
        {
            return handler.Update(uow, request);
        }
 
        [HttpPost, AuthorizeDelete(typeof(MyRow))]
        public DeleteResponse Delete(IUnitOfWork uow, DeleteRequest request,
            [FromServices] IBillDeleteHandler handler)
        {
            return handler.Delete(uow, request);
        }

        [HttpPost]
        public RetrieveResponse<MyRow> Retrieve(IDbConnection connection, RetrieveRequest request,
            [FromServices] IBillRetrieveHandler handler)
        {
            return handler.Retrieve(connection, request);
        }

        [HttpPost]
        public ListResponse<MyRow> List(IDbConnection connection, ListRequest request,
            [FromServices] IBillListHandler handler)
        {
            return handler.List(connection, request);
        }

        public FileContentResult ListExcel(IDbConnection connection, ListRequest request,
            [FromServices] IBillListHandler handler,
            [FromServices] IExcelExporter exporter)
        {
            var data = List(connection, request, handler).Entities;
            using (var package = new ExcelPackage())
            {
                ExcelWorksheets worksheets = package.Workbook.Worksheets;
                var ws = package.Workbook.Worksheets.Add("Bill Excel Report");
                ws.Cells["A1"].Value = "Number";
                ws.Cells["B1"].Value = "Month - Year";
                ws.Cells["C1"].Value = "Bill Date";
                ws.Cells["D1"].Value = "PurchaseOrder Number";
                ws.Cells["E1"].Value = "Total";
              

                int rowIndex = 2;
                foreach (var d in data)
                {
                    ws.Cells["A" + rowIndex].Value = d.Number;
                    ws.Cells["B" + rowIndex].Value = d.BillDate;
                    ws.Cells["C" + rowIndex].Value = d.BillDate;
                    ws.Cells["D" + rowIndex].Value = d.PurchaseOrderNumber;
                    ws.Cells["E" + rowIndex].Value = d.FinalTotalPostTDS_TCS;
                  
                    rowIndex++;
                }
                int totalRows = rowIndex - 1;
                int lastRow = rowIndex + 1;

                var rangeFirstRow = ws.Cells["A1:E1"];//Formatting Table
                rangeFirstRow.Style.Font.Bold = true;
                rangeFirstRow.Style.Fill.PatternType = ExcelFillStyle.Solid;
                rangeFirstRow.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#c2c2f0")); // or any other color you preferhas context menu

                var excelTable = ws.Tables.Add(ws.Cells["A1:E" + totalRows], "BillTable");

                excelTable.ShowFirstColumn = false;
                excelTable.ShowLastColumn = false;
                excelTable.ShowRowStripes = true;
                excelTable.ShowColumnStripes = false;

                using (var range = ws.Cells["A1:E" + totalRows])
                {
                    range.AutoFitColumns();
                    range.Style.Border.Top.Style = ExcelBorderStyle.Thick;
                    range.Style.Border.Bottom.Style = ExcelBorderStyle.Thick;
                    range.Style.Border.Left.Style = ExcelBorderStyle.Thick;
                    range.Style.Border.Right.Style = ExcelBorderStyle.Thick;
                }

                var ms = new MemoryStream();
                package.SaveAs(ms);
                ms.Position = 0;

                return File(ms.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
              "BillExcelDownload_" + DateTime.Now.ToString("yyyyMMdd_HHmmss", CultureInfo.InvariantCulture) + ".xlsx");
            }
            //var bytes = exporter.Export(data, typeof(Columns.BillColumns), request.ExportColumns);
            //return ExcelContentResult.Create(bytes, "BillList_" +
            //    DateTime.Now.ToString("yyyyMMdd_HHmmss", CultureInfo.InvariantCulture) + ".xlsx");


        }

        [HttpPost]
        public BillCurrencyResponse Currency(IDbConnection connection, BillCurrencyRequest request,
           [FromServices] IBillCurrencyHandler handler)
        {
            return handler.Currency(connection, request);
        }
    }
}