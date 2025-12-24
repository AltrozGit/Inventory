using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Sales.Forms
{
    [FormScript("Sales.SalesDeliveryDetail")]
    [BasedOnRow(typeof(SalesDeliveryDetailRow), CheckNames = true)]
    public class SalesDeliveryDetailForm
    {
        [Tab("General")]
        [Category("Main")]
        public Int32 ProductId { get; set; }

        [Category("Delivered")]
        public Double QtyDelivered { get; set; }
    }
}