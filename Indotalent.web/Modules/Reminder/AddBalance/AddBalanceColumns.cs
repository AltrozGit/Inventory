using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Reminder.Columns
{
    [ColumnsScript("Reminder.AddBalance")]
    [BasedOnRow(typeof(AddBalanceRow), CheckNames = true)]
    public class AddBalanceColumns
    {

        [EditLink]
        [Width(150)]
        public String ProductName { get; set; }
        [Width(150)]
        public String CustomerName { get; set; }
        [Width(150)]
        public String PlanName { get; set; }
       
        [Width(150)]
        public Decimal Cost { get; set; }
        [Width(150)]
        public Int32 Units { get; set; }
        [Width(150)]



        public String Frequency { get; set; }

        [Width(150)]


        public String Type { get; set; }
        [Width(150)]
        public DateTime RechargeDate { get; set; }
        [Width(150)]

      //  public String TenantName { get; set; }
      

        public DateTime ValidThrough { get; set; }
        [Width(150)]
        public Int32 ApplicationTenantId { get; set; }
    }
}