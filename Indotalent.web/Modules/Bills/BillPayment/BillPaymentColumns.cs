using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Bills.Columns
{
    [ColumnsScript("Bills.BillPayment")]
    [BasedOnRow(typeof(BillPaymentRow), CheckNames = true)]
    public class BillPaymentColumns
    {
        [EditLink]
        [SortOrder(1, descending: true)]
        public String Number { get; set; }
        [Width(100)]
        public DateTime PaymentDate { get; set; }
        public String BillNumber { get; set; }

        public String VendorName { get; set; }

        public String CashBankName { get; set; }
        [Width(150)]
        public Double PaymentAmount { get; set; }
        //public String TenantName { get; set; }
    }
}