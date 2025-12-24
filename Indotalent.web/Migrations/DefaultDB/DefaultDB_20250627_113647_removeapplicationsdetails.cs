using DocumentFormat.OpenXml.Drawing.Charts;
using FluentMigrator;
using Serenity.Extensions;
using System;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20250627113647)]
    public class DefaultDB_20250627_113647_removeapplicationsdetails : ForwardOnlyMigration
    {
        public override void Up()
        {
         
            if (Schema.Table("PlanSetting").Column("ApplicationId").Exists())
            {
                Delete.ForeignKey("FK_PlanSetting_ApplicationId").OnTable("PlanSetting");
                Delete.Column("ApplicationId").FromTable("PlanSetting");
            }

           
            if (Schema.Table("AddBalance").Column("ApplicationId").Exists())
            {
                Delete.ForeignKey("FK_AddBalance_ApplicationId").OnTable("AddBalance");
                Delete.Column("ApplicationId").FromTable("AddBalance");
            }

         

            // Drop columns from Subscription
            if (Schema.Table("Subscription").Column("ApplicationCode").Exists())
            {
                Delete.Column("ApplicationCode").FromTable("Subscription");
            }

         

            // Finally, drop Applications table
            if (Schema.Table("Applications").Exists())
            {
                Delete.Table("Applications");
            }


        }
    }
}
