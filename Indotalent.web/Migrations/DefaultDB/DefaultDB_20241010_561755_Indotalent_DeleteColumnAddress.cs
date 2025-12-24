using DocumentFormat.OpenXml.Drawing.Charts;
using FluentMigrator;

namespace Indotalent.Web.Migrations.DefaultDB
{
    [Migration(20241010561755)]
    public class DefaultDB_20241010_561755_Indotalent_DeleteColumnAddress : ForwardOnlyMigration
    {
        public override void Up()
        {
            Delete.Column("Address").FromTable("DueDateReminder");
            
           
        }
    }
}
