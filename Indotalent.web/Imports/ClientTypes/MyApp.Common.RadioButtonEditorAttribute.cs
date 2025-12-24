using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace MyApp.Common
{
    public partial class RadioButtonEditorAttribute : CustomEditorAttribute
    {
        public const string Key = "MyApp.Common.RadioButtonEditor";

        public RadioButtonEditorAttribute()
            : base(Key)
        {
        }
    }
}
