using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Projects.Columns
{
    [ColumnsScript("Projects.ProjectFund")]
    [BasedOnRow(typeof(ProjectFundRow), CheckNames = true)]
    public class ProjectFundColumns
    {
        [EditLink]
        public Int32 Id { get; set; }

        public Double AddedFund { get; set; }
       
        public DateTime FundingDate { get; set; }
        
        public String Description { get; set; }
       
    }
}