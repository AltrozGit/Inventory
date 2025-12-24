using Indotalent.Web.Modules.Common.Project_Summary.ProjectExpense.RequestHandlers;
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
using MyRow = Indotalent.Web.Modules.Common.Project_Summary.ProjectExpense.ProjectExpensesRow;

namespace Indotalent.Web.Modules.Common.Project_Summary.ProjectExpense
{
    [Route("Services/Common/Dashboard/Project/ProjectExpenses/[action]")]
    [ConnectionKey(typeof(MyRow)), ServiceAuthorize(typeof(MyRow))]
    public class ProjectExpensesController : ServiceEndpoint
    {
        [HttpPost]
        public ListResponse<MyRow> List(IDbConnection connection, ListRequest request,
            [FromServices] IProjectExpensesListHandler handler)
        {
            return handler.List(connection, request);
        }

        public FileContentResult ListExcel(IDbConnection connection, ListRequest request,
            [FromServices] IProjectExpensesListHandler handler,
            [FromServices] IExcelExporter exporter)
        {
            var data = List(connection, request, handler).Entities;
            var bytes = exporter.Export(data, typeof(ProjectExpensesColumns), request.ExportColumns);
            return ExcelContentResult.Create(bytes, "ProjectExpenseList" +
                DateTime.Now.ToString("yyyyMMdd_HHmmss", CultureInfo.InvariantCulture) + ".xlsx");
        }
    }
}