using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Common.DashboardInventory.Columns
{
    [ColumnsScript("Common.MostSold")]
    [BasedOnRow(typeof(MostSoldRow), CheckNames = true)]
    public class MostSoldColumns
    {
        public String ProductName { get; set; }
        public Double Qty { get; set; }
        public String Uom { get; set; }

    }
}