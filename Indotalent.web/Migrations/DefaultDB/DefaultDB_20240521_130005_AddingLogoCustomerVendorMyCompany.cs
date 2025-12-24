using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20240521130005)]
    public class DefaultDB_20240521_130005_AddingLogoCustomerVendorMyCompany : AutoReversingMigration
    {
        public override void Up()
        {


            Alter.Table("Tenant").InSchema("dbo")
                  .AddColumn("Logo").AsString(200).Nullable();
           
            
            Alter.Table("Customer").InSchema("dbo")
                 .AddColumn("Logo").AsString(200).Nullable();
        
            
            Alter.Table("Vendor").InSchema("dbo")
                 .AddColumn("Logo").AsString(200).Nullable();


        }
    }
}