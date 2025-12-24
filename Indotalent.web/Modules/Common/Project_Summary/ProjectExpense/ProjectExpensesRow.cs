using Indotalent.Projects;
using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;
using System.IO;

namespace Indotalent.Web.Modules.Common.Project_Summary.ProjectExpense
{

    [ConnectionKey("Default"), TableName("[dbo].[ProjectExpense]")]
    [DisplayName("Other Expense Details"), InstanceName("Project Expense")]

    [ReadPermission("*")]
    [ModifyPermission("*")]
    public sealed class ProjectExpensesRow : Row<ProjectExpensesRow.RowFields>, IIdRow
    {
        [DisplayName("Id"), Identity, IdProperty]
        public int? Id
        {
            get => fields.Id[this];
            set => fields.Id[this] = value;
        }

        [DisplayName("Project"), NotNull, ForeignKey("[dbo].[Project]", "Id"), LeftJoin("jProject"), TextualField("ProjectName"), QuickSearch]
        [LookupEditor(typeof(ProjectRow), InplaceAdd = true)]

        public int? ProjectId
        {
            get => fields.ProjectId[this];
            set => fields.ProjectId[this] = value;
        }

        [DisplayName("Expense"), NotNull, ForeignKey("[dbo].[Expense]", "Id"), LeftJoin("jExpense"), TextualField("ExpenseName"), QuickSearch]
        [LookupEditor(typeof(ExpenseRow), InplaceAdd = true)]

        public int? ExpenseId
        {
            get => fields.ExpenseId[this];
            set => fields.ExpenseId[this] = value;
        }




        [DisplayName("Project Name"), Expression("jProject.[Name]"), QuickSearch]
        public string ProjectName
        {
            get => fields.ProjectName[this];
            set => fields.ProjectName[this] = value;
        }

        [DisplayName("Expense Date"), NotNull, QuickSearch]
        public DateTime? ExpenseDate
        {
            get => fields.ExpenseDate[this];
            set => fields.ExpenseDate[this] = value;
        }
        [DisplayName("Expense Name"), Expression("jExpense.[Name]"), QuickSearch]
        public string ExpenseName
        {
            get => fields.ExpenseName[this];
            set => fields.ExpenseName[this] = value;
        }

        [DisplayName("Cost"), NotNull, QuickSearch]
        [DefaultValue(0)]
        public double? Cost
        {
            get => fields.Cost[this];
            set => fields.Cost[this] = value;
        }
        [DisplayName("Tenant"), ForeignKey("Tenant", "TenantId"), LeftJoin("jTenant")]
        [Insertable(false), Updatable(false)]
        public int? TenantId
        {
            get { return Fields.TenantId[this]; }
            set { Fields.TenantId[this] = value; }
        }
        [DisplayName("Tenant"), Expression("jTenant.TenantName")]
        public string TenantName
        {
            get { return Fields.TenantName[this]; }
            set { Fields.TenantName[this] = value; }
        }
        public Int32Field TenantIdField
        {
            get { return Fields.TenantId; }
        }

        public ProjectExpensesRow()
            : base()
        {
        }

        public ProjectExpensesRow(RowFields fields)
            : base(fields)
        {
        }


        public class RowFields : RowFieldsBase
        {
            public Int32Field Id;
            public Int32Field ProjectId;
            public StringField ProjectName;

            public Int32Field ExpenseId;

            public Int32Field TenantId;



            public StringField ExpenseName;
            public DoubleField Cost;

            public StringField TenantName;

            public DateTimeField ExpenseDate;
        }
    }
}
