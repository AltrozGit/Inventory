using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20240915140730)]
    public class DefaultDB_20240915_140730_Indotalent_AddColForTDSTCSImplementation_UnderSalesOrderTable : AutoReversingMigration
    {
        public override void Up()
        {
            Alter.Table("SalesOrder").InSchema("dbo")
             .AddColumn("TcsTdsTaxAmount").AsDouble().Nullable()
             .AddColumn("FinalTotalPostTDS_TCS").AsDouble().Nullable()
             .AddColumn("TaxType").AsInt32().Nullable()
             .AddColumn("TDS ").AsDouble().Nullable()
             .AddColumn("TCS").AsDouble().Nullable();

        }
    }
}
