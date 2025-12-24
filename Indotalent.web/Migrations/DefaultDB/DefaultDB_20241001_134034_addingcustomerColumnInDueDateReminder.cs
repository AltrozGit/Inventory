using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20241001134034)]
    public class DefaultDB_20241001_134034_addingcustomerColumnInDueDateReminder : AutoReversingMigration
    {
        public override void Up()
        {

            Alter.Table("DueDateReminder").InSchema("dbo")
                .AddColumn("CustomerName").AsString(255).Nullable()
                .AddColumn("ToEmail").AsString(255).Nullable()
                      .AddColumn("CustomerId").AsInt32().Nullable()
                    .ForeignKey("FK_DueDateReminder_CustomerId", "Customer", "Id");

            
        }
    }
}
