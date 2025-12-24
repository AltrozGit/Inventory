using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20240723130001)]
    public class DefaultDB_20240723_130001_AddNotesInProjectExpense : AutoReversingMigration
    {
        public override void Up()
        {
            Alter.Table("ProjectExpense").InSchema("dbo")
               
                .AddColumn("Notes").AsString().Nullable();
        }
    }
}