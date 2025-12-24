using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20240529130000)]
    public class DefaultDB_20240529_130000_AddingFileSelectorToPurchaseOrder : AutoReversingMigration
    {
        public override void Up()
        {

            Alter.Table("PurchaseOrder").InSchema("dbo")
                .AddColumn("UploadQuotation").AsString(int.MaxValue).Nullable();
             
        }
    }
}