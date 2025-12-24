using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Inventory.Forms
{
    [FormScript("Inventory.PositiveAdjustment")]
    [BasedOnRow(typeof(PositiveAdjustmentRow), CheckNames = true)]
    public class PositiveAdjustmentForm
    {
        [Tab("General")]
        [Category("Positive Adjustment")]
        public String Number { get; set; }
        [TextAreaEditor(Rows = 3)]
        public String Description { get; set; }
        [DefaultValue("now")]
        public DateTime AdjustmentDate { get; set; }

        [Category("Warehouse And Location")]
        public Int32 ProjectId { get; set; }
        public Int32 WarehouseId { get; set; }
        public Int32 LocationId { get; set; }

        [Category("Detail")]
        [PositiveAdjustmentDetailEditor]
        public List<PositiveAdjustmentDetailRow> ItemList { get; set; }

        [Category("Summary")]
        public Double TotalQty { get; set; }
    }
}