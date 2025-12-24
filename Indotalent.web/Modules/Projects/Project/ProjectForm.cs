using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Projects.Forms
{
    [FormScript("Projects.Project")]
    [BasedOnRow(typeof(ProjectRow), CheckNames = true)]
    public class ProjectForm
    {
        [Tab("General")]

        [Category("Project Info")]
        public String Name { get; set; }

        public String CustomerName { get; set; }

        [TextAreaEditor(Rows = 3)]
        public String Description { get; set; }

        [Category("Address")]
        public String Street { get; set; }
        public String City { get; set; }
        public String State { get; set; }
        public String ZipCode { get; set; }
        public String Phone { get; set; }
        public String Email { get; set; }

        [Tab("Add Project Fund")]

        [Category("Fund Summary")]
        public Double TotalAllocatedFund { get; set; }
        public Double TotalAvailableFund { get; set; }
        public Double TotalProjectExpense { get; set; }

        [Category("Add Fund")]
        [ProjectFundEditor]
        public List<ProjectFundRow> FundList { get; set; }
    }
}