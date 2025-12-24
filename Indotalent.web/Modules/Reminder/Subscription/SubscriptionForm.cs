using Serenity;
using Serenity.ComponentModel;
using System;
using System.ComponentModel;

namespace Indotalent.Reminder.Forms
{
    [FormScript("Reminder.Subscription")]
    [BasedOnRow(typeof(SubscriptionRow), CheckNames = true)]
    public class SubscriptionForm
    {
        [Tab("General")]
        [Category("Subscription Details")]

        [HalfWidth]
        [DisplayName("Product")]
        public String ProductName { get; set; }

        [HalfWidth]
        [DisplayName("Application Tenant ID")]
        public String ApplicationTenantId { get; set; }

        [HalfWidth]
        [DisplayName("Plan Name")]
        public String PlanName { get; set; }

        [HalfWidth]
        [DisplayName("Start Date")]
        public DateTime StartDate { get; set; }

        [HalfWidth]
        [DisplayName("End Date")]
        public DateTime EndDate { get; set; }

        [HalfWidth]
        [DisplayName("Active End Date")]
        public DateTime ActiveEndDate { get; set; }

        [HalfWidth]
        [DisplayName("Total Units")]
        public Int32 TotalUnits { get; set; }

        [HalfWidth]
        [DisplayName("Current Balance Units")]
        public Int32 CurrentBalanceUnits { get; set; }

        [HalfWidth]
        [DisplayName("Is Active")]
        public Boolean IsActive { get; set; }

        [HalfWidth]
        [DisplayName("Is Archive")]
        public Boolean IsArchive { get; set; }
    }
}
