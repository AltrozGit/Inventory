using Indotalent.Purchase;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Reporting;
using System;
using System.Collections.Generic;

namespace Indotalent.Purchase
{
    [Report("PurchaseReturnPrint")]
    [ReportDesign(MVC.Views.Purchase.PurchaseReturn.PurchaseReturnPrint)]
    [RequiredPermission("Purchase:PurchaseReturn")]
    public class PurchaseReturnPrintModel : IReport, ICustomizeHtmlToPdf
    {
        public PurchaseReturnPrintModel(ISqlConnections sqlConnections)
        {
            SqlConnections = sqlConnections ?? throw new ArgumentNullException(nameof(sqlConnections));
        }

        public int Id { get; set; }

        protected ISqlConnections SqlConnections { get; }

        public object GetData()
        {
            var data = new PurchaseReturnPrintData();

            using (var connection = SqlConnections.NewFor<PurchaseReturnRow>())
            {

                var h = PurchaseReturnRow.Fields;
                data.Header = connection.TryById<PurchaseReturnRow>(Id, q => q
                     .SelectTableFields()
                     .Select(h.PurchaseReceiptNumber)
                     .Select(h.VendorId));

                var od = PurchaseReturnDetailRow.Fields;
                data.Details = connection.List<PurchaseReturnDetailRow>(q => q
                    .SelectTableFields()
                    .Select(od.ProductName)
                    .Where(od.PurchaseReturnId == Id));

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

    public class PurchaseReturnPrintData
    {
        public PurchaseReturnRow Header { get; set; }
        public List<PurchaseReturnDetailRow> Details { get; set; }
        public VendorRow Vendor { get; set; }
        public Settings.MyCompanyRow Company { get; set; }
    }
}
