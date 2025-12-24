using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Material.Forms
{
    [FormScript("Material.Issue")]
    [BasedOnRow(typeof(IssueRow), CheckNames = true)]
    public class IssueForm
    {
      
        [Tab("General")]
        [Category("Issue Info")]
        [HalfWidth]
        public String Number { get; set; }
        [HalfWidth]

        public Int32 MaterialRequestId { get; set; }

        [DefaultValue("now")]
        [HalfWidth]

        public DateTime IssueDate { get; set; }

       

        [HalfWidth]

        public Int32 PurchaseReceiptId { get; set; }

       

        // [HalfWidth]

        [TextAreaEditor(Rows = 3)]
        public String Description { get; set; }

        [Category("Outbound")]
		public Int32 ProjectId { get; set; }
		public Int32 WarehouseId { get; set; }

		[Category("Detail")]
        [IssueDetailEditor]
        public List<IssueDetailRow> ItemList { get; set; }

        [Category("Summary")]
        [HalfWidth]
        public Double TotalQtyIssue { get; set; }

        [HalfWidth]
        public Double? Total { get; set; }


    }
}