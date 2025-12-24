using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20230727113220)]
    public class DefaultDB_20230727_113220_Indotalent_TaxTable : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("Tax")
               .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
               .WithColumn("PO ").AsString().Nullable()
               .WithColumn("typeNumber").AsString(1000).Nullable()
               .WithColumn("totalAmount").AsDouble().Nullable()
                .WithColumn("IGST ").AsInt32().Nullable()
                 .WithColumn("CGST").AsInt32().Nullable()
                  .WithColumn("SGST").AsInt32().Nullable()
                   .WithColumn("UGST").AsInt32().Nullable()
                    .WithColumn("TDS").AsInt32().Nullable()
                     .WithColumn("TCS").AsInt32().Nullable()
               .WithColumn("InsertDate").AsDateTime().Nullable()
               .WithColumn("InsertUserId").AsInt32().Nullable()
               .WithColumn("UpdateDate").AsDateTime().Nullable()
               .WithColumn("UpdateUserId").AsInt32().Nullable()
               .WithColumn("TenantId").AsInt32().NotNullable();
        }
    }
}