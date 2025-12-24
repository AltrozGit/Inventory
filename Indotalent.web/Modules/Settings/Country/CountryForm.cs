using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Settings.Forms
{
    [FormScript("Settings.Country")]
    [BasedOnRow(typeof(CountryRow), CheckNames = true)]
    public class CountryForm
    {
        public String CountryCode { get; set; }
        public String Name { get; set; }
       
    }
}