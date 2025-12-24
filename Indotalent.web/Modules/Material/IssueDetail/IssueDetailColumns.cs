using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Material.Columns
{
    [ColumnsScript("Material.IssueDetail")]
    [BasedOnRow(typeof(IssueDetailRow), CheckNames = true)]
    public class IssueDetailColumns
    {
        [EditLink]

        public String ProductName { get; set; }
        [Width(150)]
        public Double? PurchasePrice { get; set; }
        [Width(150)]
        public Double QtyRequest { get; set; }
        [Width(100)]
        public String UomName { get; set; }
        [Width(200)]
        public String InternalCode { get; set; }

        public Double QtyIssue { get; set; }

        public Double AvailableStock { get; set; }

        public Double SubTotal { get; set; }
        //public Double Qty { get; set; }

    }
}