using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Projects.Forms
{
    [FormScript("Projects.Expense")]
    [BasedOnRow(typeof(ExpenseRow), CheckNames = true)]
    public class ExpenseForm
    {
        [Tab("General")]
        [Category("Expense for Project")]
        public String Name { get; set; }
        [TextAreaEditor(Rows = 3)]
        public String Description { get; set; }
    }
}