using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Purchase.Columns
{
    [ColumnsScript("Purchase.Vendor")]
    [BasedOnRow(typeof(VendorRow), CheckNames = true)]
    public class VendorColumns
    {
        [EditLink]
        [Width(200)]
        public String Name { get; set; }

        [Width(200)]
        public String Phone { get; set; }

        [Width(200)]
        public String Email { get; set; }

		[Width(200)]
		public Int32? TermName { get; set; }
		[Width(200)]
		public String GSTNumber { get; set; }
        [Width(200)]
        public String BankName { get; set; }
        [Width(200)]
        public String BankBranch { get; set; }
        [Width(200)]
        public String AccountNumber { get; set; }
        [Width(200)]
        public String IFSCCode { get; set; }
        [Width(200)]
        public String PanNumber { get; set; }
        [Width(200)]
        public String TenantName { get; set; }
    }
}