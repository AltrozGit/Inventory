using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Reminder.Columns
{
    [ColumnsScript("Reminder.TenantUnitTransaction")]
    [BasedOnRow(typeof(TenantUnitTransactionRow), CheckNames = true)]
    public class TenantUnitTransactionColumns
    {
        [EditLink]
        [Width(150)]

       
        public String Remark { get; set; }
        [Width(150)]

        public Int32 SubscriptionId { get; set; }
        [Width(150)]

        public Int32 Units { get; set; }
        [Width(150)]

        public Int32 ReferenceId { get; set; }
        [Width(150)]

        public String TenantName { get; set; }



    }
}