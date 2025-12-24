using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using Serenity.Extensions.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using Indotalent.Web.Modules.Merchandise.Product;
using Indotalent.Merchandise;

namespace Indotalent.Projects
{
    [ConnectionKey("Default"), Module("Projects"), TableName("[dbo].[ProjectMaterialRequestDetail]")]
    [DisplayName("Project Material Request Detail"), InstanceName("Project Material Request Detail")]
    [ReadPermission("Projects:ProjectMaterialRequestDetail")]
    [ModifyPermission("Projects:ProjectMaterialRequestDetail")]
    [LookupScript(LookupType = typeof(MultiTenantRowLookupScript<>))]

    //[LeftJoin("jvwAvailableStock", "[dbo].[vwAvailableStock]", "[T0].[ProductId] = jvwAvailableStock.[ProductId] " +
    //    "AND jProjectMaterialRequest.[ProjectId] = jvwAvailableStock.[ProjectID] ")]
    public sealed class ProjectMaterialRequestDetailRow : LoggingRow<ProjectMaterialRequestDetailRow.RowFields>, IIdRow, IMultiTenantRow
    {
        [DisplayName("Id"), Identity, IdProperty]
        public Int32? Id
        {
            get => fields.Id[this];
            set => fields.Id[this] = value;
        }

        [DisplayName("Project Request"), NotNull, ForeignKey("[dbo].[ProjectMaterialRequest]", "Id"), LeftJoin("jProjectMaterialRequest"), TextualField("ProjectMaterialRequestNumber")]
        public Int32? ProjectMaterialRequestId
        {
            get => fields.ProjectMaterialRequestId[this];
            set => fields.ProjectMaterialRequestId[this] = value;
        }

        [DisplayName("Product"), NotNull, ForeignKey("[dbo].[Product]", "Id"), LeftJoin("jProduct"), TextualField("ProductName")]
        [LookupEditor(typeof(ProductLookup), InplaceAdd = true, DialogType = "Indotalent.Merchandise.ProductDialog")]


        public Int32? ProductId
        {
            get => fields.ProductId[this];
            set => fields.ProductId[this] = value;
        }
        [DisplayName("Product"), Expression("jProduct.[Name]"), MinSelectLevel(SelectLevel.List)]

        public String ProductName
        {
            get => fields.ProductName[this];
            set => fields.ProductName[this] = value;
        }

		/*[DisplayName("Is Selected"), NotMapped]
		public Boolean? IsSelected
		{
			get => fields.IsSelected[this];
			set => fields.IsSelected[this] = value;
		}*/

		[DisplayName("Purchase Tax"), Expression("jProduct.[PurchaseTaxId]"), ForeignKey("[dbo].[PurchaseTax]", "Id"), LeftJoin("jPurchaseTax")]

        public Int32? PurchaseTaxId
        {
            get => fields.PurchaseTaxId[this];
            set => fields.PurchaseTaxId[this] = value;
        }
        //[DisplayName("Price"), Expression("jProduct.[PurchasePrice]"), MinSelectLevel(SelectLevel.List)]

        //public Double? PurchasePrice
        //{
        //    get => fields.PurchasePrice[this];
        //    set => fields.PurchasePrice[this] = value;
        //}
       
        [DisplayName("Tax Percentage"), NotNull, Expression("jPurchaseTax.[TaxRatePercentage]"), MinSelectLevel(SelectLevel.List)]
        [DefaultValue(0)]
        public Double? TaxRatePercentage
        {
            get => fields.TaxRatePercentage[this];
            set => fields.TaxRatePercentage[this] = value;
        }

        [DisplayName("IGST"), NotNull, Expression("jPurchaseTax.[IGST]"), MinSelectLevel(SelectLevel.List)]
        [DefaultValue(0)]
        public Double? IGST
        {
            get => fields.IGST[this];
            set => fields.IGST[this] = value;
        }
        [DisplayName("SGST"), NotNull, Expression("jPurchaseTax.[SGST]"), MinSelectLevel(SelectLevel.List)]
        [DefaultValue(0)]
        public Double? SGST
        {
            get => fields.SGST[this];
            set => fields.SGST[this] = value;
        }

        [DisplayName("CGST"), NotNull, Expression("jPurchaseTax.[CGST]"), MinSelectLevel(SelectLevel.List)]
        [DefaultValue(0)]
        public Double? CGST
        {
            get => fields.CGST[this];
            set => fields.CGST[this] = value;
        }


        [DisplayName("Quantity"), NotNull]
        [DefaultValue(0)]

        public Double? QtyRequest
        {
            get => fields.QtyRequest[this];
            set => fields.QtyRequest[this] = value;
        }


        [DisplayName("Pending Material RequestQty")]
        [DefaultValue(0)]

        public Double? PendingMaterialRequestQty
        {
            get => fields.PendingMaterialRequestQty[this];
            set => fields.PendingMaterialRequestQty[this] = value;
        }

        [DisplayName("Purchase Price"), NotNull]
        [DefaultValue(0)]

        public Double? PurchasePrice
        {
            get => fields.PurchasePrice[this];
            set => fields.PurchasePrice[this] = value;
        }
        [DisplayName("Sub Total")]
        [DefaultValue(0)]
        public Double? SubTotal
        {
            get => fields.SubTotal[this];
            set => fields.SubTotal[this] = value;
        }
        [DisplayName("Uom"), NotNull, ForeignKey("[dbo].[Uom]", "Id"), Expression("jProduct.[UomId]"), LeftJoin("jUom"), TextualField("UomName"), MinSelectLevel(SelectLevel.List), QuickSearch, Updatable(false), Insertable(false)]
        [LookupEditor(typeof(UomRow), InplaceAdd = true)]
        public Int32? UomId
        {
            get => fields.UomId[this];
            set => fields.UomId[this] = value;
        }
        [DisplayName("Uom"), Expression("jUom.[Name]"), QuickSearch, MinSelectLevel(SelectLevel.List)]
        public String UomName
        {
            get => fields.UomName[this];
            set => fields.UomName[this] = value;
        }

        //[DisplayName("SAC"), NotNull, ForeignKey("[dbo].[SAC]", "Id"), Expression("jProduct.[SacId]"), LeftJoin("jSAC"), TextualField("SacName"), MinSelectLevel(SelectLevel.List), QuickSearch, Updatable(false), Insertable(false)]
        //[LookupEditor(typeof(SACRow), InplaceAdd = true)]
        //public Int32? SacId
        //{
        //    get => fields.SacId[this];
        //    set => fields.SacId[this] = value;
        //}
        //[DisplayName("SAC"), Expression("jSAC.[SacName]"), QuickSearch, MinSelectLevel(SelectLevel.List)]
        //public String SacName1
        //{
        //    get => fields.SacName1[this];
        //    set => fields.SacName1[this] = value;
        //}

        [DisplayName("Project Request"), Expression("jProjectMaterialRequest.[Number]")]
        public String ProjectMaterialRequestNumber
        {
            get => fields.ProjectMaterialRequestNumber[this];
            set => fields.ProjectMaterialRequestNumber[this] = value;
        }

        [DisplayName("Request Id"), NotMapped]
        public Int32? RequestId
        {
            get => fields.Id[this];
            set => fields.Id[this] = value;
        }
        [DisplayName("Item Id"), NotMapped]
        public Int32? ItemId
        {
            get => fields.Id[this];
            set => fields.Id[this] = value;
        }

        [DisplayName("Is Active")]
        public Boolean? IsActive
        {
            get => fields.IsActive[this];
            set => fields.IsActive[this] = value;
        }


        [DisplayName("IsCompleteMRCreated")]
        public Boolean? IsCompleteMRCreated
        {
            get => fields.IsCompleteMRCreated[this];
            set => fields.IsCompleteMRCreated[this] = value;
        }



        [DisplayName("Tenant"), ForeignKey("Tenant", "TenantId"), LeftJoin("jTenant")]
        [Insertable(false), Updatable(false)]

        public Int32? TenantId
        {
            get { return Fields.TenantId[this]; }
            set { Fields.TenantId[this] = value; }
        }

        [DisplayName("Tenant"), Expression("jTenant.TenantName"), MinSelectLevel(SelectLevel.List)]
        public String TenantName
        {
            get { return Fields.TenantName[this]; }
            set { Fields.TenantName[this] = value; }
        }
       
        public Int32Field TenantIdField
        {
            get { return Fields.TenantId; }
        }

        public int TotalQtyRequest { get; internal set; }
        public bool IsPOGenerated { get; internal set; }



        public ProjectMaterialRequestDetailRow()
            : base()
        {
        }

        public ProjectMaterialRequestDetailRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : LoggingRowFields
        {
            public Int32Field Id;
            public Int32Field ProjectMaterialRequestId;
            public Int32Field ProductId;
            public Int32Field RequestId;
            public Int32Field ItemId;
            public BooleanField IsActive;
            public BooleanField IsCompleteMRCreated;
            public DoubleField QtyRequest;
            public DoubleField PendingMaterialRequestQty;
            public DoubleField SubTotal;

            public Int32Field TenantId;
            public StringField TenantName;

            public StringField ProjectMaterialRequestNumber;
            public StringField ProductName;
            public Int32Field PurchaseTaxId;
            public DoubleField PurchasePrice;
           
            public DoubleField TaxRatePercentage;
            public DoubleField SGST;
            public DoubleField CGST;
            public DoubleField IGST;
            public Int32Field UomId;
            public StringField UomName;
            //public Int32Field SacId;
            //public StringField SacName1;



        }
    }
}
