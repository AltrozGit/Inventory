using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20240916114560)]
    public class DefaultDB_20240916_114560_Indotalent_AddTaxColumn_UnderInvoiceDetailTable : AutoReversingMigration
    {
        public override void Up()
        {

            Alter.Table("InvoiceDetail").InSchema("dbo")
            .AddColumn("SGST ").AsDouble().Nullable()
             .AddColumn("CGST").AsDouble().Nullable()
             .AddColumn("IGST").AsDouble().Nullable();


        }
    }
}




