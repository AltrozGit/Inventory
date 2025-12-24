using DocumentFormat.OpenXml.Drawing.Charts;
using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20252603164946)]
    public class DefaultDB_20252603_164946_RemoveFkPurchadeOrderIdBillTBL : ForwardOnlyMigration
    {
        public override void Up()
        {
            Delete.ForeignKey("FK_Bill_PurchaseOrderId")

               .OnTable("Bill");


        }
       
    }
}