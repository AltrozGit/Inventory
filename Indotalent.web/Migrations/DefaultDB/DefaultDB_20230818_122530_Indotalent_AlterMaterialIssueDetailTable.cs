using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20230818122530)]
    public class DefaultDB_20230818_122530_Indotalent_AlterMaterialIssueDetailTable : AutoReversingMigration
    {
        public override void Up()
        {

            Alter.Table("MaterialIssueDetail").InSchema("dbo")
               .AddColumn("PurchasePrice").AsDouble().Nullable();


			
        }

    }
}