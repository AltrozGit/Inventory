using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;
using Indotalent.Settings;
using Indotalent.Web.Modules.Purchase.PaymentTerm;

namespace Indotalent.Purchase.Forms
{
	[FormScript("Purchase.Vendor")]
    [BasedOnRow(typeof(VendorRow), CheckNames = true)]
    public class VendorForm
    {
        [Tab("General")]
        [Category("Vendor Info")]

        public String Name { get; set; }
        
        [TextAreaEditor(Rows = 3)]
        public String Description { get; set; }
        
        [Category("Vendor Logo")]
        public String Logo { get; set; }

        [Category("Address")]        
        public String Street { get; set; }        
        public String City { get; set; }

        [LookupEditor(typeof(CountryRow))]
        public Int32? CountryId { get; set; }

        [LookupEditor(typeof(StateRow), CascadeFrom = "CountryId")]
        public Int32? StateId { get; set; }

        public String ZipCode { get; set; }
        public String Phone { get; set; }
        public String Email { get; set; }

		//[LookupEditor(typeof(PaymentTermLookup))]
		public Int32? PaymentTermId { get; set; }

		[Category("Financial Details")]
        public String GSTNumber { get; set; }
        public String BankName { get; set; }
        public String BankBranch { get; set; }
        public String AccountNumber { get; set; }
        public String IFSCCode { get; set; }
        public String PanNumber { get; set; }

        [Tab("Contacts")]
        [Category("List")]
        [VendorContactEditor]
        public List<VendorContactRow> ContactList { get; set; }
    }
}