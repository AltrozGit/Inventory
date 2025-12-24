using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;
using System.IO;

namespace Indotalent.Projects
{
    [ConnectionKey("Default"), Module("Projects"), TableName("[dbo].[vwProjectFund]")]
    [DisplayName("Vw Project Fund"), InstanceName("Vw Project Fund")]
    [ReadPermission("Projects:vwProjectFund")]
    [ModifyPermission("Projects:vwProjectFund")]
    public sealed class vwProjectFundRow : Row<vwProjectFundRow.RowFields>, IIdRow, INameRow
    {
        [DisplayName("Project Id"), IdProperty]
        public Int32? ProjectId
        {
            get => fields.ProjectId[this];
            set => fields.ProjectId[this] = value;
        }

        [DisplayName("Project Name"), Size(200), NotNull, QuickSearch, NameProperty]
        public String ProjectName
        {
            get => fields.ProjectName[this];
            set => fields.ProjectName[this] = value;
        }

        [DisplayName("Total Allocated Fund"), NotNull]
        public Double? TotalAllocatedFund
        {
            get => fields.TotalAllocatedFund[this];
            set => fields.TotalAllocatedFund[this] = value;
        }

        [DisplayName("Total Expense"), NotNull]
        public Double? TotalExpense
        {
            get => fields.TotalExpense[this];
            set => fields.TotalExpense[this] = value;
        }

        [DisplayName("Available Fund"), NotNull]
        public Double? AvailableFund
        {
            get => fields.AvailableFund[this];
            set => fields.AvailableFund[this] = value;
        }

        public vwProjectFundRow()
            : base()
        {
        }

        public vwProjectFundRow(RowFields fields)
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
