using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;
using Indotalent.Web.Modules.Purchase.PurchaseReceipt;

namespace Indotalent.Purchase.Columns
{
    [ColumnsScript("Purchase.PurchaseReceipt")]
    [BasedOnRow(typeof(PurchaseReceiptRow), CheckNames = true)]
    public class PurchaseReceiptColumns
    {
        [EditLink]
        [SortOrder(1, descending: true)]
        [Width(200)]
        public String Number { get; set; }
        [Width(200)]
        public DateTime ReceiptDate { get; set; }
        [Width(200)]
        public String PurchaseOrderNumber { get; set; }
        [Width(200)]
        public Double TotalQtyReceive { get; set; }
        [Width(200)]
        public String TenantName { get; set; }


        //[Width(150)]
        //public Boolean IsBillCreate { get; set; }

        [Width(150)]
        public Boolean IsIssueCreated { get; set; }

        //[Width(150)]
        //public EnumField<Status> Status { get; set; }

    }
}