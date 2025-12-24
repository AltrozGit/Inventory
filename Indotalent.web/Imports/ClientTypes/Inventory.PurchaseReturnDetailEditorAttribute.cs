using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace Indotalent.Inventory
{
    public partial class PurchaseReturnDetailEditorAttribute : CustomEditorAttribute
    {
        public const string Key = "Indotalent.Inventory.PurchaseReturnDetailEditor";

        public PurchaseReturnDetailEditorAttribute()
            : base(Key)
        {
        }
    }
}
