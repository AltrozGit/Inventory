using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Purchase.Forms
{
    [FormScript("Purchase.PaymentTerm")]
    [BasedOnRow(typeof(PaymentTermRow), CheckNames = true)]
    public class PaymentTermForm
    {
		public String TermName { get; set; }
		public String TermNameCode { get; set; }
		public String Description { get; set; }
		public Boolean IsActive { get; set; }
	}
}