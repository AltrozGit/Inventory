using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Inventory.Forms
{
    [FormScript("Inventory.PositiveAdjustmentDetail")]
    [BasedOnRow(typeof(PositiveAdjustmentDetailRow), CheckNames = true)]
    public class PositiveAdjustmentDetailForm
    {
        [Tab("General")]
        [Category("Product to adjust")]
        public Int32 ProductId { get; set; }

        [Category("Quantity adjustment")]
        public Double Qty { get; set; }
    }
}