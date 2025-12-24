using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Purchase.Forms
{
    [FormScript("Purchase.PurchaseReturnDetail")]
    [BasedOnRow(typeof(PurchaseReturnDetailRow), CheckNames = true)]
    public class PurchaseReturnDetailForm
    {
        [Tab("General")]
        [Category("Main")]
        public Int32 ProductId { get; set; }

        [Category("Return")]
        public Double QtyReturn { get; set; }
    }
}