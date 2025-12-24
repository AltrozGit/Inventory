using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20240916141700)]
    public class DefaultDB_20240916_141700_addingFileuploadinMultiTenant : AutoReversingMigration
    {
        public override void Up()
        {

            Alter.Table("Tenant")

                .AddColumn("BulkFileUploadNumberPrefix").AsString(30).Nullable().WithDefaultValue("EmailSender")
                .AddColumn("BulkFileUploadNumberUseDate").AsBoolean().Nullable().WithDefaultValue(true)
                .AddColumn("BulkFileUploadNumberLength").AsInt16().Nullable().WithDefaultValue(16);
                
        }
    }
}
