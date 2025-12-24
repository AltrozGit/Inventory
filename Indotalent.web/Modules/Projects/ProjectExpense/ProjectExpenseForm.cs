using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;
using Org.BouncyCastle.Asn1.Pkcs;


namespace Indotalent.Projects.Forms
{
    [FormScript("Projects.ProjectExpense")]
    [BasedOnRow(typeof(ProjectExpenseRow), CheckNames = true)]
    public class ProjectExpenseForm
    {
        [Tab("General")]

        public Int32 ProjectId { get; set; }
        [TextAreaEditor(Rows = 3)]
        public String Notes { get; set; }
        [DefaultValue("now")]
        public Int32 ExpenseId { get; set; }
        [HalfWidth]
        [DefaultValue("now")]

        public DateTime ExpenseDate { get; set; }

        public decimal Cost { get; set; }

       // public Double TotalAllocatedFund { get; set; }
    }
}