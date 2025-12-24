using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20240726130002)]
    public class DefaultDB_20240726_130002_AddQuotationReferenceNumber : AutoReversingMigration
    {
        public override void Up()
        {
            Alter.Table("PurchaseOrder").InSchema("dbo")
               
                .AddColumn("QuotationReferenceNumber").AsString().Nullable();
        }
    }
}