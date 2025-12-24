using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Inventory.Forms
{
    [FormScript("Inventory.TransferOrderDetail")]
    [BasedOnRow(typeof(TransferOrderDetailRow), CheckNames = true)]
    public class TransferOrderDetailForm
    {
        [Tab("General")]
        [Category("Product to transfer")]
        public Int32 ProductId { get; set; }

        [Category("Quantity transfer")]
        public Double Qty { get; set; }
    }
}