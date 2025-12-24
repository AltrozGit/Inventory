using FluentMigrator;

using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB

{

    [Migration(20250718115748)]

    public class DefaultDB_20250718_115748_AddCreateInvoiceSP : ForwardOnlyMigration

    {

        public override void Up()

        {

            // Creating the stored procedure using raw SQL

            Execute.Sql(@"

              SET ANSI_NULLS ON

              GO

              SET QUOTED_IDENTIFIER ON

              GO
 
-- =============================================

-- Author:		<Author,,Name>

-- Create date: <Create Date,,>

-- Description:	<Description,,>
 
-- =============================================


CREATE PROCEDURE [dbo].[CreateInvoice]
 @HRMSTenantID INT,
 @PayrollId INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE
	 @TenantName NVARCHAR(100),
	 @InventoryTenantID  INT,
	 @InventoryCustomerID INT,
	 @TotalGross float(10), 
	@PayrollCharges float(10),
	@PayrollChargesAmount  float(10),
	@Number nvarchar(100),
	@Number1 nvarchar(100),
	@PayrollPercent float(10),
	@CustomerName nvarchar(100)

	set @TenantName='BR India'
	 -- Step 1: Get tenant name from HRMS


    IF @TenantName IS NULL
    BEGIN
        RAISERROR('Tenant not found in HRMS.', 16, 1);
       
    END
	  -- Step 2: Check if tenant exists in Inventory
    SELECT @InventoryTenantID = TenantID
    FROM Tenant
    WHERE TenantName = @TenantName;

	  IF @InventoryTenantID IS NULL
    BEGIN
        INSERT INTO Tenant (TenantName,Currency,MaximumUser)
        VALUES (@TenantName,'INR',5);

        SET @InventoryTenantID = SCOPE_IDENTITY();
    END
	--create customer in Inventory
	 -- Step 1: Get tenant name from HRMS
		 SELECT @CustomerName = TenantName
    FROM [HRMSProd].dbo.Tenant
    WHERE TenantID = @HRMSTenantID;

    IF @CustomerName IS NULL
    BEGIN
        RAISERROR('Customer not found in Inventory.', 16, 1);
       
    END
	 -- Step 2: Check if customer exists in Inventory
   DECLARE @NormalizedCustomerName NVARCHAR(255);
SET @NormalizedCustomerName = LOWER(REPLACE(@CustomerName, ' ', ''));

-- Step 2: Check if normalized customer exists in Inventory
SELECT @InventoryCustomerID = TenantId
FROM Customer
WHERE TenantId = @InventoryTenantID
  AND LOWER(REPLACE(Name, ' ', '')) = @NormalizedCustomerName;

IF @InventoryCustomerID IS NULL
BEGIN
    -- Insert new customer
    INSERT INTO Customer (Name, TenantId, IsActive)
    VALUES (@CustomerName, @InventoryTenantID, 1);

    -- Get the newly inserted ID
    SET @InventoryCustomerID = SCOPE_IDENTITY();
END
declare @CustomerId int
select @CustomerId=max(Id) from  Customer
print @NormalizedCustomerName
--------

	  SELECT @TotalGross = TotalGross
    FROM [HRMSProd].dbo.Payroll
    WHERE Id = @PayrollId
	
	  SELECT @PayrollCharges = PayrollCharges
    FROM [Hrmsprod].dbo.TenantConfiguration
    WHERE TenantId = @HRMSTenantID
	print @PayrollCharges
	--calculate  @payrollChargesAmount
	set @PayrollPercent= @PayrollCharges/100
	print @PayrollPercent
	set @PayrollChargesAmount=@TotalGross*@PayrollPercent
	SET @Number = 'INV/' + FORMAT(GETDATE(), 'yyyyMMddHHmmss')

	print @PayrollChargesAmount print @Number

-------Add Sales channel for sodeclare @PurchaseTax nvarchar(50),@PurchaseTaxName varchar(100)
   declare @Saleschannel nvarchar(50),@SalesChannelName varchar(100)
   set @SalesChannelName='White label'
	

	  SELECT @Saleschannel = [name]
    FROM SalesChannel
    WHERE TenantId = @InventoryTenantID and Name=@SalesChannelName

	  IF @Saleschannel IS NULL
    BEGIN
        INSERT INTO SalesChannel(Name,TenantId,IsActive)
        VALUES (@SalesChannelName,@InventoryTenantID,1);
    END

	declare @SalesChannelId int
select @SalesChannelId=max(Id) from  SalesChannel where  Name=@SalesChannelName and TenantId = @InventoryTenantID
------
--Add Category
declare @Category1 nvarchar(50),@CategoryName1 varchar(100)
    set @CategoryName1='PayrollService'
	

	  SELECT @Category1 = [name]
    FROM Category
    WHERE TenantId = @InventoryTenantID and Name=@CategoryName1

	  IF @Category1 IS NULL
    BEGIN
        INSERT INTO Category(Name,TenantId,IsActive)
        VALUES (@CategoryName1,@InventoryTenantID,1);
    END

	declare @CategoryId int
select @CategoryId=max(Id) from  Category where  Name='PayrollService'and TenantId = @InventoryTenantID

--Add UOM
declare @Uom1 nvarchar(50),@UomName1 varchar(100)
    set @UomName1='No Unit'
	

	  SELECT @Uom1 = [name]
    FROM Uom
    WHERE TenantId = @InventoryTenantID and Name=@UomName1

	  IF @Uom1 IS NULL
    BEGIN
        INSERT INTO Uom(Name,TenantId,IsActive)
        VALUES (@UomName1,@InventoryTenantID,1);
    END

	declare @UomId int
select @UomId=max(Id) from  Uom where  Name=@UomName1 and TenantId = @InventoryTenantID

--Add Sac code 
declare @SAC nvarchar(50),@SACName varchar(100),@SacCode varchar(100),@SacDescription varchar(100)
    set @SACName='998223 '
	set @SacDescription='Payroll Service'
	set @SacCode='998223'

	  SELECT @SAC = [sacname]
    FROM SAC
    WHERE SacName=@SACName

	  IF @SAC IS NULL
    BEGIN
        INSERT INTO SAC(IsActive,SacName,SacCode,SacDescription)
        VALUES (1,@SACName,@SacCode,@SacDescription);
    END

	declare @SacId int
select @SacId=max(Id) from  SAC where  SacName=@SACName and SacCode = @SacCode



-- Add Purchase Tax
declare @PurchaseTax nvarchar(50),@PurchaseTaxName varchar(100)
    set @PurchaseTaxName='No Tax'
	

	  SELECT @PurchaseTax = [name]
    FROM PurchaseTax
    WHERE TenantId = @InventoryTenantID and Name=@PurchaseTaxName

	  IF @PurchaseTax IS NULL
    BEGIN
        INSERT INTO PurchaseTax(Name,TaxRatePercentage,TenantId,IsActive)
        VALUES (@PurchaseTaxName,0,@InventoryTenantID,1);
    END

	declare @PurchaseTaxId int
select @PurchaseTaxId=max(Id) from  PurchaseTax where  Name=@PurchaseTaxName and TenantId = @InventoryTenantID

-- Add Sales Tax
declare @SalesTax nvarchar(50),@SalesTaxName varchar(100)
    set @SalesTaxName='No Tax'
	

	  SELECT @SalesTax = [name]
    FROM SalesTax
    WHERE TenantId = @InventoryTenantID and Name=@SalesTaxName

	  IF @SalesTax IS NULL
    BEGIN
        INSERT INTO SalesTax(Name,TaxRatePercentage,TenantId,IsActive)
        VALUES (@SalesTaxName,0,@InventoryTenantID,1);
    END

	declare @SalesTaxId int
select @SalesTaxId=max(Id) from  SalesTax where  Name=@SalesTaxName and TenantId = @InventoryTenantID


--Add Products
declare @Product1 nvarchar(50),  @Product2 nvarchar(50),@ProductName1 varchar(100),@ProductName2 varchar(100)
    set @ProductName1='TotalPayrollAmount'
	set @ProductName2='PayrollCharges'

	  SELECT @Product1 = [name]
    FROM Product
    WHERE TenantId = @InventoryTenantID and Name=@ProductName1

	  IF @Product1 IS NULL
    BEGIN
        INSERT INTO Product (Name,InternalCode,UomId,CategoryId,PurchasePrice,SalesPrice,PurchaseTaxId,SalesTaxId,MinimumQty,TenantId,IsActive)
        VALUES (@ProductName1,@SacCode,@UomId,@CategoryId,0,0,@PurchaseTaxId,@SalesTaxId,1,@InventoryTenantID,1);
    END
	 declare @ProductId1 int
select @ProductId1=max(Id) from  Product where  Name=@ProductName1 and TenantId = @InventoryTenantID

	SELECT @Product2 = [name]
    FROM Product
    WHERE TenantId = @InventoryTenantID  and Name=@ProductName2

	  IF @Product2 IS NULL
    BEGIN
        INSERT INTO Product (Name,InternalCode,UomId,CategoryId,PurchasePrice,SalesPrice,PurchaseTaxId,SalesTaxId,MinimumQty,TenantId,IsActive)
        VALUES (@ProductName2,@SacCode,@UomId,@CategoryId,0,0,@PurchaseTaxId,@SalesTaxId,1,@InventoryTenantID,1);
    END

	declare @ProductId2 int
select @ProductId2=max(Id) from  Product where  Name=@ProductName2 and TenantId = @InventoryTenantID




-------create sales order
-----
declare @InvoiceId int
declare @CGST float , @SGST float, @CGSTAmount float, @SGSTAmount float, @CGSTAmount1 float, @SGSTAmount1 float,@taxpercent float,@taxamount float,@taxamount1 float, @subtotal float , @beforetaxamount float
SET @CGST = 9
SET @SGST =9
SET @CGSTAmount =@PayrollChargesAmount*(@CGST/100)
SET @SGSTAmount =@PayrollChargesAmount*(@SGST/100)
SET @CGSTAmount1 =@TotalGross*(@CGST/100)
SET @SGSTAmount1 =@TotalGross*(@SGST/100)
SET @taxpercent= 18
SET @taxamount= @SGSTAmount+@CGSTAmount
SET @taxamount1= @SGSTAmount1+@CGSTAmount1
SET @subtotal=(@TotalGross+@taxamount1)+(@PayrollChargesAmount+@taxamount)
SET @beforetaxamount=(@TotalGross+@taxamount1)+(@PayrollChargesAmount+@taxamount)
print @taxpercent
print @taxamount
print @taxamount1
print @beforetaxamount

DECLARE @Total float 
SET @Total = @PayrollChargesAmount+@CGSTAmount+@SGSTAmount

SET @Number1 = 'SO/' + FORMAT(GETDATE(), 'yyyyMMddHHmmss')
 IF NOT EXISTS (select CustomerPONumber from Invoice where CustomerPONumber=@PayrollId)
 BEGIN
INSERT INTO SalesOrder(
    Number,
	SalesGroup,
    OrderDate,
	CustomerId,
	SalesChannelId,
    SubTotal,
    Discount,
    BeforeTax,
    TaxAmount,
    Total,
    OtherCharge,
    InsertDate,
    TenantId,
    IsInvoiceGenerated,
	TcsTdsTaxAmount,
    IsActive
) VALUES (
@Number1,
@PayrollId,
GETDATE(),
@CustomerId,
@SalesChannelId,
@TotalGross,
0,
@PayrollChargesAmount,
0,
@PayrollChargesAmount,
0,
GETDATE(),
@InventoryTenantID,
0,
0,
1
);

declare @SalesOrderId int
select @SalesOrderId=max(Id) from  SalesOrder

--Insert values into SO details
INSERT INTO SalesOrderDetail(
    SalesOrderId,
	ProductId,
	Price,
	Qty,
	SubTotal,
	Discount,
	BeforeTax,
	TaxPercentage,
	TaxAmount,
	Total,
	InsertDate,
	TenantId,
	IsActive,
	InternalCode
   
) VALUES (
@SalesOrderId,
@ProductId1,
@TotalGross,
1,
@TotalGross,
0,
@TotalGross,
@taxpercent,
@taxamount1,
@TotalGross+@taxamount1,
GETDATE(),
@InventoryTenantID,
1,
@SacCode
);


INSERT INTO SalesOrderDetail(
    SalesOrderId,
	ProductId,
	Price,
	Qty,
	SubTotal,
	Discount,
	BeforeTax,
	TaxPercentage,
	TaxAmount,
	Total,
	InsertDate,
	TenantId,
	IsActive,
	InternalCode
   
) VALUES (
@SalesOrderId,
@ProductId2,
@PayrollChargesAmount,
1,
@PayrollChargesAmount,
0,
@PayrollChargesAmount,
@taxpercent,
@taxamount,
@PayrollChargesAmount+@taxamount,
GETDATE(),
@InventoryTenantID,
1,
@SacCode
);
END
ELSE
 BEGIN
        RAISERROR('Invoice is already generated for this Payroll .', 16, 1);
         RETURN;
    END




---check for payrolll exist


 IF NOT EXISTS (select CustomerPONumber from Invoice where CustomerPONumber=@PayrollId)

 BEGIN
 print @PayrollId
	INSERT INTO Invoice (
    Number,
    InvoiceDate,
	SalesOrderId,
    SubTotal,
    Discount,
    BeforeTax,
    TaxAmount,
    Total,
    OtherCharge,
    InsertDate,
    TenantId,
    IsInvoicePaymentGenerated,
	TcsTdsTaxAmount,
	FinalTotalPostTDS_TCS,
    IsActive,
	CustomerPONumber
) VALUES (
@Number,
GETDATE(),
@SalesOrderId,
@TotalGross,
0,
@TotalGross+@PayrollChargesAmount,
@taxamount+@taxamount1,
@TotalGross+@PayrollChargesAmount+
@taxamount+@taxamount1,
0,
GETDATE(),
@InventoryTenantID,
0,
0,
@subtotal,
1,
@PayrollId
);


select @InvoiceId=max(Id) from  Invoice

---insetinto invoice details

INSERT INTO InvoiceDetail(
    InvoiceId,
	ProductId,
	Price,
	Qty,
	SubTotal,
	Discount,
	BeforeTax,
	TaxPercentage,
	TaxAmount,
	Total,
	InsertDate,
	TenantId,
	[SGST ],
	CGST,
	SGSTAmount,
	CGSTAmount,
	IsActive,
	InternalCode
   
) VALUES (
@InvoiceId,
@ProductId1,
@TotalGross,
1,
@TotalGross,
0,
@TotalGross,
@taxpercent,
@taxamount1,
@TotalGross+@taxamount1,
GETDATE(),
@InventoryTenantID,
@SGST,
@CGST,
@SGSTAmount1,
@CGSTAmount1,
1,
@SacCode

);



INSERT INTO InvoiceDetail(
    InvoiceId,
	ProductId,
	Price,
	Qty,
	SubTotal,
	Discount,
	BeforeTax,
	TaxPercentage,
	TaxAmount,
	Total,
	InsertDate,
	TenantId,
	[SGST ],
	CGST,
	SGSTAmount,
	CGSTAmount,
	IsActive,
	InternalCode
   
) VALUES (
@InvoiceId,
@ProductId2,
@PayrollChargesAmount,
1,
@PayrollChargesAmount,
0,
@PayrollChargesAmount,
@taxpercent,
@taxamount,
@PayrollChargesAmount+@taxamount,
GETDATE(),
@InventoryTenantID,
@SGST,
@CGST,
@PayrollChargesAmount*(@SGST/100),
@PayrollChargesAmount*(@CGST/100),
1,
@SacCode
);
END
ELSE
 BEGIN
        RAISERROR('Invoice is already generated for this Payroll .', 16, 1);
         RETURN;
    END

END;

GO


");

        }

    }

}

