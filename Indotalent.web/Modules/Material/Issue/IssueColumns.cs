using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;
using Indotalent.Material;

namespace Indotalent.Material.Columns
{
    [ColumnsScript("Material.Issue")]
    [BasedOnRow(typeof(IssueRow), CheckNames = true)]
    public class IssueColumns
    {
        [EditLink]
        [SortOrder(1, descending: true)]
        [Width(200)]
        public String Number { get; set; }

        [Width(200)]
        public DateTime IssueDate { get; set; }
        [Width(200)]
        public String MaterialRequestNumber { get; set; }

        //[Width(200)]
        //public String PurchaseReceiptNumber { get; set; }

        [Width(200)]
        public String ProjectName { get; set; }
        
      
        [Width(200)]
        public Double TotalQtyIssue { get; set; }
        [Width(200)]
        public Double? Total { get; set; }




    }
}
        