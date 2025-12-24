using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20240806130003)]
    public class DefaultDB_20240806_130003_AddReminderInDaysAndTotalReminderCountInTenant : AutoReversingMigration
    {
        public override void Up()
        {
            Alter.Table("Tenant").InSchema("dbo")
               
                .AddColumn("ReminderInDays").AsInt32().Nullable()
                .AddColumn("TotalReminderCount ").AsInt32().Nullable();

        }
    }
}