using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Projects.Columns
{
    [ColumnsScript("Projects.Quotation")]
    [BasedOnRow(typeof(QuotationRow), CheckNames = true)]
    public class QuotationColumns
    {
       
     
        
        [EditLink]
        [SortOrder(1, descending: true)]
        public String Number { get; set; }
        [Width(150)]
        public DateTime QuotationDate { get; set; }
        public String ProjectName { get; set; }

        public Double Total { get; set; }
        public String TenantName { get; set; }
    }
}