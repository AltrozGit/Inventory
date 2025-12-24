using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Reporting;
using System;
using System.Collections.Generic;

namespace Indotalent.Inventory
{
    [Report("TransferOrderPrint")]
    [ReportDesign(MVC.Views.Inventory.TransferOrder.TransferOrderPrint)]
    [RequiredPermission("Inventory:TransferOrder")]
    public class TransferOrderPrintModel : IReport, ICustomizeHtmlToPdf
    {
        public TransferOrderPrintModel(ISqlConnections sqlConnections)
        {
            SqlConnections = sqlConnections ?? throw new ArgumentNullException(nameof(sqlConnections));
        }

        public int Id { get; set; }

        protected ISqlConnections SqlConnections { get; }

        public object GetData()
        {
            var data = new TransferOrderPrintData();

            using (var connection = SqlConnections.NewFor<TransferOrderRow>())
            {

                var h = TransferOrderRow.Fields;
                data.Header = connection.TryById<TransferOrderRow>(Id, q => q
                     .SelectTableFields()
                     .Select(h.FromName)
                     .Select(h.FromStreet)
                     .Select(h.FromCity)
                     .Select(h.FromState)
                     .Select(h.FromZipCode)
                     .Select(h.FromPhone)
                     .Select(h.FromEmail)
                     .Select(h.ToName)
                     .Select(h.ToStreet)
                     .Select(h.ToCity)
                     .Select(h.ToState)
                     .Select(h.ToZipCode)
                     .Select(h.ToPhone)
                     .Select(h.ToEmail));

                var od = TransferOrderDetailRow.Fields;
                data.Details = connection.List<TransferOrderDetailRow>(q => q
                    .SelectTableFields()
                    .Select(od.ProductName)
                    .Where(od.TransferOrderId == Id));
            }

            return data;
        }

        public void Customize(IHtmlToPdfOptions options)
        {
        }
    }

    public class TransferOrderPrintData
    {
        public TransferOrderRow Header { get; set; }
        public List<TransferOrderDetailRow> Details { get; set; }
    }
}
