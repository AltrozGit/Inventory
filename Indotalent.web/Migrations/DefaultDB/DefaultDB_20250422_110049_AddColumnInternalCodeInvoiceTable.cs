using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20250422110049)]
    public class DefaultDB_20250422_110049_AddColumnInternalCodeInvoiceTable : AutoReversingMigration
    {
        public override void Up()
        {
			 Alter.Table("InvoiceDetail").InSchema("dbo")
              .AddColumn("InternalCode").AsString(100).Nullable();

           

        }
    }
}