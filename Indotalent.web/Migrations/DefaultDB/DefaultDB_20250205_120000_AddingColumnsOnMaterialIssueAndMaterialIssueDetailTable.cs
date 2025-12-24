using FluentMigrator;
using Serenity.Extensions;


namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20250205120000)]
    public class DefaultDB_20250205_120000_AddingColumnsOnMaterialIssueAndMaterialIssueDetailTable : AutoReversingMigration
    {
        public override void Up()
        {
            Alter.Table("MaterialIssue").InSchema("dbo")
            .AddColumn("Total").AsDouble().Nullable();


            Alter.Table("MaterialIssueDetail").InSchema("dbo")
            
            .AddColumn("SubTotal").AsDouble().Nullable();


        }
    }
}
