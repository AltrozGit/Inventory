using Indotalent.Purchase;
using Indotalent.Sales;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Reporting;
using System;
using System.Collections.Generic;

namespace Indotalent.Projects
{
    [Report("QuotationPrint")]
    [ReportDesign(MVC.Views.Projects.Quotation.QuotationPrint)]
    [RequiredPermission("Projects:Quotation")]
    public class QuotationPrintModel : IReport, ICustomizeHtmlToPdf
    {
        public QuotationPrintModel(ISqlConnections sqlConnections)
        {
            SqlConnections = sqlConnections ?? throw new ArgumentNullException(nameof(sqlConnections));
        }

        public int Id { get; set; }

        protected ISqlConnections SqlConnections { get; }

        public object GetData()
        {
            var data = new QuotationPrintData();

            using (var connection = SqlConnections.NewFor<QuotationRow>())
            {

                data.Header = connection.TryById<QuotationRow>(Id, q => q
                     .SelectTableFields());

                var od = QuotationDetailRow.Fields;
                data.Details = connection.List<QuotationDetailRow>(q => q
                    .SelectTableFields()
                    .Select(od.ProductName)
                    .Where(od.QuotationId == Id));

                data.Details = connection.List<QuotationDetailRow>(q => q
                  .SelectTableFields()
                  .Select(od.ProductName)
                  .Select(od.InternalCode)
                  .Where(od.QuotationId == Id));


                var cust = CustomerRow.Fields;
                data.Customer = connection.TryById<CustomerRow>(data.Header.CustomerId, q => q
                     .SelectTableFields()
                     .Select(cust.StateName));

                var c = Settings.MyCompanyRow.Fields;
                data.Company = connection.TryById<Settings.MyCompanyRow>(data.Header.TenantId, q => q
                     .SelectTableFields()
                     .Select(c.StateName));
            }

            return data;
        }

        public void Customize(IHtmlToPdfOptions options)
        {
        }
    }

    public class QuotationPrintData
    {
        public QuotationRow Header { get; set; }
        public List<QuotationDetailRow> Details { get; set; }
        public CustomerRow Customer { get; set; }
        public Settings.MyCompanyRow Company { get; set; }
    }
}
