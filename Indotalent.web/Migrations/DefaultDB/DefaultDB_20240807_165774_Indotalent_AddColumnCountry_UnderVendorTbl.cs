using DocumentFormat.OpenXml.Drawing.Charts;
using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20240807165774)]
    public class DefaultDB_20240807_165774_Indotalent_AddColumnCountry_UnderVendorTbl : AutoReversingMigration
    {
        public override void Up()
        {
            Alter.Table("Vendor").InSchema("dbo")
             .AddColumn("CountryId").AsInt32().Nullable()
             .ForeignKey("FK_Vendor_CountryId", "Country", "Id")
             .AddColumn("StateId").AsInt32().Nullable()
             .ForeignKey("FK_Vendor_StateId", "State", "Id");
        }
    }
}