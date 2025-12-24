using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Material.Forms
{
    [FormScript("Material.MaterialReturnDetail")]
    [BasedOnRow(typeof(MaterialReturnDetailRow), CheckNames = true)]
    public class MaterialReturnDetailForm
    {
        [Tab("General")]
        [Category("Main")]
        public Int32 ProductId { get; set; }
        [Category("Return")]
        public Double QtyReturn { get; set; }
      
    }
}