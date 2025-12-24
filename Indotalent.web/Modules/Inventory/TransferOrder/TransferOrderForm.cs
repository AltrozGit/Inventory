using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Inventory.Forms
{
    [FormScript("Inventory.TransferOrder")]
    [BasedOnRow(typeof(TransferOrderRow), CheckNames = true)]
    public class TransferOrderForm
    {
        [Tab("General")]
        [Category("Tranfer Order")]
        public String Number { get; set; }
        [TextAreaEditor(Rows = 3)]
        public String Description { get; set; }
        [DefaultValue("now")]
        public DateTime TransferDate { get; set; }
        [Category("Project From To")]
        public Int32 ProjectFromId { get; set; }
        public Int32 ProjectToId { get; set; }

        [Category("Warehouse From To")]
        public Int32 FromId { get; set; }
        public Int32 ToId { get; set; }

        [Category("Detail")]
        [TransferOrderDetailEditor]
        public List<TransferOrderDetailRow> ItemList { get; set; }

        [Category("Summary")]
        public Double TotalQty { get; set; }
    }
}