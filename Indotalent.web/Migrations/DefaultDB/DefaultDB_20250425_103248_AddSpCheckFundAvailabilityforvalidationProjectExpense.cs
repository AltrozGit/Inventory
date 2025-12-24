using FluentMigrator;

using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB

{

    [Migration(20250425103248)]

    public class DefaultDB_20250425_103248_AddSpCheckFundAvailabilityforvalidationProjectExpense : ForwardOnlyMigration

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

CREATE PROCEDURE [dbo].[CheckFundAvailability]
    @ProjectId INT,
    @NewExpense FLOAT
AS
BEGIN
    DECLARE @IsFundAvailable BIT;
 
    IF EXISTS (
        SELECT 1
        FROM [dbo].[vwProjectFund]
        WHERE ProjectId = @ProjectId AND @NewExpense < AvailableFund
    )
    BEGIN
        SET @IsFundAvailable = 1;
    END
    ELSE
    BEGIN
        SET @IsFundAvailable = 0;
    END
 
    -- Output the result
    SELECT @IsFundAvailable AS IsFundAvailable;
END");

        }

    }

}

