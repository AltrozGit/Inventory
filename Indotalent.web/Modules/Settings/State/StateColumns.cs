using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Settings.Columns
{
    [ColumnsScript("Settings.State")]
    [BasedOnRow(typeof(StateRow), CheckNames = true)]
    public class StateColumns
    {
        [EditLink]
        [Width(100)]
        public String StateCode { get; set; }
        [EditLink]
        public String Name { get; set; }
        public String CountryName { get; set; }
    }
}