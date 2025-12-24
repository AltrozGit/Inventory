using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Reminder.Forms
{
    [FormScript("Reminder.Plan")]
    [BasedOnRow(typeof(PlanRow), CheckNames = true)]
    public class PlanForm
    {
        [Tab("General")]
        [Category("Plan Information")]
        [HalfWidth]
        public String PlanName { get; set; }
        [HalfWidth]
        [LookupEditor("Product.SAASProductLookup")]
        public String Product { get; set; }
        [HalfWidth]

        public Decimal Cost { get; set; }
        [HalfWidth]

        public Int32 Units { get; set; }
        [HalfWidth]


        [LookupEditor("Frequency.FrequencyLookup")]
        public String Frequency { get; set; }
        [HalfWidth]

        public Boolean IsActive { get; set; }
        [HalfWidth]

        [LookupEditor("Type.TypeLookup")]
        public String Type { get; set; }
       
    }
}