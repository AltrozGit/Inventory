using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.General.Columns
{
    [ColumnsScript("General.Action")]
    [BasedOnRow(typeof(ActionRow), CheckNames = true)]
    public class ActionColumns
    {
      
        
        [EditLink]
        [Width(150)]
        public String ActionName { get; set; }
        
        
    }
}