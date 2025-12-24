using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Merchandise.Forms
{
    [FormScript("Merchandise.HSN")]
    [BasedOnRow(typeof(HSNRow), CheckNames = true)]
    public class HSNForm
    {
        public String HsnCode { get; set; }
        public String HsnDescription { get; set; }
        public String HsnName { get; set; }
    }
}