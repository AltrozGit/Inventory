using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Settings.Forms
{
    [FormScript("Settings.State")]
    [BasedOnRow(typeof(StateRow), CheckNames = true)]
    public class StateForm
    {

        public String StateCode { get; set; }
        public String Name { get; set; }

        [LookupEditor(typeof(CountryRow))]
       
        public Int32 CountryId { get; set; }
        

        


    }
}