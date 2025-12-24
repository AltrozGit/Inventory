using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Settings.Columns
{
    [ColumnsScript("Settings.Country")]
    [BasedOnRow(typeof(CountryRow), CheckNames = true)]
    public class CountryColumns
    {
        [EditLink]
        [Width(100)]
        public String CountryCode { get; set; }
        [EditLink]
        [Width(150)]
        public String Name { get; set; }
    }
}