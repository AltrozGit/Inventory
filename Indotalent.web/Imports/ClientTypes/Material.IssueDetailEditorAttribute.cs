using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace Indotalent.Material
{
    public partial class IssueDetailEditorAttribute : CustomEditorAttribute
    {
        public const string Key = "Indotalent.Material.IssueDetailEditor";

        public IssueDetailEditorAttribute()
            : base(Key)
        {
        }
    }
}
