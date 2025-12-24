using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Reporting;
using System;
using System.Collections.Generic;

namespace Indotalent.Inventory
{
    [Report("PositiveAdjustmentPrint")]
    [ReportDesign(MVC.Views.Inventory.PositiveAdjustment.PositiveAdjustmentPrint)]
    [RequiredPermission("Inventory:PositiveAdjustment")]
    public class PositiveAdjustmentPrintModel : IReport, ICustomizeHtmlToPdf
    {
        public PositiveAdjustmentPrintModel(ISqlConnections sqlConnections)
        {
            SqlConnections = sqlConnections ?? throw new ArgumentNullException(nameof(sqlConnections));
        }

        public int Id { get; set; }

        protected ISqlConnections SqlConnections { get; }

        public object GetData()
        {
            var data = new PositiveAdjustmentPrintData();

            using (var connection = SqlConnections.NewFor<PositiveAdjustmentRow>())
            {
                var h = PositiveAdjustmentRow.Fields;
                data.Header = connection.TryById<PositiveAdjustmentRow>(Id, q => q
                     .SelectTableFields()
                     .Select(h.ProjectName)
                     .Select(h.WarehouseName)
                     .Select(h.LocationName));

                var d = PositiveAdjustmentDetailRow.Fields;
                data.Details = connection.List<PositiveAdjustmentDetailRow>(q => q
                    .SelectTableFields()
                    .Select(d.ProductName)
                    .Where(d.PositiveAdjustmentId == Id));
            }

            return data;
        }

        public void Customize(IHtmlToPdfOptions options)
        {
        }
    }


    public class PositiveAdjustmentPrintData
    {
        public PositiveAdjustmentRow Header { get; set; }
        public List<PositiveAdjustmentDetailRow> Details { get; set; }
    }

}
