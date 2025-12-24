using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20230827165578)]
    public class DefaultDB_20230827_165578_Indotalent_AddColTaxType_TcsTdsTaxAmount_FinalTotalPostTDS_TCS_UnderPOtbl : AutoReversingMigration
    {
       
        public override void Up()
        {
            Alter.Table("PurchaseOrder").InSchema("dbo")
            .AddColumn("TaxType").AsInt32().Nullable()
             .AddColumn("TcsTdsTaxAmount").AsDouble().Nullable()
             .AddColumn("FinalTotalPostTDS_TCS").AsDouble().Nullable();



        }
    }
}
