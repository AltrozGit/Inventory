

using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20250324125855)]
    public class DefaultDB_20250324125855_DeleteOldColumnHSNandSAC_UnderHSNSACTbl : ForwardOnlyMigration
    {
        public override void Up()
        {

            Execute.Sql("UPDATE dbo.HSN SET HsnCode = [HSN Code], HsnDescription = [HSN Description], HsnName = [HSN Name]");
            Execute.Sql("UPDATE dbo.SAC SET SacCode = [SAC Code], SacDescription = [SAC Description], SacName = [SAC Name]");



            Delete.Column("HSN Code")
            .FromTable("HSN");

            Delete.Column("HSN Description")
           .FromTable("HSN");

            Delete.Column("HSN Name")
           .FromTable("HSN");

            Delete.Column("SAC Code")
         .FromTable("SAC");

            Delete.Column("SAC Description")
         .FromTable("SAC");

            Delete.Column("SAC Name")
         .FromTable("SAC");



        }
    }
}
