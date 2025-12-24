using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Reporting;
using System;
using System.Collections.Generic;

namespace Indotalent.Inventory
{
    [Report("NegativeAdjustmentPrint")]
    [ReportDesign(MVC.Views.Inventory.NegativeAdjustment.NegativeAdjustmentPrint)]
    [RequiredPermission("Inventory:NegativeAdjustment")]
    public class NegativeAdjustmentPrintModel : IReport, ICustomizeHtmlToPdf
    {
        public NegativeAdjustmentPrintModel(ISqlConnections sqlConnections)
        {
            SqlConnections = sqlConnections ?? throw new ArgumentNullException(nameof(sqlConnections));
        }

        public int Id { get; set; }

        protected ISqlConnections SqlConnections { get; }

        public object GetData()
        {
            var data = new NegativeAdjustmentPrintData();

            using (var connection = SqlConnections.NewFor<NegativeAdjustmentRow>())
            {
                var h = NegativeAdjustmentRow.Fields;
                data.Header = connection.TryById<NegativeAdjustmentRow>(Id, q => q
                     .SelectTableFields()
                     .Select(h.ProjectName)

                     .Select(h.WarehouseName)
                     .Select(h.LocationName));

                var d = NegativeAdjustmentDetailRow.Fields;
                data.Details = connection.List<NegativeAdjustmentDetailRow>(q => q
                    .SelectTableFields()
                    .Select(d.ProductName)
                    .Where(d.NegativeAdjustmentId == Id));
            }

            return data;
        }

        public void Customize(IHtmlToPdfOptions options)
        {
        }
    }


    public class NegativeAdjustmentPrintData
    {
        public NegativeAdjustmentRow Header { get; set; }
        public List<NegativeAdjustmentDetailRow> Details { get; set; }
    }

}
