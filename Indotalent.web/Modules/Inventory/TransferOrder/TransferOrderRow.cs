using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using Serenity.Extensions.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using Indotalent.Web.Modules.Projects.Project;
using Indotalent.Web.Modules.Merchandise.Product;
using Indotalent.Web.Modules.Inventory.Warehouse;

namespace Indotalent.Inventory
{
    [ConnectionKey("Default"), Module("Inventory"), TableName("[dbo].[TransferOrder]")]
    [DisplayName("Transfer Orders"), InstanceName("Transfer Order")]
    [ReadPermission("Inventory:TransferOrder")]
    [ModifyPermission("Inventory:TransferOrder")]
    [LookupScript(LookupType = typeof(MultiTenantRowLookupScript<>))]
    public sealed class TransferOrderRow : LoggingRow<TransferOrderRow.RowFields>, IIdRow, INameRow, IMultiTenantRow
    {
        [DisplayName("Id"), Identity, IdProperty]
        public Int32? Id
        {
            get => fields.Id[this];
            set => fields.Id[this] = value;
        }

        [DisplayName("Number"), Size(200), NotNull, QuickSearch, NameProperty]
      
        [DefaultValue("auto")]
        public String Number
        {
            get => fields.Number[this];
            set => fields.Number[this] = value;
        }

        [DisplayName("Description"), Size(1000)]
        public String Description
        {
            get => fields.Description[this];
            set => fields.Description[this] = value;
        }

        [DisplayName("Transfer Date"), NotNull, QuickSearch]
        public DateTime? TransferDate
        {
            get => fields.TransferDate[this];
            set => fields.TransferDate[this] = value;
        }
        [DisplayName("From Project"), NotNull, ForeignKey("[dbo].[Project]", "Id"), LeftJoin("jFromProject"), TextualField("FromProjectName"), QuickSearch]
        [LookupEditor(typeof(ProjectLookup), InplaceAdd = true, DialogType = "Indotalent.Projects.ProjectDialog")]
        public Int32? ProjectFromId
        {
            get => fields.ProjectFromId[this];
            set => fields.ProjectFromId[this] = value;
        }

        [DisplayName("To Project"), NotNull, ForeignKey("[dbo].[Project]", "Id"), LeftJoin("jToProject"), TextualField("ToProjectName"), QuickSearch]
        [LookupEditor(typeof(ProjectLookup), InplaceAdd = true, DialogType = "Indotalent.Projects.ProjectDialog")]
        public Int32? ProjectToId
        {
            get => fields.ProjectToId[this];
            set => fields.ProjectToId[this] = value;
        }


        [DisplayName("From"), NotNull, ForeignKey("[dbo].[Warehouse]", "Id"), LeftJoin("jFrom"), TextualField("FromName"), QuickSearch]
        [LookupEditor(typeof(WarehouseLookup), InplaceAdd = true, DialogType = "Indotalent.Inventory.WarehouseDialog")]
        public Int32? FromId
        {
            get => fields.FromId[this];
            set => fields.FromId[this] = value;
        }

        [DisplayName("To"), NotNull, ForeignKey("[dbo].[Warehouse]", "Id"), LeftJoin("jTo"), TextualField("ToName"), QuickSearch]
        [LookupEditor(typeof(WarehouseLookup), InplaceAdd = true, DialogType = "Indotalent.Inventory.WarehouseDialog")]
        public Int32? ToId
        {
            get => fields.ToId[this];
            set => fields.ToId[this] = value;
        }

        [DisplayName("Total Qty"), NotNull, QuickSearch]
        [DefaultValue(0), Insertable(false), Updatable(false)]
        public Double? TotalQty
        {
            get => fields.TotalQty[this];
            set => fields.TotalQty[this] = value;
        }
        [DisplayName(" Project From"), Expression("jFromProject.[Name]"), QuickSearch]
        public String ProjectFromName
        {
            get => fields.ProjectFromName[this];
            set => fields.ProjectFromName[this] = value;
        }
        [DisplayName("Street"), Expression("jFromProject.[Street]")]
        public String ProjectFromStreet
        {
            get => fields.ProjectFromStreet[this];
            set => fields.ProjectFromStreet[this] = value;
        }
        [DisplayName("City"), Expression("jFromProject.[City]")]
        public String ProjectFromCity
        {
            get => fields.ProjectFromCity[this];
            set => fields.ProjectFromCity[this] = value;
        }
        [DisplayName("State"), Expression("jFromProject.[State]")]
        public String ProjectFromState
        {
            get => fields.ProjectFromState[this];
            set => fields.ProjectFromState[this] = value;
        }
        [DisplayName("Zip Code"), Expression("jFromProject.[ZipCode]")]
        public String ProjectFromZipCode
        {
            get => fields.ProjectFromZipCode[this];
            set => fields.ProjectFromZipCode[this] = value;
        }

        [DisplayName("Phone"), Expression("jFromProject.[Phone]")]
        public String ProjectFromPhone
        {
            get => fields.ProjectFromPhone[this];
            set => fields.ProjectFromPhone[this] = value;
        }

        [DisplayName("Email"), Expression("jFromProject.[Email]")]
        public String ProjectFromEmail
        {
            get => fields.ProjectFromEmail[this];
            set => fields.ProjectFromEmail[this] = value;
        }
        [DisplayName("Project To"), Expression("jToProject.[Name]"), QuickSearch]
        public String ProjectToName
        {
            get => fields.ProjectToName[this];
            set => fields.ProjectToName[this] = value;
        }

        [DisplayName("Street"), Expression("jToProject.[Street]")]
        public String ProjectToStreet
        {
            get => fields.ProjectToStreet[this];
            set => fields.ProjectToStreet[this] = value;
        }

        [DisplayName("City"), Expression("jToProject.[City]")]
        public String ProjectToCity
        {
            get => fields.ProjectToCity[this];
            set => fields.ProjectToCity[this] = value;
        }

        [DisplayName("State"), Expression("jToProject.[State]")]
        public String ProjectToState
        {
            get => fields.ProjectToState[this];
            set => fields.ProjectToState[this] = value;
        }

        [DisplayName("Zip Code"), Expression("jToProject.[ZipCode]")]
        public String ProjectToZipCode
        {
            get => fields.ProjectToZipCode[this];
            set => fields.ProjectToZipCode[this] = value;
        }

        [DisplayName("Phone"), Expression("jToProject.[Phone]")]
        public String ProjectToPhone
        {
            get => fields.ProjectToPhone[this];
            set => fields.ProjectToPhone[this] = value;
        }

        [DisplayName("Email"), Expression("jToProject.[Email]")]
        public String ProjectToEmail
        {
            get => fields.ProjectToEmail[this];
            set => fields.ProjectToEmail[this] = value;
        }

        [DisplayName("From"), Expression("jFrom.[Name]"), QuickSearch]
        public String FromName
        {
            get => fields.FromName[this];
            set => fields.FromName[this] = value;
        }

        [DisplayName("Street"), Expression("jFrom.[Street]")]
        public String FromStreet
        {
            get => fields.FromStreet[this];
            set => fields.FromStreet[this] = value;
        }

        [DisplayName("City"), Expression("jFrom.[City]")]
        public String FromCity
        {
            get => fields.FromCity[this];
            set => fields.FromCity[this] = value;
        }

        [DisplayName("State"), Expression("jFrom.[State]")]
        public String FromState
        {
            get => fields.FromState[this];
            set => fields.FromState[this] = value;
        }

        [DisplayName("Zip Code"), Expression("jFrom.[ZipCode]")]
        public String FromZipCode
        {
            get => fields.FromZipCode[this];
            set => fields.FromZipCode[this] = value;
        }

        [DisplayName("Phone"), Expression("jFrom.[Phone]")]
        public String FromPhone
        {
            get => fields.FromPhone[this];
            set => fields.FromPhone[this] = value;
        }

        [DisplayName("Email"), Expression("jFrom.[Email]")]
        public String FromEmail
        {
            get => fields.FromEmail[this];
            set => fields.FromEmail[this] = value;
        }

        [DisplayName("To"), Expression("jTo.[Name]"), QuickSearch]
        public String ToName
        {
            get => fields.ToName[this];
            set => fields.ToName[this] = value;
        }

        [DisplayName("Street"), Expression("jTo.[Street]")]
        public String ToStreet
        {
            get => fields.ToStreet[this];
            set => fields.ToStreet[this] = value;
        }

        [DisplayName("City"), Expression("jTo.[City]")]
        public String ToCity
        {
            get => fields.ToCity[this];
            set => fields.ToCity[this] = value;
        }

        [DisplayName("State"), Expression("jTo.[State]")]
        public String ToState
        {
            get => fields.ToState[this];
            set => fields.ToState[this] = value;
        }

        [DisplayName("Zip Code"), Expression("jTo.[ZipCode]")]
        public String ToZipCode
        {
            get => fields.ToZipCode[this];
            set => fields.ToZipCode[this] = value;
        }

        [DisplayName("Phone"), Expression("jTo.[Phone]")]
        public String ToPhone
        {
            get => fields.ToPhone[this];
            set => fields.ToPhone[this] = value;
        }

        [DisplayName("Email"), Expression("jTo.[Email]")]
        public String ToEmail
        {
            get => fields.ToEmail[this];
            set => fields.ToEmail[this] = value;
        }

        [DisplayName("Items"), MasterDetailRelation(foreignKey: "TransferOrderId"), NotMapped]
        public List<TransferOrderDetailRow> ItemList
        {
            get => fields.ItemList[this];
            set => fields.ItemList[this] = value;
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

        public TransferOrderRow()
            : base()
        {
        }

        public TransferOrderRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : LoggingRowFields
        {
            public Int32Field Id;
            public StringField Number;
            public StringField Description;
            public DateTimeField TransferDate;
            public Int32Field ProjectFromId;
            public Int32Field ProjectToId;

            public Int32Field FromId;
            public Int32Field ToId;
            public DoubleField TotalQty;
            public StringField ProjectFromName;
            public StringField ProjectFromStreet;
            public StringField ProjectFromCity;
            public StringField ProjectFromState;
            public StringField ProjectFromZipCode;
            public StringField ProjectFromPhone;
            public StringField ProjectFromEmail;
            public StringField ProjectToName;
            public StringField ProjectToStreet;
            public StringField ProjectToCity;
            public StringField ProjectToState;
            public StringField ProjectToZipCode;
            public StringField ProjectToPhone;
            public StringField ProjectToEmail;
            public StringField FromName;
            public StringField FromStreet;
            public StringField FromCity;
            public StringField FromState;
            public StringField FromZipCode;
            public StringField FromPhone;
            public StringField FromEmail;

            public StringField ToName;
            public StringField ToStreet;
            public StringField ToCity;
            public StringField ToState;
            public StringField ToZipCode;
            public StringField ToPhone;
            public StringField ToEmail;

            public RowListField<TransferOrderDetailRow> ItemList;

            public Int32Field TenantId;
            public StringField TenantName;
        }
    }
}
