using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace Indotalent.Projects
{
    public partial class QuotationDetailEditorAttribute : CustomEditorAttribute
    {
        public const string Key = "Indotalent.Projects.QuotationDetailEditor";

        public QuotationDetailEditorAttribute()
            : base(Key)
        {
        }
    }
}
