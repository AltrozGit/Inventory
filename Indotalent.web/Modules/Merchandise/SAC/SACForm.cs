using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Merchandise.Forms
{
    [FormScript("Merchandise.SAC")]
    [BasedOnRow(typeof(SACRow), CheckNames = true)]
    public class SACForm
    {
        public String SacCode { get; set; }
        public String SacDescription { get; set; }
        public String SacName { get; set; }
    }
}