using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace Indotalent.Projects
{
    public partial class ProjectExpenseEditorAttribute : CustomEditorAttribute
    {
        public const string Key = "Indotalent.Projects.ProjectExpenseEditor";

        public ProjectExpenseEditorAttribute()
            : base(Key)
        {
        }
    }
}
