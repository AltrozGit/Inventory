using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Web.Modules.Common.Project_Summary.IssuedStock
{
    [ColumnsScript("Common.IssueStock")]
    [BasedOnRow(typeof(IssueStockRow), CheckNames = true)]
    public class IssueStockColumns
    {

        [Width(200)]

        public string ProductName { get; set; }
        [Width(200)]

        public double QtyRequest { get; set; }
        [Width(200)]

        public double QtyIssue { get; set; }
        [Width(200)]
        public string ProjectName { get; set; }
        [Width(200)]
        public string WarehouseName { get; set; }
        [Width(200)]

        public double AvailableStock { get; set; }
    }
}