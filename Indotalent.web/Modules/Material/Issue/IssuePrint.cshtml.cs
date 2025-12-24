using Indotalent.Inventory;
using Indotalent.Material;

using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Reporting;
using System;
using System.Collections.Generic;

namespace Indotalent.Material
{
    [Report("IssuePrint")]
    [ReportDesign(MVC.Views.Material.Issue.IssuePrint)]
    [RequiredPermission("Material:Issue")]
    public class IssuePrintModel : IReport, ICustomizeHtmlToPdf
    {
        public IssuePrintModel(ISqlConnections sqlConnections)
        {
            SqlConnections = sqlConnections ?? throw new ArgumentNullException(nameof(sqlConnections));
        }

        public int Id { get; set; }

        protected ISqlConnections SqlConnections { get; }

        public object GetData()
        {
            var data = new IssuePrintData();

            using (var connection = SqlConnections.NewFor<IssueRow>())
            {

                var h = IssueRow.Fields;
                data.Header = connection.TryById<IssueRow>(Id, q => q
                     .SelectTableFields()
                     .Select(h.Number));
                    

                var od = IssueDetailRow.Fields;
                data.Details = connection.List<IssueDetailRow>(q => q
                    .SelectTableFields()
                    .Select(od.ProductName)
                .Select(od.QtyRequest)
                .Select(od.PurchasePrice)
                 .Where(od.MaterialIssueId == Id));

                var md = RequestDetailRow.Fields;
                data.Detail = connection.List<RequestDetailRow>(q => q
                    .SelectTableFields()
                    .Select(md.ProductName)
                    .Select(md.QtyRequest)
                    .Select(md.PurchasePrice)
                    .Where(md.MaterialRequestId == Id));

                var c = Settings.MyCompanyRow.Fields;
                data.Company = connection.TryById<Settings.MyCompanyRow>(data.Header.TenantId, q => q
                     .SelectTableFields()
                       .Select(c.StateId)
                 .Select(c.StateName));
            }

            return data;
        }

        public void Customize(IHtmlToPdfOptions options)
        {
        }
    }

    public class IssuePrintData
    {
        
        public IssueRow Header { get; set; }
        public List<IssueDetailRow> Details { get; set; }

        public List<RequestDetailRow> Detail { get; set; }

        public Settings.MyCompanyRow Company { get; set; }
    }
}
