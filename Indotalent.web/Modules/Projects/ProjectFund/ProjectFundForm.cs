using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Projects.Forms
{
    [FormScript("Projects.ProjectFund")]
    [BasedOnRow(typeof(ProjectFundRow), CheckNames = true)]
    public class ProjectFundForm
    {
        public Double AddedFund { get; set; }

        [DefaultValue("now")]
        public DateTime FundingDate { get; set; }
        
        public String Description { get; set; }
       
    }
}