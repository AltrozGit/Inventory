using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Projects.Columns
{
    [ColumnsScript("Projects.VwProjectFund")]
    [BasedOnRow(typeof(vwProjectFundRow), CheckNames = true)]
    public class VwProjectFundColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 ProjectId { get; set; }
        [EditLink]
        public String ProjectName { get; set; }
        public Double TotalAllocatedFund { get; set; }
        public Double TotalExpense { get; set; }
        public Double AvailableFund { get; set; }
    }
}