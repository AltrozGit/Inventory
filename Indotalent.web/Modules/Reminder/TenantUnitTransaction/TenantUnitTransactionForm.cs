using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Reminder.Forms
{
    [FormScript("Reminder.TenantUnitTransaction")]
    [BasedOnRow(typeof(TenantUnitTransactionRow), CheckNames = true)]
    public class TenantUnitTransactionForm
    {
     
        public Int32 SubscriptionId { get; set; }
        public Int32 Units { get; set; }
        public Int32 ReferenceId { get; set; }
        public String Remark { get; set; }
     
    }
}