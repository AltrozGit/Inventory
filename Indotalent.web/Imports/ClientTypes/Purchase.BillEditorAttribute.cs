using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace Indotalent.Purchase
{
    public partial class BillEditorAttribute : CustomEditorAttribute
    {
        public const string Key = "Indotalent.Bills.BillEditor";

        public BillEditorAttribute()
            : base(Key)
        {
        }
    }
}
