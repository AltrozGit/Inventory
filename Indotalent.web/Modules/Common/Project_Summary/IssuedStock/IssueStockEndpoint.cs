using Indotalent.Common;
using Microsoft.AspNetCore.Mvc;
using Serenity;
using Serenity.Data;
using Serenity.Reporting;
using Serenity.Services;
using Serenity.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using MyRow = Indotalent.Web.Modules.Common.Project_Summary.IssuedStock.IssueStockRow;

namespace Indotalent.Web.Modules.Common.Project_Summary.IssuedStock
{
    [Route("Services/Common/Dashboard/Project/IssueStock/[action]")]
    [ConnectionKey(typeof(MyRow)), ServiceAuthorize(typeof(MyRow))]
    public class IssueStockController : ServiceEndpoint
    {
        [HttpPost]
        public ListResponse<MyRow> List(IDbConnection connection, ListRequest request,
            [FromServices] IIssueStockListHandler handler)
        {
            return handler.List(connection, request);
        }

        public FileContentResult ListExcel(IDbConnection connection, ListRequest request,
            [FromServices] IIssueStockListHandler handler,
            [FromServices] IExcelExporter exporter)
        {
            var data = List(connection, request, handler).Entities;
            var bytes = exporter.Export(data, typeof(IssueStockColumns), request.ExportColumns);
            return ExcelContentResult.Create(bytes, "IssueStockList_" +
                DateTime.Now.ToString("yyyyMMdd_HHmmss", CultureInfo.InvariantCulture) + ".xlsx");
        }
    }
}