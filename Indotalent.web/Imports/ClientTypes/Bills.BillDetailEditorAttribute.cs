using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace Indotalent.Bills
{
    public partial class BillDetailEditorAttribute : CustomEditorAttribute
    {
        public const string Key = "Indotalent.Bills.BillDetailEditor";

        public BillDetailEditorAttribute()
            : base(Key)
        {
        }
    }
}
