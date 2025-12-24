using DocumentFormat.OpenXml.Drawing.Charts;
using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20250417141249)]
    public class DefaultDB_20250417_141249_RemoveProjectIdColumnNotNullConstraint : AutoReversingMigration
    {
        public override void Up()
        {
            Alter.Table("Bill")
                .AlterColumn("ProjectId")
                .AsInt32()  // Adjust the column type if necessary
                .Nullable(); // This removes the NOT NULL constraint
                             // Delete.Index("IX_Bill_PurchaseOrderId").OnTable("Bill");

        }

    }
}