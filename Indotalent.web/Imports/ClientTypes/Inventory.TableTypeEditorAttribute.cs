using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace Indotalent.Inventory
{
    public partial class TableTypeEditorAttribute : CustomEditorAttribute
    {
        public const string Key = "Indotalent.Inventory.TableTypeEditor";

        public TableTypeEditorAttribute()
            : base(Key)
        {
        }
    }
}
