using FluentMigrator;
using Serenity.Extensions;


namespace Indotalent.Migrations.DefaultDB
{ 

    [Migration(20240916115159)]
    public class DefaultDB_20240916_115159_Indotalent_AddColForTDSTCSImplementation_UnderInvoiceTable : AutoReversingMigration
    {
        public override void Up()
        {
            Alter.Table("Invoice").InSchema("dbo")
             .AddColumn("TcsTdsTaxAmount").AsDouble().Nullable()
             .AddColumn("FinalTotalPostTDS_TCS").AsDouble().Nullable()
             .AddColumn("TaxType").AsInt32().Nullable()
             .AddColumn("TDS ").AsDouble().Nullable()
             .AddColumn("TCS").AsDouble().Nullable();

        }
    }
}


