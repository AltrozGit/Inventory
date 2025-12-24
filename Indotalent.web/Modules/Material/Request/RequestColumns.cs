using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;
using Indotalent.Material;
using Serenity.Data.Mapping;

namespace Indotalent.Material.Columns
{
    [ColumnsScript("Material.Request")]
    [BasedOnRow(typeof(RequestRow), CheckNames = true)]
    public class RequestColumns
    {
        [EditLink]
        [SortOrder(1, descending: true)]
        [Width(200)]
        public String Number { get; set; }
     
        [Width(200)]
        public DateTime RequestDate { get; set; }
       
       
        [Width(200)]

        public String ProjectName { get; set; }
        [Width(200)]
        public DateTime DeliveryDate { get; set; }
        [Width(200)]
        public Double TotalQtyRequest { get; set; }
        [Width(200)]
        public Double? Total { get; set; }

		[Width(150)]
		public Int32 RequestStatus { get; set; }
        [Width(150)]
        public Boolean IsPOComplete { get; set; }

        public Boolean IsIssueCreated { get; set; }


    }
}
