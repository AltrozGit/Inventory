using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20230816140826)]
    public class DefaultDB_20230816_140826_Indotalent_PurchaseOrder_IsBillGenerated : AutoReversingMigration
    {
        public override void Up()
        {

            Alter.Table("PurchaseOrder").InSchema("dbo").
             AddColumn("IsBillGenerated").AsBoolean().NotNullable().WithDefaultValue(false);


        }
    }
}