using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace Indotalent.Material_Request
{
    public partial class MaterialRequestDetailEditorAttribute : CustomEditorAttribute
    {
        public const string Key = "Indotalent.Material_Request.MaterialRequestDetailEditor";

        public MaterialRequestDetailEditorAttribute()
            : base(Key)
        {
        }
    }
}
