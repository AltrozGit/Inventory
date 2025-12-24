using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Reminder.Columns
{
    [ColumnsScript("Reminder.Plan")]
    [BasedOnRow(typeof(PlanRow), CheckNames = true)]
    public class PlanColumns
    {
        [Width(150)]

        [EditLink]
        public String PlanName { get; set; }
        [Width(150)]

        public String Product { get; set; }
        [Width(150)]

        public Decimal Cost { get; set; }
        [Width(150)]

        public Int32 Units { get; set; }
        [Width(150)]

        public String Frequency { get; set; }
        [Width(150)]

        public Boolean IsActive { get; set; }
        [Width(150)]

        public String Type { get; set; }
        [Width(150)]

        public String TenantName { get; set; }


    }
}