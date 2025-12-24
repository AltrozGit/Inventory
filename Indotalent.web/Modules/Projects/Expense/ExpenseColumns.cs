using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Projects.Columns
{
    [ColumnsScript("Projects.Expense")]
    [BasedOnRow(typeof(ExpenseRow), CheckNames = true)]
    public class ExpenseColumns
    {
        [EditLink]
        [Width(200)]
        public String Name { get; set; }
      
    }
}