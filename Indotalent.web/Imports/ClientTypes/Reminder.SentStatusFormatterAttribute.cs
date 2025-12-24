using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace Indotalent.Reminder
{
    public partial class SentStatusFormatterAttribute : CustomFormatterAttribute
    {
        public const string Key = "Indotalent.Reminder.SentStatusFormatter";

        public SentStatusFormatterAttribute()
            : base(Key)
        {
        }
    }
}
