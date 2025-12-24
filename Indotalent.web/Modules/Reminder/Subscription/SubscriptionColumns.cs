using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Reminder.Columns
{
    [ColumnsScript("Reminder.Subscription")]
    [BasedOnRow(typeof(SubscriptionRow), CheckNames = true)]
    public class SubscriptionColumns
    {
        [EditLink]
        [Width(150)]

        public String ProductName { get; set; }

        [Width(150)]

        public String PlanName { get; set; }
       
        [Width(150)]

        public DateTime StartDate { get; set; }
        [Width(150)]

        public DateTime EndDate { get; set; }
        [Width(150)]

        public Boolean IsActive { get; set; }
        [Width(150)]

        public Boolean IsArchive { get; set; }
        [Width(150)]

        public DateTime ActiveEndDate { get; set; }
        [Width(150)]

        public Int32 TotalUnits { get; set; }
        [Width(150)]

        public Int32 CurrentBalanceUnits { get; set; }
      
        [Width(150)]

        public Int32 ApplicationTenantId { get; set; }

    }
}