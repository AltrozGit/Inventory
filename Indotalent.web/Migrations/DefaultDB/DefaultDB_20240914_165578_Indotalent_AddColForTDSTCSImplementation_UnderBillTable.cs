using FluentMigrator;
using Serenity.Extensions;


namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20240914165578)]
    public class DefaultDB_20240914_165578_Indotalent_AddColForTDSTCSImplementation_UnderBillTable : AutoReversingMigration
    {
        public override void Up()
        {
            Alter.Table("Bill").InSchema("dbo")
             .AddColumn("TcsTdsTaxAmount").AsDouble().Nullable()
             .AddColumn("FinalTotalPostTDS_TCS").AsDouble().Nullable()
             .AddColumn("TaxType").AsInt32().Nullable()
             .AddColumn("TDS ").AsDouble().Nullable()
             .AddColumn("TCS").AsDouble().Nullable();
           
        }
    }
}
