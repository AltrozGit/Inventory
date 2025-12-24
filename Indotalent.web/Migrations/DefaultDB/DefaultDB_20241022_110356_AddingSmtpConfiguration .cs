using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20241022110356)]
    public class DefaultDB_20241022_110356_AddingSmtpConfiguration : AutoReversingMigration
    {
        public override void Up()
        {


            Create.Table("SmtpConfiguration")
                   .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
                   .WithColumn("Host").AsString(255).NotNullable() // Host for SMTP
                   .WithColumn("Port").AsInt32().NotNullable() // SMTP Port
                   .WithColumn("FromAddress").AsString(255).NotNullable() // From Address
                   .WithColumn("UserName").AsString(255).NotNullable() // SMTP User Name
                   .WithColumn("Password").AsString(255).NotNullable() // SMTP Password
                   .WithColumn("EnableSsl").AsBoolean().NotNullable().WithDefaultValue(false)
                  

                   // SSL Enable Flag
                   .WithColumn("Description").AsString(1000).Nullable() // Description (optional)
                   .WithColumn("Address").AsString(255).Nullable() // Address (optional)
                   .WithColumn("Phone").AsString(50).Nullable() // Phone number (optional)
                   .WithColumn("TenantId").AsInt32().NotNullable() // Tenant ID
                     .WithColumn("InsertDate").AsDateTime().Nullable()
                .WithColumn("InsertUserId").AsInt32().Nullable()
                .WithColumn("UpdateDate").AsDateTime().Nullable()
                .WithColumn("UpdateUserId").AsInt32().Nullable()
                  
                   .WithColumn("SourceSystem").AsString(50).NotNullable(); // Source system





        }
    }
}
