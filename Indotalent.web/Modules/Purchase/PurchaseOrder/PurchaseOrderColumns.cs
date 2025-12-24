using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;
using Indotalent.Web.Modules.Purchase.PurchaseOrder;

namespace Indotalent.Purchase.Columns
{
    [ColumnsScript("Purchase.PurchaseOrder")]
    [BasedOnRow(typeof(PurchaseOrderRow), CheckNames = true)]
    public class PurchaseOrderColumns
    {
        [EditLink]
        [SortOrder(1, descending: true)]
        [Width(200)]
        public String Number { get; set; }
        [Width(200)]
        public DateTime OrderDate { get; set; }

        [Width(200)]
        public String VendorName { get; set; }
		[Width(200)]
		//public String MaterialRequestNumber { get; set; }
		//[Width(200)]
		public String ProjectName { get; set; }
		[Width(150)]

        public Double FinalTotalPostTDS_TCS { get; set; }
        [Width(150)]
        public String TenantName { get; set; }

        [Width(150)]
        public Boolean IsPRCreate { get; set; }

        [Width(150)]
        public Boolean IsBillCreated { get; set; }

        [Width(150)]
        public EnumField<Status> Status { get; set; }

    }
}