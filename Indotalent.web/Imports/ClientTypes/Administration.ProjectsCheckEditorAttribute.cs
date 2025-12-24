using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace Indotalent.Administration
{
    public partial class ProjectsCheckEditorAttribute : CustomEditorAttribute
    {
        public const string Key = "Indotalent.Administration.ProjectsCheckEditor";

        public ProjectsCheckEditorAttribute()
            : base(Key)
        {
        }
    }
}
