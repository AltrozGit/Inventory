using Indotalent.Inventory;
using Indotalent.Purchase;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Reporting;
using System;
using System.Collections.Generic;

namespace Indotalent.Purchase
{
    [Report("PurchaseReceiptPrint")]
    [ReportDesign(MVC.Views.Purchase.PurchaseReceipt.PurchaseReceiptPrint)]
    [RequiredPermission("Purchase:PurchaseReceipt")]
    public class PurchaseReceiptPrintModel : IReport, ICustomizeHtmlToPdf
    {
        public PurchaseReceiptPrintModel(ISqlConnections sqlConnections)
        {
            SqlConnections = sqlConnections ?? throw new ArgumentNullException(nameof(sqlConnections));
        }

        public int Id { get; set; }

        protected ISqlConnections SqlConnections { get; }

        public object GetData()
        {
            var data = new PurchaseReceiptPrintData();

            using (var connection = SqlConnections.NewFor<PurchaseReceiptRow>())
            {

                var h = PurchaseReceiptRow.Fields;
                data.Header = connection.TryById<PurchaseReceiptRow>(Id, q => q
                     .SelectTableFields()
                     .Select(h.PurchaseOrderNumber)
                     .Select(h.VendorId));

                var od = PurchaseReceiptDetailRow.Fields;
                data.Details = connection.List<PurchaseReceiptDetailRow>(q => q
                    .SelectTableFields()
                    .Select(od.ProductName)
                    .Where(od.PurchaseReceiptId == Id));

              
                var vendor = VendorRow.Fields;
                data.Vendor = connection.TryById<VendorRow>(data.Header.VendorId, q => q
                     .SelectTableFields()
                     .Select(vendor.StateName));


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

    public class PurchaseReceiptPrintData
    {
        public PurchaseReceiptRow Header { get; set; }
        public List<PurchaseReceiptDetailRow> Details{ get; set; }
        public VendorRow Vendor { get; set; }
        public Settings.MyCompanyRow Company { get; set; }
    }
}
