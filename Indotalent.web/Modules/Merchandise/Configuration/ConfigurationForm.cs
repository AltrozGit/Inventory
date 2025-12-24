using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Merchandise.Forms
{
    [FormScript("Merchandise.Configuration")]
    [BasedOnRow(typeof(ConfigurationRow), CheckNames = true)]
    public class ConfigurationForm
    {
        public String Description { get; set; }
        public String Key { get; set; }
        public String Value { get; set; }
        public DateTime InsertDate { get; set; }
        public Int32 InsertUserId { get; set; }
        public DateTime UpdateDate { get; set; }
        public Int32 UpdateUserId { get; set; }
        public Int32 TenantId { get; set; }
    }
}