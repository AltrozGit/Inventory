using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20252703172748)]
    public class DefaultDB_20252703_172748_AddColumnCustomerNameProjectTable : AutoReversingMigration
    {
        public override void Up()
        {
            Alter.Table("Project").InSchema("dbo")
             .AddColumn("CustomerName").AsString(1000).Nullable();


        }
    }
}