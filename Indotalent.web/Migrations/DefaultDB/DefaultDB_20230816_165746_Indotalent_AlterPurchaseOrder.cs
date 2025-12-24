using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20230816165746)]
    public class DefaultDB_20230816_165746_Indotalent_AlterPurchaseOrder : AutoReversingMigration
    {
        public override void Up()
        {

			Alter.Table("PurchaseOrder").InSchema("dbo")
			 .AddColumn("MaterialRequestId").AsInt32().Nullable()
			 .ForeignKey("FK_PurchaseOrder_MaterialRequestId", "dbo", "MaterialRequest", "Id");
		}
    }
}