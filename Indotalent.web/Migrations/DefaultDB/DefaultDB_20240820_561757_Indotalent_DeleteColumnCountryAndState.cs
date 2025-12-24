using DocumentFormat.OpenXml.Drawing.Charts;
using FluentMigrator;

namespace Indotalent.Web.Migrations.DefaultDB
{
    [Migration(20240820561757)]
    public class DefaultDB_20240820_561757_Indotalent_DeleteColumnCountryAndState : ForwardOnlyMigration
    {
        public override void Up()
        {
            Delete.Column("State").FromTable("Tenant");
            
            Delete.Column("State").FromTable("Vendor");
        }
    }
}
