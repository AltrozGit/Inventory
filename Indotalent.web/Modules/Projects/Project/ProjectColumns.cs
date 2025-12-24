using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Projects.Project.Columns
{
    [ColumnsScript("Projects.Project")]
    [BasedOnRow(typeof(ProjectRow), CheckNames = true)]
    public class ProjectColumns
    {
        [EditLink]
        [Width(200)]
        public String Name { get; set; }

        [DisplayName("Allocated Fund"), Width(150)]

        public Double TotalAllocatedFund { get; set; }

        [Width(150)]

        public Double TotalProjectExpense { get; set; }

        [Width(150)]
        public Double TotalAvailableFund { get; set; }


        public string State {  get; set; }  


    }
}