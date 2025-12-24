using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;
using Indotalent.Settings;

namespace Indotalent.Sales.Forms
{
    [FormScript("Sales.Customer")]
    [BasedOnRow(typeof(CustomerRow), CheckNames = true)]
    public class CustomerForm
    {
        [Tab("General")]
        [Category("Customer Info")]
        public String Name { get; set; }
        [TextAreaEditor(Rows = 3)]
        public String Description { get; set; }
        [Category("Customer Logo")]
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
        [Category("Other Address")]
        public String BillingAddress { get; set; }
        public String ShippingAddress { get; set; }
        
        [Category("Financial Details")]

        public String GSTNumber { get; set; }
        [Tab("Contacts")]
        [Category("List")]
        [CustomerContactEditor]
        public List<CustomerContactRow> ContactList { get; set; }
    }
}