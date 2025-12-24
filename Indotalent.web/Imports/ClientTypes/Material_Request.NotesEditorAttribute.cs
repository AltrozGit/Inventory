using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace Indotalent.Material_Request
{
    public partial class NotesEditorAttribute : CustomEditorAttribute
    {
        public const string Key = "Indotalent.Material_Request.NotesEditor";

        public NotesEditorAttribute()
            : base(Key)
        {
        }
    }
}
