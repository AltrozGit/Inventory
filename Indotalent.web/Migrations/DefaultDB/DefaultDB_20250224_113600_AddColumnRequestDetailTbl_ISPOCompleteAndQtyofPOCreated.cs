
using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20250224113600)]
    public class DefaultDB_20250224_113600_AddColumnRequestDetailTbl_ISPOCompleteAndQtyofPOCreated : AutoReversingMigration
    {
        public override void Up()
        {
            Alter.Table("MaterialRequestDetail").InSchema("dbo")
           .AddColumn("QuanityOfPOCreated").AsInt32().Nullable().WithDefaultValue(0)
           .AddColumn("IsPOComplete").AsBoolean().WithDefaultValue(false);


        }
    }
}