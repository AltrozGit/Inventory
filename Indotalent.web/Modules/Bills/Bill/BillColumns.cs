using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Bills.Columns
{
    [ColumnsScript("Bills.Bill")]
    [BasedOnRow(typeof(BillRow), CheckNames = true)]
    public class BillColumns
    {
        [EditLink]
        [SortOrder(1, descending: true)]
        public String Number { get; set; }
        public DateTime BillDate { get; set; }
        public String PurchaseOrderNumber { get; set; }
        //public String PurchaseReceiptNumber { get; set; }

        [Width(200)]
        public String VendorName { get; set; }
        [Width(200)]
        public Double FinalTotalPostTDS_TCS { get; set; }
        public String TenantName { get; set; }
    }
}