using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20250417132848)]
    public class DefaultDB_20250417_132848_RemoveFkColumnProjectIdBillTable : ForwardOnlyMigration
    {
        public override void Up()
        {
            Delete.ForeignKey("FK_Bill_ProjectId")

               .OnTable("Bill");


        }
    }
}

    