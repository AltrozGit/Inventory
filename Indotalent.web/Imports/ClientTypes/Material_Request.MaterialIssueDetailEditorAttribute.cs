using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace Indotalent.Material_Request
{
    public partial class MaterialIssueDetailEditorAttribute : CustomEditorAttribute
    {
        public const string Key = "Indotalent.Material_Request.MaterialIssueDetailEditor";

        public MaterialIssueDetailEditorAttribute()
            : base(Key)
        {
        }
    }
}
