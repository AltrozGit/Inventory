
using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20250401113600)]
    public class DefaultDB_20250401_113600_AddColumnMaterialRequestTbl_ISPOComplete : AutoReversingMigration
    {
        public override void Up()
        {
            Alter.Table("MaterialRequest").InSchema("dbo")
           
           .AddColumn("IsPOComplete").AsBoolean().WithDefaultValue(false);


        }
    }
}