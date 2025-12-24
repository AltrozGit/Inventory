using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Material.Forms
{
    [FormScript("Material.RequestDetail")]
    [BasedOnRow(typeof(RequestDetailRow), CheckNames = true)]
    public class RequestDetailForm
    {
        [Tab("General")]
        [Category("Product to Request")]
        public Int32 ProductId { get; set; }
        public Double? PurchasePrice { get; set; }
        [HalfWidth]
        public Int32 UomId { get; set; }
        [HalfWidth]
        public String InternalCode { get; set; }
        [HalfWidth]
        [Hidden]
        public Int32 SacId { get; set; }
        [Hidden]
        [HalfWidth]
        public Int32 HsnId { get; set; }

        [Category("Quantity Request and Total Price")]
        [HalfWidth]
        public Double QtyRequest { get; set; }
        [HalfWidth]
        public Double SubTotal { get; set; }

        [Hidden]
        public Int32 QuanityOfPOCreated { get; set; }
        [Hidden]
        public Boolean IsPOComplete { get; set; }

        
    }
}