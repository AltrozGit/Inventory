using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Sales.Forms
{
    [FormScript("Sales.SalesReturnDetail")]
    [BasedOnRow(typeof(SalesReturnDetailRow), CheckNames = true)]
    public class SalesReturnDetailForm
    {
        [Tab("General")]
        [Category("Main")]
        public Int32 ProductId { get; set; }

        [Category("Return")]
        public Double QtyReturn { get; set; }
    }
}