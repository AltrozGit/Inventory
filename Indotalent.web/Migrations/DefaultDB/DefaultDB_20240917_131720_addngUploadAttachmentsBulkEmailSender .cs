using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20240917131720)]
    public class DefaultDB_20240917_131720_addngUploadAttachmentsBulkEmailSender : AutoReversingMigration
    {
        public override void Up()
        {


            Alter.Table("BulkEmailSender").InSchema("dbo")
               .AddColumn("UploadAttachments").AsString(int.MaxValue).Nullable();


        }
    }
}
