using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20230914141159)]
    public class DefaultDB_20230914_141159_Indotalent_SalesOrder_IsInvoiceGenerated : AutoReversingMigration
    {
        public override void Up()
        {

            Alter.Table("SalesOrder").InSchema("dbo").
             AddColumn("IsInvoiceGenerated").AsBoolean().NotNullable().WithDefaultValue(false);


        }
    }
}