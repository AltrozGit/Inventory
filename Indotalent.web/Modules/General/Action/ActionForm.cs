using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.General.Forms
{
    [FormScript("General.Action")]
    [BasedOnRow(typeof(ActionRow), CheckNames = true)]
    public class ActionForm
    {
        public String ActionName { get; set; }

		[TextAreaEditor(Rows = 3)]
		public String Description { get; set; }
        
    }
}