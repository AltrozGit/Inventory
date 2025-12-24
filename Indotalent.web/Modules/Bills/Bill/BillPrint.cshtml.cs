using Indotalent.Purchase;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Reporting;
using System;
using System.Collections.Generic;

namespace Indotalent.Bills
{
    [Report("BillPrint")]
    [ReportDesign(MVC.Views.Bills.Bill.BillPrint)]
    [RequiredPermission("Bills:Bill")]
    public class BillPrintModel : IReport, ICustomizeHtmlToPdf
    {
        public BillPrintModel(ISqlConnections sqlConnections)
        {
            SqlConnections = sqlConnections ?? throw new ArgumentNullException(nameof(sqlConnections));
        }

        public int Id { get; set; }

        protected ISqlConnections SqlConnections { get; }

        public object GetData()
        {
            var data = new BillPrintData();

            using (var connection = SqlConnections.NewFor<BillRow>())
            {
                var h = BillRow.Fields;
                data.Header = connection.TryById<BillRow>(Id, q => q
                     .SelectTableFields()
                     .Select(h.PurchaseOrderNumber)
                     .Select(h.VendorId)
                     .Select(h.DispatchedBy)
                     .Select(h.DispatchedTo)
                     .Select(h.DispatchDetails));

                var d = BillDetailRow.Fields;
                data.Details = connection.List<BillDetailRow>(q => q
                    .SelectTableFields()
                    .Select(d.ProductName)
                      .Select(d.InternalCode)
                    .Where(d.BillId == Id));

               
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

    public class BillPrintData
    {
        public BillRow Header { get; set; }
        public List<BillDetailRow> Details { get; set; }
        public Purchase.VendorRow Vendor { get; set; }
        public Settings.MyCompanyRow Company { get; set; }
    }
}
