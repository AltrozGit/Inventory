using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20211010130000)]
    public class DefaultDB_20211010_130000_Indotalent : AutoReversingMigration
    {
        public override void Up()
        {
            /*
             *  
             *  Sales Order
             *  |_ SalesChannel
             *  |_ Customer
             *      |_ CustomerContact
             *  |_ SalesOrder
             *      |_ SalesOrderDetail
             *      |_ Invoice
             *          |_ InvoiceDetail
             *          |_ InvoicePayment
             *  
             *  Purchase Order
             *  |_ Vendor
             *      |_ VendorContact
             *  |_ PurchaseOrder
             *      |_ PurchaseOrderDetail
             *      |_ Bill
             *          |_ BillDetail
             *          |_ BillPayment
             *  
             *  Merchandise
             *  |_ Uom
             *  |_ Size
             *  |_ Colour
             *  |_ Flavour
             *  |_ Brand
             *  |_ Category
             *  |_ Product
             *  
             *  
             *  
             *  
             *  Inventory
             *  |_ Shipper
             *  |_ Location
             *  |_ Warehouse
             *  |_ SalesDelivery
             *    |_ SalesDeliveryDetail
             *    |_ SalesReturn
             *           |_ SalesReturnDetail
             *  |_ PurchaseReceipt
             *     |_ PurchaseReceiptDetail
             *     |_ PurchaseReturn
             *         |_ PurchaseReturnDetail
             *  |_ PositiveAdjustment
             *      |_ PositiveAdjustmentDetail
             *  |_ NegativeAjustment
             *      |_ NegativeAdjustmentDetail
             *  |_ TransferOrder
             *      |_ TransferOrderDetail
             *  
             *  
             *  Settings
             *  |_ Company
             *  |_ CashBank
             *  |_ PurchaseTax
             *  |_ SalesTax
             *  
             */            

            Create.UniqueConstraint("StateUniqueConstraint").OnTable("State").Columns("CountryId", "Name");

            Create.Table("Project")
			 .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
			 .WithColumn("Name").AsString(200).NotNullable()
			 .WithColumn("Description").AsString(1000).Nullable()
			 .WithColumn("Street").AsString(200).Nullable()
			 .WithColumn("City").AsString(200).Nullable()
			 .WithColumn("State").AsString(200).Nullable()
			 .WithColumn("ZipCode").AsString(10).Nullable()
			 .WithColumn("Phone").AsString(50).Nullable()
			 .WithColumn("Email").AsString(200).Nullable()		  
			 .WithColumn("InsertDate").AsDateTime().Nullable()
			 .WithColumn("InsertUserId").AsInt32().Nullable()
			 .WithColumn("UpdateDate").AsDateTime().Nullable()
			 .WithColumn("UpdateUserId").AsInt32().Nullable()
			 .WithColumn("TenantId").AsInt32().NotNullable();

			Create.UniqueConstraint("ProjectUniqueConstraint").OnTable("Project").Columns("Name", "TenantId");

			Create.Table("CashBank")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
                .WithColumn("Name").AsString(200).NotNullable()
                .WithColumn("Description").AsString(1000).Nullable()
                .WithColumn("AccountNumber").AsString(100).Nullable()
                .WithColumn("Street").AsString(200).Nullable()
                .WithColumn("City").AsString(200).Nullable()
                .WithColumn("State").AsString(200).Nullable()
                .WithColumn("ZipCode").AsString(10).Nullable()
                .WithColumn("Phone").AsString(50).Nullable()
                .WithColumn("Email").AsString(200).Nullable()
                .WithColumn("InsertDate").AsDateTime().Nullable()
                .WithColumn("InsertUserId").AsInt32().Nullable()
                .WithColumn("UpdateDate").AsDateTime().Nullable()
                .WithColumn("UpdateUserId").AsInt32().Nullable()
                .WithColumn("TenantId").AsInt32().NotNullable();

            Create.UniqueConstraint("CashBankUniqueConstraint").OnTable("CashBank").Columns("Name", "TenantId");

            Create.Table("SalesTax")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
                .WithColumn("Name").AsString(10).NotNullable()
                .WithColumn("Description").AsString(1000).Nullable()
                .WithColumn("TaxRatePercentage").AsDouble().NotNullable().WithDefaultValue(0)
                .WithColumn("InsertDate").AsDateTime().Nullable()
                .WithColumn("InsertUserId").AsInt32().Nullable()
                .WithColumn("UpdateDate").AsDateTime().Nullable()
                .WithColumn("UpdateUserId").AsInt32().Nullable()
                .WithColumn("TenantId").AsInt32().NotNullable(); 
            
            Create.UniqueConstraint("SalesTaxUniqueConstraint").OnTable("SalesTax").Columns("Name", "TenantId");

            Create.Table("PurchaseTax")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
                .WithColumn("Name").AsString(10).NotNullable()
                .WithColumn("Description").AsString(1000).Nullable()
                .WithColumn("TaxRatePercentage").AsDouble().NotNullable().WithDefaultValue(0)
                .WithColumn("InsertDate").AsDateTime().Nullable()
                .WithColumn("InsertUserId").AsInt32().Nullable()
                .WithColumn("UpdateDate").AsDateTime().Nullable()
                .WithColumn("UpdateUserId").AsInt32().Nullable()
                .WithColumn("TenantId").AsInt32().NotNullable();

            Create.UniqueConstraint("PurchaseTaxUniqueConstraint").OnTable("PurchaseTax").Columns("Name", "TenantId");

            Create.Table("Uom")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
                .WithColumn("Name").AsString(200).NotNullable()
                .WithColumn("Description").AsString(1000).Nullable()
                .WithColumn("InsertDate").AsDateTime().Nullable()
                .WithColumn("InsertUserId").AsInt32().Nullable()
                .WithColumn("UpdateDate").AsDateTime().Nullable()
                .WithColumn("UpdateUserId").AsInt32().Nullable()
                .WithColumn("TenantId").AsInt32().NotNullable();

            Create.UniqueConstraint("UomUniqueConstraint").OnTable("Uom").Columns("Name", "TenantId");

            Create.Table("Size")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
                .WithColumn("Name").AsString(200).NotNullable()
                .WithColumn("Description").AsString(1000).Nullable()
                .WithColumn("InsertDate").AsDateTime().Nullable()
                .WithColumn("InsertUserId").AsInt32().Nullable()
                .WithColumn("UpdateDate").AsDateTime().Nullable()
                .WithColumn("UpdateUserId").AsInt32().Nullable()
                .WithColumn("TenantId").AsInt32().NotNullable();

            Create.UniqueConstraint("SizeUniqueConstraint").OnTable("Size").Columns("Name", "TenantId");

            Create.Table("Colour")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
                .WithColumn("Name").AsString(200).NotNullable()
                .WithColumn("Description").AsString(1000).Nullable()
                .WithColumn("InsertDate").AsDateTime().Nullable()
                .WithColumn("InsertUserId").AsInt32().Nullable()
                .WithColumn("UpdateDate").AsDateTime().Nullable()
                .WithColumn("UpdateUserId").AsInt32().Nullable()
                .WithColumn("TenantId").AsInt32().NotNullable();

            Create.UniqueConstraint("ColourUniqueConstraint").OnTable("Colour").Columns("Name", "TenantId");

            Create.Table("Flavour")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
                .WithColumn("Name").AsString(200).NotNullable()
                .WithColumn("Description").AsString(1000).Nullable()
                .WithColumn("InsertDate").AsDateTime().Nullable()
                .WithColumn("InsertUserId").AsInt32().Nullable()
                .WithColumn("UpdateDate").AsDateTime().Nullable()
                .WithColumn("UpdateUserId").AsInt32().Nullable()
                .WithColumn("TenantId").AsInt32().NotNullable();

            Create.UniqueConstraint("FlavourUniqueConstraint").OnTable("Flavour").Columns("Name", "TenantId");

            Create.Table("Brand")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
                .WithColumn("Name").AsString(200).NotNullable()
                .WithColumn("Description").AsString(1000).Nullable()
                .WithColumn("InsertDate").AsDateTime().Nullable()
                .WithColumn("InsertUserId").AsInt32().Nullable()
                .WithColumn("UpdateDate").AsDateTime().Nullable()
                .WithColumn("UpdateUserId").AsInt32().Nullable()
                .WithColumn("TenantId").AsInt32().NotNullable();

            Create.UniqueConstraint("BrandUniqueConstraint").OnTable("Brand").Columns("Name", "TenantId");

            Create.Table("Category")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
                .WithColumn("Name").AsString(200).NotNullable()
                .WithColumn("Description").AsString(1000).Nullable()
                .WithColumn("InsertDate").AsDateTime().Nullable()
                .WithColumn("InsertUserId").AsInt32().Nullable()
                .WithColumn("UpdateDate").AsDateTime().Nullable()
                .WithColumn("UpdateUserId").AsInt32().Nullable()
                .WithColumn("TenantId").AsInt32().NotNullable();

            Create.UniqueConstraint("CategoryUniqueConstraint").OnTable("Category").Columns("Name", "TenantId");

            Create.Table("Product")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
                .WithColumn("Name").AsString(200).NotNullable()
                .WithColumn("Description").AsString(1000).Nullable()
                .WithColumn("Picture").AsString(200).Nullable()
                .WithColumn("InternalCode").AsString(100).Nullable()
                .WithColumn("Barcode").AsString(100).Nullable()
                .WithColumn("UomId").AsInt32().NotNullable()
                    .ForeignKey("FK_Product_UomId", "Uom", "Id")
                .WithColumn("BrandId").AsInt32().NotNullable()
                    .ForeignKey("FK_Product_BrandId", "Brand", "Id")
                .WithColumn("CategoryId").AsInt32().NotNullable()
                    .ForeignKey("FK_Product_CategoryId", "Category", "Id")
                .WithColumn("SizeId").AsInt32().Nullable()
                    .ForeignKey("FK_Product_SizeId", "Size", "Id")
                .WithColumn("ColourId").AsInt32().Nullable()
                    .ForeignKey("FK_Product_ColourId", "Colour", "Id")
                .WithColumn("FlavourId").AsInt32().Nullable()
                    .ForeignKey("FK_Product_FlavourId", "Flavour", "Id")
                .WithColumn("PurchasePrice").AsDouble().NotNullable()
                .WithColumn("SalesPrice").AsDouble().NotNullable()
                .WithColumn("PurchaseTaxId").AsInt32().NotNullable()
                    .ForeignKey("FK_Product_PurchaseTaxId", "PurchaseTax", "Id")
                .WithColumn("SalesTaxId").AsInt32().NotNullable()
                    .ForeignKey("FK_Product_SalesTaxId", "SalesTax", "Id")
                .WithColumn("MinimumQty").AsDouble().NotNullable().WithDefaultValue(0)
                .WithColumn("InsertDate").AsDateTime().Nullable()
                .WithColumn("InsertUserId").AsInt32().Nullable()
                .WithColumn("UpdateDate").AsDateTime().Nullable()
                .WithColumn("UpdateUserId").AsInt32().Nullable()
                .WithColumn("TenantId").AsInt32().NotNullable();

            Create.UniqueConstraint("ProductNameUniqueConstraint").OnTable("Product").Columns("Name", "TenantId");

            Create.Table("Vendor")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
                .WithColumn("Name").AsString(200).NotNullable()
                .WithColumn("Description").AsString(1000).Nullable()
                .WithColumn("Street").AsString(200).Nullable()
                .WithColumn("City").AsString(200).Nullable()                
                .WithColumn("ZipCode").AsString(10).Nullable()
                .WithColumn("Phone").AsString(50).Nullable()
                .WithColumn("Email").AsString(200).Nullable()
                .WithColumn("InsertDate").AsDateTime().Nullable()
                .WithColumn("InsertUserId").AsInt32().Nullable()
                .WithColumn("UpdateDate").AsDateTime().Nullable()
                .WithColumn("UpdateUserId").AsInt32().Nullable()
                .WithColumn("TenantId").AsInt32().NotNullable();

            Create.UniqueConstraint("VendorUniqueConstraint").OnTable("Vendor").Columns("Name", "TenantId");

            Create.Table("VendorContact")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
                .WithColumn("VendorId").AsInt32().NotNullable()
                    .ForeignKey("FK_VendorContact_VendorId", "Vendor", "Id")
                .WithColumn("Name").AsString(200).NotNullable()
                .WithColumn("Description").AsString(1000).Nullable()
                .WithColumn("Street").AsString(200).Nullable()
                .WithColumn("City").AsString(200).Nullable()
                .WithColumn("State").AsString(200).Nullable()
                .WithColumn("ZipCode").AsString(10).Nullable()
                .WithColumn("Phone").AsString(50).Nullable()
                .WithColumn("Email").AsString(200).Nullable()
                .WithColumn("InsertDate").AsDateTime().Nullable()
                .WithColumn("InsertUserId").AsInt32().Nullable()
                .WithColumn("UpdateDate").AsDateTime().Nullable()
                .WithColumn("UpdateUserId").AsInt32().Nullable()
                .WithColumn("TenantId").AsInt32().NotNullable();

            Create.Table("PurchaseOrder")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
                .WithColumn("Number").AsString(200).NotNullable()
                .WithColumn("Description").AsString(1000).Nullable()
                .WithColumn("ProcurementGroup").AsString(200).Nullable()
                .WithColumn("OrderDate").AsDateTime().NotNullable()
                .WithColumn("VendorId").AsInt32().NotNullable()
                    .ForeignKey("FK_PurchaseOrder_VendorId", "Vendor", "Id")
                .WithColumn("SubTotal").AsDouble().NotNullable()
                .WithColumn("Discount").AsDouble().NotNullable()
                .WithColumn("BeforeTax").AsDouble().NotNullable()
                .WithColumn("TaxAmount").AsDouble().NotNullable()
                .WithColumn("Total").AsDouble().NotNullable()
                .WithColumn("OtherCharge").AsDouble().NotNullable().WithDefaultValue(0)
                .WithColumn("InsertDate").AsDateTime().Nullable()
                .WithColumn("InsertUserId").AsInt32().Nullable()
                .WithColumn("UpdateDate").AsDateTime().Nullable()
                .WithColumn("UpdateUserId").AsInt32().Nullable()
                .WithColumn("TenantId").AsInt32().NotNullable();

            Create.UniqueConstraint("PurchaseOrderUniqueConstraint").OnTable("PurchaseOrder").Columns("Number", "TenantId");

            Create.Table("PurchaseOrderDetail")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
                .WithColumn("PurchaseOrderId").AsInt32().NotNullable()
                    .ForeignKey("FK_PurchaseOrderDetail_PurchaseOrderId", "PurchaseOrder", "Id")
                .WithColumn("ProductId").AsInt32().NotNullable()
                    .ForeignKey("FK_PurchaseOrderDetail_ProductId", "Product", "Id")
                .WithColumn("Price").AsDouble().NotNullable()
                .WithColumn("Qty").AsDouble().NotNullable()
                .WithColumn("SubTotal").AsDouble().NotNullable()
                .WithColumn("Discount").AsDouble().NotNullable()
                .WithColumn("BeforeTax").AsDouble().NotNullable()
                .WithColumn("TaxPercentage").AsDouble().NotNullable()
                .WithColumn("TaxAmount").AsDouble().NotNullable()
                .WithColumn("Total").AsDouble().NotNullable()
                .WithColumn("InsertDate").AsDateTime().Nullable()
                .WithColumn("InsertUserId").AsInt32().Nullable()
                .WithColumn("UpdateDate").AsDateTime().Nullable()
                .WithColumn("UpdateUserId").AsInt32().Nullable()
                .WithColumn("TenantId").AsInt32().NotNullable();

            Create.Table("Bill")
               .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
               .WithColumn("Number").AsString(200).NotNullable()
               .WithColumn("Description").AsString(1000).Nullable()
               .WithColumn("ExternalReferenceNumber").AsString(200).Nullable()
               .WithColumn("ProcurementGroup").AsString(200).Nullable()
               .WithColumn("BillDate").AsDateTime().NotNullable()
               .WithColumn("PurchaseOrderId").AsInt32().NotNullable()
                   .ForeignKey("FK_Bill_PurchaseOrderId", "PurchaseOrder", "Id")
               .WithColumn("SubTotal").AsDouble().NotNullable()
               .WithColumn("Discount").AsDouble().NotNullable()
               .WithColumn("BeforeTax").AsDouble().NotNullable()
               .WithColumn("TaxAmount").AsDouble().NotNullable()
               .WithColumn("Total").AsDouble().NotNullable()
               .WithColumn("OtherCharge").AsDouble().NotNullable().WithDefaultValue(0)
                .WithColumn("InsertDate").AsDateTime().Nullable()
                .WithColumn("InsertUserId").AsInt32().Nullable()
                .WithColumn("UpdateDate").AsDateTime().Nullable()
                .WithColumn("UpdateUserId").AsInt32().Nullable()
                .WithColumn("TenantId").AsInt32().NotNullable();

            Create.UniqueConstraint("BillUniqueConstraint").OnTable("Bill").Columns("Number", "TenantId");

            Create.Table("BillDetail")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
                .WithColumn("BillId").AsInt32().NotNullable()
                    .ForeignKey("FK_BillDetail_BillId", "Bill", "Id")
                .WithColumn("ProductId").AsInt32().NotNullable()
                    .ForeignKey("FK_BillDetail_ProductId", "Product", "Id")
                .WithColumn("Price").AsDouble().NotNullable()
                .WithColumn("Qty").AsDouble().NotNullable()
                .WithColumn("SubTotal").AsDouble().NotNullable()
                .WithColumn("Discount").AsDouble().NotNullable()
                .WithColumn("BeforeTax").AsDouble().NotNullable()
                .WithColumn("TaxPercentage").AsDouble().NotNullable()
                .WithColumn("TaxAmount").AsDouble().NotNullable()
                .WithColumn("Total").AsDouble().NotNullable()
                .WithColumn("InsertDate").AsDateTime().Nullable()
                .WithColumn("InsertUserId").AsInt32().Nullable()
                .WithColumn("UpdateDate").AsDateTime().Nullable()
                .WithColumn("UpdateUserId").AsInt32().Nullable()
                .WithColumn("TenantId").AsInt32().NotNullable();

            Create.Table("BillPayment")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
                .WithColumn("BillId").AsInt32().NotNullable()
                    .ForeignKey("FK_BillPayment_BillId", "Bill", "Id")
                .WithColumn("Number").AsString(200).NotNullable()
                .WithColumn("Description").AsString(1000).Nullable()
                .WithColumn("ProcurementGroup").AsString(200).Nullable()
                .WithColumn("PaymentDate").AsDateTime().NotNullable()
                .WithColumn("CashBankId").AsInt32().NotNullable()
                    .ForeignKey("FK_BillPayment_CashBankId", "CashBank", "Id")
                .WithColumn("BillAmount").AsDouble().NotNullable()
                .WithColumn("PaymentAmount").AsDouble().NotNullable()
                .WithColumn("InsertDate").AsDateTime().Nullable()
                .WithColumn("InsertUserId").AsInt32().Nullable()
                .WithColumn("UpdateDate").AsDateTime().Nullable()
                .WithColumn("UpdateUserId").AsInt32().Nullable()
                .WithColumn("TenantId").AsInt32().NotNullable();

            Create.UniqueConstraint("BillPaymentUniqueConstraint").OnTable("BillPayment").Columns("Number", "TenantId");

            Create.Table("SalesChannel")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
                .WithColumn("Name").AsString(200).NotNullable()
                .WithColumn("Description").AsString(1000).Nullable()
                .WithColumn("InsertDate").AsDateTime().Nullable()
                .WithColumn("InsertUserId").AsInt32().Nullable()
                .WithColumn("UpdateDate").AsDateTime().Nullable()
                .WithColumn("UpdateUserId").AsInt32().Nullable()
                .WithColumn("TenantId").AsInt32().NotNullable();

            Create.UniqueConstraint("SalesChannelUniqueConstraint").OnTable("SalesChannel").Columns("Name", "TenantId");


            Create.Table("Customer")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
                .WithColumn("Name").AsString(200).NotNullable()
                .WithColumn("Description").AsString(1000).Nullable()
                .WithColumn("Street").AsString(200).Nullable()
                .WithColumn("City").AsString(200).Nullable()
                //.WithColumn("State").AsString(200).Nullable()
                .WithColumn("ZipCode").AsString(10).Nullable()
                .WithColumn("Phone").AsString(50).Nullable()
                .WithColumn("Email").AsString(200).Nullable()
                .WithColumn("InsertDate").AsDateTime().Nullable()
                .WithColumn("InsertUserId").AsInt32().Nullable()
                .WithColumn("UpdateDate").AsDateTime().Nullable()
                .WithColumn("UpdateUserId").AsInt32().Nullable()
                .WithColumn("TenantId").AsInt32().NotNullable();

            Create.UniqueConstraint("CustomerUniqueConstraint").OnTable("Customer").Columns("Name", "TenantId");

            Create.Table("CustomerContact")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
                .WithColumn("CustomerId").AsInt32().NotNullable()
                    .ForeignKey("FK_CustomerContact_CustomerId", "Customer", "Id")
                .WithColumn("Name").AsString(200).NotNullable()
                .WithColumn("Description").AsString(1000).Nullable()
                .WithColumn("Street").AsString(200).Nullable()
                .WithColumn("City").AsString(200).Nullable()
                .WithColumn("State").AsString(200).Nullable()
                .WithColumn("ZipCode").AsString(10).Nullable()
                .WithColumn("Phone").AsString(50).Nullable()
                .WithColumn("Email").AsString(200).Nullable()
                .WithColumn("InsertDate").AsDateTime().Nullable()
                .WithColumn("InsertUserId").AsInt32().Nullable()
                .WithColumn("UpdateDate").AsDateTime().Nullable()
                .WithColumn("UpdateUserId").AsInt32().Nullable()
                .WithColumn("TenantId").AsInt32().NotNullable();

            Create.Table("SalesOrder")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
                .WithColumn("Number").AsString(200).NotNullable()
                .WithColumn("Description").AsString(1000).Nullable()
                .WithColumn("SalesGroup").AsString(200).Nullable()
                .WithColumn("OrderDate").AsDateTime().NotNullable()
                .WithColumn("CustomerId").AsInt32().NotNullable()
                    .ForeignKey("FK_SalesOrder_CustomerId", "Customer", "Id")
                .WithColumn("SalesChannelId").AsInt32().NotNullable()
                    .ForeignKey("FK_SalesOrder_SalesChannelId", "SalesChannel", "Id")
                .WithColumn("SubTotal").AsDouble().NotNullable()
                .WithColumn("Discount").AsDouble().NotNullable()
                .WithColumn("BeforeTax").AsDouble().NotNullable()
                .WithColumn("TaxAmount").AsDouble().NotNullable()
                .WithColumn("Total").AsDouble().NotNullable()
                .WithColumn("OtherCharge").AsDouble().NotNullable().WithDefaultValue(0)
                .WithColumn("InsertDate").AsDateTime().Nullable()
                .WithColumn("InsertUserId").AsInt32().Nullable()
                .WithColumn("UpdateDate").AsDateTime().Nullable()
                .WithColumn("UpdateUserId").AsInt32().Nullable()
                .WithColumn("TenantId").AsInt32().NotNullable();

            Create.UniqueConstraint("SalesOrderUniqueConstraint").OnTable("SalesOrder").Columns("Number", "TenantId");

            Create.Table("SalesOrderDetail")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
                .WithColumn("SalesOrderId").AsInt32().NotNullable()
                    .ForeignKey("FK_SalesOrderDetail_SalesOrderId", "SalesOrder", "Id")
                .WithColumn("ProductId").AsInt32().NotNullable()
                    .ForeignKey("FK_SalesOrderDetail_ProductId", "Product", "Id")
                .WithColumn("Price").AsDouble().NotNullable()
                .WithColumn("Qty").AsDouble().NotNullable()
                .WithColumn("SubTotal").AsDouble().NotNullable()
                .WithColumn("Discount").AsDouble().NotNullable()
                .WithColumn("BeforeTax").AsDouble().NotNullable()
                .WithColumn("TaxPercentage").AsDouble().NotNullable()
                .WithColumn("TaxAmount").AsDouble().NotNullable()
                .WithColumn("Total").AsDouble().NotNullable()
                .WithColumn("InsertDate").AsDateTime().Nullable()
                .WithColumn("InsertUserId").AsInt32().Nullable()
                .WithColumn("UpdateDate").AsDateTime().Nullable()
                .WithColumn("UpdateUserId").AsInt32().Nullable()
                .WithColumn("TenantId").AsInt32().NotNullable();

            Create.Table("Invoice")
               .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
               .WithColumn("Number").AsString(200).NotNullable()
               .WithColumn("Description").AsString(1000).Nullable()
               .WithColumn("SalesGroup").AsString(200).Nullable()
               .WithColumn("InvoiceDate").AsDateTime().NotNullable()
               .WithColumn("SalesOrderId").AsInt32().NotNullable()
                   .ForeignKey("FK_Invoice_SalesOrderId", "SalesOrder", "Id")
               .WithColumn("SubTotal").AsDouble().NotNullable()
               .WithColumn("Discount").AsDouble().NotNullable()
               .WithColumn("BeforeTax").AsDouble().NotNullable()
               .WithColumn("TaxAmount").AsDouble().NotNullable()
               .WithColumn("Total").AsDouble().NotNullable()
               .WithColumn("OtherCharge").AsDouble().NotNullable().WithDefaultValue(0)
                .WithColumn("InsertDate").AsDateTime().Nullable()
                .WithColumn("InsertUserId").AsInt32().Nullable()
                .WithColumn("UpdateDate").AsDateTime().Nullable()
                .WithColumn("UpdateUserId").AsInt32().Nullable()
                .WithColumn("TenantId").AsInt32().NotNullable();

            Create.UniqueConstraint("InvoiceUniqueConstraint").OnTable("Invoice").Columns("Number", "TenantId");

            Create.Table("InvoiceDetail")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
                .WithColumn("InvoiceId").AsInt32().NotNullable()
                    .ForeignKey("FK_InvoiceDetail_InvoiceId", "Invoice", "Id")
                .WithColumn("ProductId").AsInt32().NotNullable()
                    .ForeignKey("FK_InvoiceDetail_ProductId", "Product", "Id")
                .WithColumn("Price").AsDouble().NotNullable()
                .WithColumn("Qty").AsDouble().NotNullable()
                .WithColumn("SubTotal").AsDouble().NotNullable()
                .WithColumn("Discount").AsDouble().NotNullable()
                .WithColumn("BeforeTax").AsDouble().NotNullable()
                .WithColumn("TaxPercentage").AsDouble().NotNullable()
                .WithColumn("TaxAmount").AsDouble().NotNullable()
                .WithColumn("Total").AsDouble().NotNullable()
                .WithColumn("InsertDate").AsDateTime().Nullable()
                .WithColumn("InsertUserId").AsInt32().Nullable()
                .WithColumn("UpdateDate").AsDateTime().Nullable()
                .WithColumn("UpdateUserId").AsInt32().Nullable()
                .WithColumn("TenantId").AsInt32().NotNullable();

            Create.Table("InvoicePayment")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
                .WithColumn("InvoiceId").AsInt32().NotNullable()
                    .ForeignKey("FK_InvoicePayment_InvoiceId", "Invoice", "Id")
                .WithColumn("Number").AsString(200).NotNullable()
                .WithColumn("Description").AsString(1000).Nullable()
                .WithColumn("SalesGroup").AsString(200).Nullable()
                .WithColumn("PaymentDate").AsDateTime().NotNullable()
                .WithColumn("CashBankId").AsInt32().NotNullable()
                    .ForeignKey("FK_InvoicePayment_CashBankId", "CashBank", "Id")
                .WithColumn("InvoiceAmount").AsDouble().NotNullable()
                .WithColumn("PaymentAmount").AsDouble().NotNullable()
                .WithColumn("InsertDate").AsDateTime().Nullable()
                .WithColumn("InsertUserId").AsInt32().Nullable()
                .WithColumn("UpdateDate").AsDateTime().Nullable()
                .WithColumn("UpdateUserId").AsInt32().Nullable()
                .WithColumn("TenantId").AsInt32().NotNullable();

            Create.UniqueConstraint("InvoicePaymentUniqueConstraint").OnTable("InvoicePayment").Columns("Number", "TenantId");



            Create.Table("Shipper")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
                .WithColumn("Name").AsString(200).NotNullable()
                .WithColumn("Description").AsString(1000).Nullable()
                .WithColumn("Street").AsString(200).Nullable()
                .WithColumn("City").AsString(200).Nullable()
                .WithColumn("State").AsString(200).Nullable()
                .WithColumn("ZipCode").AsString(10).Nullable()
                .WithColumn("Phone").AsString(50).Nullable()
                .WithColumn("Email").AsString(200).Nullable()
                .WithColumn("InsertDate").AsDateTime().Nullable()
                .WithColumn("InsertUserId").AsInt32().Nullable()
                .WithColumn("UpdateDate").AsDateTime().Nullable()
                .WithColumn("UpdateUserId").AsInt32().Nullable()
                .WithColumn("TenantId").AsInt32().NotNullable();

            Create.UniqueConstraint("ShipperUniqueConstraint").OnTable("Shipper").Columns("Name", "TenantId");

            Create.Table("Location")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
                .WithColumn("Name").AsString(200).NotNullable()
                .WithColumn("Description").AsString(1000).Nullable()
                .WithColumn("InsertDate").AsDateTime().Nullable()
                .WithColumn("InsertUserId").AsInt32().Nullable()
                .WithColumn("UpdateDate").AsDateTime().Nullable()
                .WithColumn("UpdateUserId").AsInt32().Nullable()
                .WithColumn("TenantId").AsInt32().NotNullable();

            Create.UniqueConstraint("LocationUniqueConstraint").OnTable("Location").Columns("Name", "TenantId");

            Create.Table("Warehouse")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
                .WithColumn("Name").AsString(200).NotNullable()
                .WithColumn("Description").AsString(1000).Nullable()
                .WithColumn("Street").AsString(200).Nullable()
                .WithColumn("City").AsString(200).Nullable()
                .WithColumn("State").AsString(200).Nullable()
                .WithColumn("ZipCode").AsString(10).Nullable()
                .WithColumn("Phone").AsString(50).Nullable()
                .WithColumn("Email").AsString(200).Nullable()
                .WithColumn("InsertDate").AsDateTime().Nullable()
                .WithColumn("InsertUserId").AsInt32().Nullable()
                .WithColumn("UpdateDate").AsDateTime().Nullable()
                .WithColumn("UpdateUserId").AsInt32().Nullable()
                .WithColumn("TenantId").AsInt32().NotNullable();

            Create.UniqueConstraint("WarehouseUniqueConstraint").OnTable("Warehouse").Columns("Name", "TenantId");


            Create.Table("PositiveAdjustment")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
                .WithColumn("Number").AsString(200).NotNullable()
                .WithColumn("Description").AsString(1000).Nullable()
                .WithColumn("AdjustmentDate").AsDateTime().NotNullable()
				.WithColumn("ProjectId").AsInt32().NotNullable()
			 .ForeignKey("FK_PositiveAdjustment_ProjectId", "dbo", "Project", "Id")
				.WithColumn("WarehouseId").AsInt32().NotNullable()
                    .ForeignKey("FK_PositiveAdjustment_WarehouseId", "Warehouse", "Id")
                .WithColumn("LocationId").AsInt32().Nullable()
                    .ForeignKey("FK_PositiveAdjustment_LocationId", "Location", "Id")
                .WithColumn("TotalQty").AsDouble().NotNullable()
                .WithColumn("InsertDate").AsDateTime().Nullable()
                .WithColumn("InsertUserId").AsInt32().Nullable()
                .WithColumn("UpdateDate").AsDateTime().Nullable()
                .WithColumn("UpdateUserId").AsInt32().Nullable()
                .WithColumn("TenantId").AsInt32().NotNullable();

            Create.UniqueConstraint("PositiveAdjustmentUniqueConstraint").OnTable("PositiveAdjustment").Columns("Number", "TenantId");


            Create.Table("PositiveAdjustmentDetail")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
                .WithColumn("PositiveAdjustmentId").AsInt32().NotNullable()
                    .ForeignKey("FK_PositiveAdjustmentDetail_PositiveAdjustmentId", "PositiveAdjustment", "Id")
                .WithColumn("ProductId").AsInt32().NotNullable()
                    .ForeignKey("FK_PositiveAdjustmentDetail_ProductId", "Product", "Id")
                .WithColumn("Qty").AsDouble().NotNullable()
                .WithColumn("InsertDate").AsDateTime().Nullable()
                .WithColumn("InsertUserId").AsInt32().Nullable()
                .WithColumn("UpdateDate").AsDateTime().Nullable()
                .WithColumn("UpdateUserId").AsInt32().Nullable()
                .WithColumn("TenantId").AsInt32().NotNullable();


            Create.Table("NegativeAdjustment")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
                .WithColumn("Number").AsString(200).NotNullable()
                .WithColumn("Description").AsString(1000).Nullable()
                .WithColumn("AdjustmentDate").AsDateTime().NotNullable()
					.WithColumn("ProjectId").AsInt32().NotNullable()
			 .ForeignKey("FK_NegativeAdjustment_ProjectId", "dbo", "Project", "Id")
				.WithColumn("WarehouseId").AsInt32().NotNullable()
                    .ForeignKey("FK_NegativeAdjustment_WarehouseId", "Warehouse", "Id")
                .WithColumn("LocationId").AsInt32().Nullable()
                    .ForeignKey("FK_NegativeAdjustment_LocationId", "Location", "Id")
                .WithColumn("TotalQty").AsDouble().NotNullable()
                .WithColumn("InsertDate").AsDateTime().Nullable()
                .WithColumn("InsertUserId").AsInt32().Nullable()
                .WithColumn("UpdateDate").AsDateTime().Nullable()
                .WithColumn("UpdateUserId").AsInt32().Nullable()
                .WithColumn("TenantId").AsInt32().NotNullable();

            Create.UniqueConstraint("NegativeAdjustmentUniqueConstraint").OnTable("NegativeAdjustment").Columns("Number", "TenantId");


            Create.Table("NegativeAdjustmentDetail")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
                .WithColumn("NegativeAdjustmentId").AsInt32().NotNullable()
                    .ForeignKey("FK_NegativeAdjustmentDetail_NegativeAdjustmentId", "NegativeAdjustment", "Id")
                .WithColumn("ProductId").AsInt32().NotNullable()
                    .ForeignKey("FK_NegativeAdjustmentDetail_ProductId", "Product", "Id")
                .WithColumn("Qty").AsDouble().NotNullable()
                .WithColumn("InsertDate").AsDateTime().Nullable()
                .WithColumn("InsertUserId").AsInt32().Nullable()
                .WithColumn("UpdateDate").AsDateTime().Nullable()
                .WithColumn("UpdateUserId").AsInt32().Nullable()
                .WithColumn("TenantId").AsInt32().NotNullable();


            Create.Table("TransferOrder")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
                .WithColumn("Number").AsString(200).NotNullable()
                .WithColumn("Description").AsString(1000).Nullable()
                .WithColumn("TransferDate").AsDateTime().NotNullable()

				  .WithColumn("ProjectFromId").AsInt32().NotNullable()
					.ForeignKey("FK_TransferOrder_ProjectFromId", "Project", "Id")
				.WithColumn("ProjectToId").AsInt32().NotNullable()
					.ForeignKey("FK_TransferOrder_ProjectToId", "Project", "Id")

				.WithColumn("FromId").AsInt32().NotNullable()
                    .ForeignKey("FK_TransferOrder_FromId", "Warehouse", "Id")
                .WithColumn("ToId").AsInt32().NotNullable()
                    .ForeignKey("FK_TransferOrder_ToId", "Warehouse", "Id")
                .WithColumn("TotalQty").AsDouble().NotNullable()
                .WithColumn("InsertDate").AsDateTime().Nullable()
                .WithColumn("InsertUserId").AsInt32().Nullable()
                .WithColumn("UpdateDate").AsDateTime().Nullable()
                .WithColumn("UpdateUserId").AsInt32().Nullable()
                .WithColumn("TenantId").AsInt32().NotNullable();

            Create.UniqueConstraint("TransferOrderUniqueConstraint").OnTable("TransferOrder").Columns("Number", "TenantId");


            Create.Table("TransferOrderDetail")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
                .WithColumn("TransferOrderId").AsInt32().NotNullable()
                    .ForeignKey("FK_TransferOrderDetail_TransferOrderId", "TransferOrder", "Id")
                .WithColumn("ProductId").AsInt32().NotNullable()
                    .ForeignKey("FK_TransferOrderDetail_ProductId", "Product", "Id")
                .WithColumn("Qty").AsDouble().NotNullable()
                .WithColumn("InsertDate").AsDateTime().Nullable()
                .WithColumn("InsertUserId").AsInt32().Nullable()
                .WithColumn("UpdateDate").AsDateTime().Nullable()
                .WithColumn("UpdateUserId").AsInt32().Nullable()
                .WithColumn("TenantId").AsInt32().NotNullable();


            Create.Table("SalesDelivery")
               .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
               .WithColumn("Number").AsString(200).NotNullable()
               .WithColumn("Description").AsString(1000).Nullable()
               .WithColumn("SalesGroup").AsString(200).Nullable()
               .WithColumn("DeliveryDate").AsDateTime().NotNullable()
               .WithColumn("SalesOrderId").AsInt32().NotNullable()
                   .ForeignKey("FK_SalesDelivery_SalesOrderId", "SalesOrder", "Id")
               .WithColumn("ShipperId").AsInt32().NotNullable()
                   .ForeignKey("FK_SalesDelivery_ShipperId", "Shipper", "Id")
				   .WithColumn("ProjectId").AsInt32().NotNullable()
			 .ForeignKey("FK_SalesDelivery_ProjectId", "dbo", "Project", "Id")
			   .WithColumn("WarehouseId").AsInt32().NotNullable()
                   .ForeignKey("FK_SalesDelivery_WarehouseId", "Warehouse", "Id")
               .WithColumn("LocationId").AsInt32().Nullable()
                   .ForeignKey("FK_SalesDelivery_LocationId", "Location", "Id")
               .WithColumn("TotalQtyDelivered").AsDouble().NotNullable()
                .WithColumn("InsertDate").AsDateTime().Nullable()
                .WithColumn("InsertUserId").AsInt32().Nullable()
                .WithColumn("UpdateDate").AsDateTime().Nullable()
                .WithColumn("UpdateUserId").AsInt32().Nullable()
                .WithColumn("TenantId").AsInt32().NotNullable();

            Create.UniqueConstraint("SalesDeliveryUniqueConstraint").OnTable("SalesDelivery").Columns("Number", "TenantId");


            Create.Table("SalesDeliveryDetail")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
                .WithColumn("SalesDeliveryId").AsInt32().NotNullable()
                    .ForeignKey("FK_SalesDeliveryDetail_SalesDeliveryId", "SalesDelivery", "Id")
                .WithColumn("ProductId").AsInt32().NotNullable()
                    .ForeignKey("FK_SalesDeliveryDetail_ProductId", "Product", "Id")
                .WithColumn("QtyDelivered").AsDouble().NotNullable()
                .WithColumn("InsertDate").AsDateTime().Nullable()
                .WithColumn("InsertUserId").AsInt32().Nullable()
                .WithColumn("UpdateDate").AsDateTime().Nullable()
                .WithColumn("UpdateUserId").AsInt32().Nullable()
                .WithColumn("TenantId").AsInt32().NotNullable();


            Create.Table("SalesReturn")
               .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
               .WithColumn("Number").AsString(200).NotNullable()
               .WithColumn("Description").AsString(1000).Nullable()
               .WithColumn("SalesGroup").AsString(200).Nullable()
               .WithColumn("ReturnDate").AsDateTime().NotNullable()
               .WithColumn("SalesDeliveryId").AsInt32().NotNullable()
                   .ForeignKey("FK_SalesReturn_SalesDeliveryId", "SalesDelivery", "Id")
					 .WithColumn("ProjectId").AsInt32().NotNullable()
			 .ForeignKey("FK_SalesReturn_ProjectId", "dbo", "Project", "Id")
			   .WithColumn("WarehouseId").AsInt32().NotNullable()
                   .ForeignKey("FK_SalesReturn_WarehouseId", "Warehouse", "Id")
               .WithColumn("LocationId").AsInt32().Nullable()
                   .ForeignKey("FK_SalesReturn_LocationId", "Location", "Id")
               .WithColumn("TotalQtyReturn").AsDouble().NotNullable()
               .WithColumn("InsertDate").AsDateTime().Nullable()
               .WithColumn("InsertUserId").AsInt32().Nullable()
               .WithColumn("UpdateDate").AsDateTime().Nullable()
               .WithColumn("UpdateUserId").AsInt32().Nullable()
               .WithColumn("TenantId").AsInt32().NotNullable();

            Create.UniqueConstraint("SalesReturnUniqueConstraint").OnTable("SalesReturn").Columns("Number", "TenantId");


            Create.Table("SalesReturnDetail")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
                .WithColumn("SalesReturnId").AsInt32().NotNullable()
                    .ForeignKey("FK_SalesReturnDetail_SalesReturnId", "SalesReturn", "Id")
                .WithColumn("ProductId").AsInt32().NotNullable()
                    .ForeignKey("FK_SalesReturnDetail_ProductId", "Product", "Id")
                .WithColumn("QtyReturn").AsDouble().NotNullable()
                .WithColumn("InsertDate").AsDateTime().Nullable()
                .WithColumn("InsertUserId").AsInt32().Nullable()
                .WithColumn("UpdateDate").AsDateTime().Nullable()
                .WithColumn("UpdateUserId").AsInt32().Nullable()
                .WithColumn("TenantId").AsInt32().NotNullable();


            Create.Table("PurchaseReceipt")
               .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
               .WithColumn("Number").AsString(200).NotNullable()
               .WithColumn("Description").AsString(1000).Nullable()
               .WithColumn("ExternalReferenceNumber").AsString(200).Nullable()
               .WithColumn("ProcurementGroup").AsString(200).Nullable()
               .WithColumn("ReceiptDate").AsDateTime().NotNullable()
               .WithColumn("PurchaseOrderId").AsInt32().NotNullable()
                   .ForeignKey("FK_PurchaseReceipt_PurchaseOrderId", "PurchaseOrder", "Id")
					.WithColumn("ProjectId").AsInt32().NotNullable()
			 .ForeignKey("FK_PurchaseReceipt_ProjectId", "dbo", "Project", "Id")
			  .WithColumn("WarehouseId").AsInt32().NotNullable()
                   .ForeignKey("FK_PurchaseReceipt_WarehouseId", "Warehouse", "Id")
               .WithColumn("LocationId").AsInt32().Nullable()
                   .ForeignKey("FK_PurchaseReceipt_LocationId", "Location", "Id")
               .WithColumn("TotalQtyReceive").AsDouble().NotNullable()
               .WithColumn("InsertDate").AsDateTime().Nullable()
               .WithColumn("InsertUserId").AsInt32().Nullable()
               .WithColumn("UpdateDate").AsDateTime().Nullable()
               .WithColumn("UpdateUserId").AsInt32().Nullable()
               .WithColumn("TenantId").AsInt32().NotNullable();

            Create.UniqueConstraint("PurchaseReceiptUniqueConstraint").OnTable("PurchaseReceipt").Columns("Number", "TenantId");


            Create.Table("PurchaseReceiptDetail")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
                .WithColumn("PurchaseReceiptId").AsInt32().NotNullable()
                    .ForeignKey("FK_PurchaseReceiptDetail_PurchaseReceiptId", "PurchaseReceipt", "Id")
                .WithColumn("ProductId").AsInt32().NotNullable()
                    .ForeignKey("FK_PurchaseReceiptDetail_ProductId", "Product", "Id")
                .WithColumn("QtyReceive").AsDouble().NotNullable()
                .WithColumn("InsertDate").AsDateTime().Nullable()
                .WithColumn("InsertUserId").AsInt32().Nullable()
                .WithColumn("UpdateDate").AsDateTime().Nullable()
                .WithColumn("UpdateUserId").AsInt32().Nullable()
                .WithColumn("TenantId").AsInt32().NotNullable();


            Create.Table("PurchaseReturn")
               .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
               .WithColumn("Number").AsString(200).NotNullable()
               .WithColumn("Description").AsString(1000).Nullable()
               .WithColumn("ProcurementGroup").AsString(200).Nullable()
               .WithColumn("ReturnDate").AsDateTime().NotNullable()
               .WithColumn("PurchaseReceiptId").AsInt32().NotNullable()
                   .ForeignKey("FK_PurchaseReturn_PurchaseReceiptId", "PurchaseReceipt", "Id")
					   .WithColumn("ProjectId").AsInt32().NotNullable()
			 .ForeignKey("FK_PurchaseReturn_ProjectId", "dbo", "Project", "Id")
			   .WithColumn("WarehouseId").AsInt32().NotNullable()
                   .ForeignKey("FK_PurchaseReturn_WarehouseId", "Warehouse", "Id")
               .WithColumn("LocationId").AsInt32().Nullable()
                   .ForeignKey("FK_PurchaseReturn_LocationId", "Location", "Id")
               .WithColumn("TotalQtyReturn").AsDouble().NotNullable()
               .WithColumn("InsertDate").AsDateTime().Nullable()
               .WithColumn("InsertUserId").AsInt32().Nullable()
               .WithColumn("UpdateDate").AsDateTime().Nullable()
               .WithColumn("UpdateUserId").AsInt32().Nullable()
               .WithColumn("TenantId").AsInt32().NotNullable();

            Create.UniqueConstraint("PurchaseReturnUniqueConstraint").OnTable("PurchaseReturn").Columns("Number", "TenantId");


            Create.Table("PurchaseReturnDetail")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
                .WithColumn("PurchaseReturnId").AsInt32().NotNullable()
                    .ForeignKey("FK_PurchaseReturnDetail_PurchaseReturnId", "PurchaseReturn", "Id")
                .WithColumn("ProductId").AsInt32().NotNullable()
                    .ForeignKey("FK_PurchaseReturnDetail_ProductId", "Product", "Id")
                .WithColumn("QtyReturn").AsDouble().NotNullable()
                .WithColumn("InsertDate").AsDateTime().Nullable()
                .WithColumn("InsertUserId").AsInt32().Nullable()
                .WithColumn("UpdateDate").AsDateTime().Nullable()
                .WithColumn("UpdateUserId").AsInt32().Nullable()
                .WithColumn("TenantId").AsInt32().NotNullable();


        }
    }
}