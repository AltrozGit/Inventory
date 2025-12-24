using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Sales.Forms
{
    [FormScript("Sales.SalesReturn")]
    [BasedOnRow(typeof(SalesReturnRow), CheckNames = true)]
    public class SalesReturnForm
    {
        [Tab("General")]
        [Category("Sales Return")]
        [HalfWidth]
        public String Number { get; set; }
        [HalfWidth]
        [DefaultValue("now")]
        public DateTime ReturnDate { get; set; }
        [HalfWidth]
        [TextAreaEditor(Rows = 3)]
        public String Description { get; set; }
        [HalfWidth]
        public Int32 SalesDeliveryId { get; set; }

        [Category("Inbound")]
        public Int32 ProjectId { get; set; }

        public Int32 WarehouseId { get; set; }
        public Int32 LocationId { get; set; }

        [Category("Detail")]
        [SalesReturnDetailEditor]
        public List<SalesReturnDetailRow> ItemList { get; set; }


        [Category("Summary")]
        public Double TotalQtyReturn { get; set; }
    }
}