using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Sales.Forms
{
    [FormScript("Sales.SalesDelivery")]
    [BasedOnRow(typeof(SalesDeliveryRow), CheckNames = true)]
    public class SalesDeliveryForm
    {
        [Tab("General")]
        [Category("Sales Delivery")]
        [HalfWidth]
        public String Number { get; set; }
        [HalfWidth]
        [DefaultValue("now")]
        public DateTime DeliveryDate { get; set; }
        [HalfWidth]
        [TextAreaEditor(Rows = 3)]
        public String Description { get; set; }
        [HalfWidth]
        public Int32 SalesOrderId { get; set; }

        [Category("Delivery Expedition")]
        public Int32 ShipperId { get; set; }

        [Category("Outbound")]
        public Int32 ProjectId { get; set; }

        public Int32 WarehouseId { get; set; }
        public Int32 LocationId { get; set; }


        [Category("Detail")]
        [SalesDeliveryDetailEditor]
        public List<SalesDeliveryDetailRow> ItemList { get; set; }


        [Category("Summary")]
        public Double TotalQtyDelivered { get; set; }
    }
}