using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Projects.Forms
{
    [FormScript("Projects.VwProjectFund")]
    [BasedOnRow(typeof(vwProjectFundRow), CheckNames = true)]
    public class VwProjectFundForm
    {
        public String ProjectName { get; set; }
        public Double TotalAllocatedFund { get; set; }
        public Double TotalExpense { get; set; }
        public Double AvailableFund { get; set; }
    }
}