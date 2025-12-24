using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Purchase.Columns
{
    [ColumnsScript("Purchase.PaymentTerm")]
    [BasedOnRow(typeof(PaymentTermRow), CheckNames = true)]
    public class PaymentTermColumns
    {
		[EditLink]
		public String TermName { get; set; }
		public String TermNameCode { get; set; }
        [Width(100)]
        public Boolean IsActive { get; set; }
		public Int32 TenantId { get; set; }
	}
}