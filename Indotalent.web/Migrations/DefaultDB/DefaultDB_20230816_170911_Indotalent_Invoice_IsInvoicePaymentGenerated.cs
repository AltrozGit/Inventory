using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20230816170911)]
    public class DefaultDB_20230816_170911_Indotalent_Invoice_IsInvoicePaymentGenerated : AutoReversingMigration
    {
        public override void Up()
        {

            Alter.Table("Invoice").InSchema("dbo").
             AddColumn("IsInvoicePaymentGenerated").AsBoolean().NotNullable().WithDefaultValue(false);


        }
    }
}