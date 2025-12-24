using FluentMigrator;
using Serenity.Extensions;


namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20241106500000)]
    public class DefaultDB_20241106_500000_AddingColumnsOnMaterialRequestAndMaterialRequestDetailTable : AutoReversingMigration
    {
        public override void Up()
        {
            Alter.Table("MaterialRequest").InSchema("dbo")
            .AddColumn("Total").AsDouble().Nullable();


            Alter.Table("MaterialRequestDetail").InSchema("dbo")
            .AddColumn("PurchasePrice").AsDouble().Nullable()
            .AddColumn("SubTotal").AsDouble().Nullable();


        }
    }
}
