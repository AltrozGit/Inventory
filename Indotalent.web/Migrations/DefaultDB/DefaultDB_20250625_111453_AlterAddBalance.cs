using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20250625111453)]
    public class DefaultDB_20250625_111453_AlterAddBalance : AutoReversingMigration
    {
        public override void Up()
        {


            Alter.Table("AddBalance").InSchema("dbo")
             .AddColumn("CustomerId").AsInt32().Nullable()
                    .ForeignKey("FK_AddBalance_CustomerId", "Customer", "Id");

        }
    }
}
