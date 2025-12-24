using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20250423110049)]
    public class DefaultDB_20250423_110049_AddColumnInternalCodeQuotationDetailTable : AutoReversingMigration
    {
        public override void Up()
        {
			 Alter.Table("QuotationDetail").InSchema("dbo")
              .AddColumn("InternalCode").AsString(100).Nullable();

           

        }
    }
}