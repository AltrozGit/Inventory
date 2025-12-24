using Serenity;
using Serenity.ComponentModel;
using System;
using System.ComponentModel;

namespace Indotalent.Reminder.Forms
{
    [FormScript("Reminder.PlanSetting")]
    [BasedOnRow(typeof(PlanSettingRow), CheckNames = true)]
    public class PlanSettingForm
    {
        [Tab("General")]
        [Category("Plan Information")]

  

        [HalfWidth]
        [DisplayName("Plan Name")]
        public String PlanName { get; set; }

        [HalfWidth, LookupEditor("Product.SAASProductLookup")]
        [DisplayName("Product")]
        public Int32 ProductId { get; set; }

        [HalfWidth]
        [DisplayName("Cost")]
        public Decimal Cost { get; set; }

        [HalfWidth]
        [DisplayName("Units")]
        public Int32 Units { get; set; }

        [HalfWidth, LookupEditor("Frequency.FrequencyLookup")]
        [DisplayName("Frequency")]
        public String Frequency { get; set; }

        [HalfWidth]
        [DisplayName("Is Active")]
        public Boolean IsActive { get; set; }

        [HalfWidth, LookupEditor("Type.TypeLookup")]
        [DisplayName("Plan Type")]
        public String Type { get; set; }
    }
}
