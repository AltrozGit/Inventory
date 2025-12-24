using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Inventory.Forms
{
    [FormScript("Inventory.Location")]
    [BasedOnRow(typeof(LocationRow), CheckNames = true)]
    public class LocationForm
    {
        [Tab("General")]
        [Category("Location Info")]
        public String Name { get; set; }
        [TextAreaEditor(Rows = 3)]
        public String Description { get; set; }
    }
}