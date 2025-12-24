using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Reminder.Columns
{
    [ColumnsScript("Reminder.PlanSetting")]
    [BasedOnRow(typeof(PlanSettingRow), CheckNames = true)]
    public class PlanSettingColumns
    {
      

        [EditLink]
        [Width(150)]
        public String ProductName { get; set; }

        public String PlanName { get; set; }
        
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
    }
}