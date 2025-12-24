using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Projects.Columns
{
    [ColumnsScript("Projects.ProjectExpense")]
    [BasedOnRow(typeof(ProjectExpenseRow), CheckNames = true)]
    public class ProjectExpenseColumns
    {
    
        [EditLink]
        [Width(200)]
        public String ProjectName { get; set; }
        [Width(200)]
        public String ExpenseName { get; set; }
		[Width(200)]
		public DateTime ExpenseDate { get; set; }
		public decimal Cost { get; set; }

      //  public double TotalAllocatedFund { get; set; }
      
    }
}