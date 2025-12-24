
using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20250319181000)]
    public class DefaultDB_20250319_181000_AddNewCoulmnForGlobal : AutoReversingMigration
    {
        public override void Up()
        {

            Alter.Table("InvoicePayment").InSchema("dbo")
                .AddColumn("SupportingDocuments").AsString(int.MaxValue).Nullable()
                 .AddColumn("PaymentMode").AsString().Nullable()
                  .AddColumn("TransactionNumber").AsString().Nullable();


            Alter.Table("Invoice").InSchema("dbo")
           .AlterColumn("SalesOrderId").AsInt32().Nullable()
           .AddColumn("CustomerPONumber").AsString().Nullable()
           .AddColumn("PONumberDate").AsDateTime().Nullable()
           .AddColumn("PyamentTerm").AsString().Nullable();

            Alter.Table("Product").InSchema("dbo")
          .AlterColumn("BrandId").AsInt32().Nullable();
        


        }
    }
}