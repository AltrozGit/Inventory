

using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20250310100500)]
    public class DefaultDB_20250310_100500_AddColumnPendingMaterialRequestQty_UnderProjectMaterialRequestDetailtbl : AutoReversingMigration
    {
        public override void Up()
        {
            Alter.Table("ProjectMaterialRequestDetail").InSchema("dbo")

                .AddColumn("PendingMaterialRequestQty").AsDouble().Nullable().WithDefaultValue(0);
        }
    }
}