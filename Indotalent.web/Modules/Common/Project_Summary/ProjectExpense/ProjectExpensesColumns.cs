using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Web.Modules.Common.Project_Summary.ProjectExpense
{
    [ColumnsScript("Common.ProjectExpenses")]
    [BasedOnRow(typeof(ProjectExpensesRow), CheckNames = true)]
    public class ProjectExpensesColumns
    {
        [Width(200)]
        public string ProjectName { get; set; }
        [Width(200)]
        public string ExpenseName { get; set; }
        [Width(200)]
        public DateTime ExpenseDate { get; set; }
        public decimal Cost { get; set; }
    }
}