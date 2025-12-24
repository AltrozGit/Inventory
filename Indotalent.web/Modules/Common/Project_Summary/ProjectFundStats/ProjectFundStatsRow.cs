using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Indotalent.Web.Modules.Common.Project_Summary.ProjectFundStats
{

    [ConnectionKey("Default"), TableName("[dbo].[vwProjectFund]")]
    [DisplayName("Project Fund Stats"), InstanceName("ProjectFundStats")]
    [ReadPermission("*")]
    [ModifyPermission("*")]
    public class ProjectFundStatsRow : Row<ProjectFundStatsRow.RowFields>
    {
        [DisplayName("Project Id")]
        public int? ProjectId
        {
            get => fields.ProjectId[this];
            set => fields.ProjectId[this] = value;
        }

        [DisplayName("Project Name")]
        public string ProjectName
        {
            get => fields.ProjectName[this];
            set => fields.ProjectName[this] = value;
        }

        [DisplayName("Total Allocated Fund")]
        public Double? TotalAllocatedFund
        {
            get => fields.TotalAllocatedFund[this];
            set => fields.TotalAllocatedFund[this] = value;
        }

        [DisplayName("Total Expense")]
        public Double? TotalExpense
        {
            get => fields.TotalExpense[this];
            set => fields.TotalExpense[this] = value;
        }

        [DisplayName("Available Fund")]
        public Double? AvailableFund
        {
            get => fields.AvailableFund[this];
            set => fields.AvailableFund[this] = value;
        }

        public ProjectFundStatsRow()
           : base()
        {
        }

        public ProjectFundStatsRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field ProjectId;
            public StringField ProjectName;
            public DoubleField TotalAllocatedFund;
            public DoubleField TotalExpense;
            public DoubleField AvailableFund;
        }
    }
}
