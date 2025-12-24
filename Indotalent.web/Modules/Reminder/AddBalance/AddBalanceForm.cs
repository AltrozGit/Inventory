using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;

namespace Indotalent.Reminder.Forms
{
    [FormScript("Reminder.AddBalance")]
    [BasedOnRow(typeof(AddBalanceRow), CheckNames = true)]
    public class AddBalanceForm
    {
        [Tab("General")]
        [Category("Customer")]
        [HalfWidth, LookupEditor(typeof(Sales.CustomerRow))]
        [DisplayName("Customer")]
        public Int32 CustomerId { get; set; }

        [Category("Plan Details")]
        [HalfWidth, LookupEditor("Product.SAASProductLookup")]
        public Int32? ProductId { get; set; }

        [HalfWidth, LookupEditor("PlanSetting:PlanSettingLookup", CascadeFrom = "ProductId")]
        [DisplayName("Plan")]
        public Int32? PlanId { get; set; }

      
        [HalfWidth, ReadOnly(true)]
        public Decimal Cost { get; set; }

        [HalfWidth, ReadOnly(true)]
        public Int32 Units { get; set; }

        [HalfWidth, ReadOnly(true)]
        public String Frequency { get; set; }

        [HalfWidth, ReadOnly(true)]
        public String Type { get; set; }

        [Category("Recharge Details")]

        [HalfWidth, DefaultValue("now")]
        public DateTime RechargeDate { get; set; }

        [HalfWidth]
        public DateTime ValidThrough { get; set; }

        [HalfWidth]
        public Int32 ApplicationTenantId { get; set; }
    }
}
