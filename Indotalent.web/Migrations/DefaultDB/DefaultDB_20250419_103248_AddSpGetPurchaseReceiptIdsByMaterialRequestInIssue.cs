using FluentMigrator;

using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB

{

    [Migration(20250419103248)]

    public class DefaultDB_20250419_103248_AddSpGetPurchaseReceiptIdsByMaterialRequestInIssue : ForwardOnlyMigration

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

CREATE PROCEDURE [dbo].[usp_GetPurchaseReceiptIdsByMaterialRequest]
    @MaterialRequestId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT pr.Id
    FROM PurchaseReceipt pr
    JOIN PurchaseOrder po ON pr.purchaseorderid = po.Id
    JOIN MaterialRequest mr ON po.materialrequestid = mr.Id
    WHERE mr.Id = @MaterialRequestId;
END");

        }

    }

}

