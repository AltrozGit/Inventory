using Indotalent.Sales;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Reporting;
using System;
using System.Collections.Generic;

namespace Indotalent.Sales
{
    [Report("SalesDeliveryPrint")]
    [ReportDesign(MVC.Views.Sales.SalesDelivery.SalesDeliveryPrint)]
    [RequiredPermission("Sales:SalesDelivery")]
    public class SalesDeliveryPrintModel : IReport, ICustomizeHtmlToPdf
    {
        public SalesDeliveryPrintModel(ISqlConnections sqlConnections)
        {
            SqlConnections = sqlConnections ?? throw new ArgumentNullException(nameof(sqlConnections));
        }

        public int Id { get; set; }

        protected ISqlConnections SqlConnections { get; }

        public object GetData()
        {
            var data = new SalesDeliveryPrintData();

            using (var connection = SqlConnections.NewFor<SalesDeliveryRow>())
            {

                var h = SalesDeliveryRow.Fields;
                data.Header = connection.TryById<SalesDeliveryRow>(Id, q => q
                     .SelectTableFields()
                     .Select(h.SalesOrderNumber)
                     .Select(h.CustomerId));

                var od = SalesDeliveryDetailRow.Fields;
                data.Details = connection.List<SalesDeliveryDetailRow>(q => q
                    .SelectTableFields()
                    .Select(od.ProductName)
                    .Where(od.SalesDeliveryId == Id));

                var cust = CustomerRow.Fields;
                data.Customer = connection.TryById<CustomerRow>(data.Header.CustomerId, q => q
                     .SelectTableFields()
                     .Select(cust.StateName));

                var c = Settings.MyCompanyRow.Fields;
                data.Company = connection.TryById<Settings.MyCompanyRow>(data.Header.TenantId, q => q
                     .SelectTableFields()
                     .Select(c.Currency)
                     .Select(c.StateName));
            }

            return data;
        }

        public void Customize(IHtmlToPdfOptions options)
        {
        }
    }

    public class SalesDeliveryPrintData
    {
        public SalesDeliveryRow Header { get; set; }
        public List<SalesDeliveryDetailRow> Details { get; set; }
        public CustomerRow Customer { get; set; }
        public Settings.MyCompanyRow Company { get; set; }
    }
}
