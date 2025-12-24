using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20240808140000)]
    public class DefaultDB_20240808_140000_Adding_Dispatch_Fields_To_SalesOrder : AutoReversingMigration
    {
        public override void Up()
        {

            Alter.Table("SalesOrder").InSchema("dbo")
                .AddColumn("DispatchedBy").AsString(500).Nullable()
                .AddColumn("DispatchedTo").AsString(500).Nullable()
                .AddColumn("PlaceOfSupply").AsString(200).Nullable();
               

        }
    }
}