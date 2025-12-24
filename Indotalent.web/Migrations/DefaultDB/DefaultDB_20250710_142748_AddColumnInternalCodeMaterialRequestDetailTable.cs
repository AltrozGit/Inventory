using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20250710142748)]
    public class DefaultDB_20250710_142748_AddColumnInternalCodeMaterialRequestDetailTable : AutoReversingMigration
    {
        public override void Up()
        {
            Alter.Table("MaterialRequestDetail").InSchema("dbo")
             .AddColumn("InternalCode").AsString(100).Nullable();


        }
    }
}