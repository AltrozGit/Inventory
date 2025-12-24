using Indotalent.Administration.Lookups;
using Indotalent.Merchandise;
using Microsoft.Office.Interop.Excel;
using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using Serenity.Extensions.Entities;
using System;
using System.ComponentModel;
using System.IO;
using Indotalent.Web.Modules.Projects.Project;
namespace Indotalent.Projects
{

    [ConnectionKey("Default"), Module("Projects"), TableName("[dbo].[ProjectExpense]")]
    [DisplayName("Project Expense"), InstanceName("Project Expense")]
    [ReadPermission("Projects:ProjectExpense")]
    [ModifyPermission("Projects:ProjectExpense")]
    [LookupScript(LookupType = typeof(MultiTenantRowLookupScript<>))]
    public sealed class ProjectExpenseRow : LoggingRow<ProjectExpenseRow.RowFields>, IIdRow, IMultiTenantRow
    {
        [DisplayName("Id"), Identity, IdProperty]
        public Int32? Id
        {
            get => fields.Id[this];
            set => fields.Id[this] = value;
        }

        [DisplayName("Project"), NotNull, ForeignKey("[dbo].[Project]", "Id"), LeftJoin("jProject"), TextualField("ProjectName"), QuickSearch]
        [LookupEditor(typeof(ProjectLookup), InplaceAdd = true, DialogType = "Indotalent.Projects.ProjectDialog")]

        public Int32? ProjectId
        {
            get => fields.ProjectId[this];
            set => fields.ProjectId[this] = value;
        }

        [DisplayName("Expense"), NotNull, ForeignKey("[dbo].[Expense]", "Id"), LeftJoin("jExpense"), TextualField("ExpenseName"), QuickSearch]
        [LookupEditor(typeof(ExpenseRow), InplaceAdd = true)]

        public Int32? ExpenseId
        {
            get => fields.ExpenseId[this];
            set => fields.ExpenseId[this] = value;
        }




        [DisplayName("Project Name"), Expression("jProject.[Name]"), QuickSearch]
        public String ProjectName
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

        public String ExpenseName
        {
            get => fields.ExpenseName[this];
            set => fields.ExpenseName[this] = value;
        }
        // Add Notes In Projectexpense (Mayuri)
        [DisplayName("Notes"), Expression("jExpense.[Name]"), QuickSearch]

        public String Notes
        {
            get => fields.Notes[this];
            set => fields.Notes[this] = value;
        }

        [DisplayName("Cost"), NotNull, QuickSearch]
        [DefaultValue(0)]
        public Double? Cost
        {
            get => fields.Cost[this];
            set => fields.Cost[this] = value;
        }

       
        [DisplayName("Tenant"), ForeignKey("Tenant", "TenantId"), LeftJoin("jTenant")]
        [Insertable(false), Updatable(false)]
        public Int32? TenantId
        {
            get { return Fields.TenantId[this]; }
            set { Fields.TenantId[this] = value; }
        }
        [DisplayName("Tenant"), Expression("jTenant.TenantName")]
        public String TenantName
        {
            get { return Fields.TenantName[this]; }
            set { Fields.TenantName[this] = value; }
        }
        public Int32Field TenantIdField
        {
            get { return Fields.TenantId; }
        }

        public ProjectExpenseRow()
            : base()
        {
        }

        public ProjectExpenseRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : LoggingRowFields
        {
            public Int32Field Id;
            public Int32Field ProjectId;
            public Int32Field ExpenseId;

            public Int32Field TenantId;

            public StringField ProjectName;


            public StringField ExpenseName;
            public StringField Notes;
            public DoubleField Cost;
          //  public DoubleField TotalAllocatedFund;

            public StringField TenantName;

            public DateTimeField ExpenseDate;
        }
    }
}
