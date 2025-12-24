using Indotalent.Sales;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Reporting;
using System;
using System.Collections.Generic;

namespace Indotalent.Sales
{
    [Report("SalesReturnPrint")]
    [ReportDesign(MVC.Views.Sales.SalesReturn.SalesReturnPrint)]
    [RequiredPermission("Sales:SalesReturn")]
    public class SalesReturnPrintModel : IReport, ICustomizeHtmlToPdf
    {
        public SalesReturnPrintModel(ISqlConnections sqlConnections)
        {
            SqlConnections = sqlConnections ?? throw new ArgumentNullException(nameof(sqlConnections));
        }

        public int Id { get; set; }

        protected ISqlConnections SqlConnections { get; }

        public object GetData()
        {
            var data = new SalesReturnPrintData();

            using (var connection = SqlConnections.NewFor<SalesReturnRow>())
            {

                var h = SalesReturnRow.Fields;
                data.Header = connection.TryById<SalesReturnRow>(Id, q => q
                     .SelectTableFields()
                     .Select(h.SalesDeliveryNumber)
                     .Select(h.CustomerId));

                var od = SalesReturnDetailRow.Fields;
                data.Details = connection.List<SalesReturnDetailRow>(q => q
                    .SelectTableFields()
                    .Select(od.ProductName)
                    .Where(od.SalesReturnId == Id));

                var cust = CustomerRow.Fields;
                data.Customer = connection.TryById<CustomerRow>(data.Header.CustomerId, q => q
                     .SelectTableFields()
                     .Select(cust.StateName));

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

    public class SalesReturnPrintData
    {
        public SalesReturnRow Header { get; set; }
        public List<SalesReturnDetailRow> Details { get; set; }
        public CustomerRow Customer { get; set; }
        public Settings.MyCompanyRow Company { get; set; }
    }
}
