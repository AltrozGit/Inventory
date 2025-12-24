using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Material.Columns
{
    [ColumnsScript("Material.RequestDetail")]
    [BasedOnRow(typeof(RequestDetailRow), CheckNames = true)]
    public class RequestDetailColumns
    {
		[EditLink]
        public String ProductName { get; set; }
        [Width(100)]
        public String UomName { get; set; }

        [Width(200)]
        public String InternalCode { get; set; }

        //[Width(80)]
        // public String SacName1 { get; set; }

        //[Width(80)]
        //public String HsnName1 { get; set; }
        public Double QtyRequest { get; set; }
        [Width(150)]
        public Double? PurchasePrice { get; set; }
        public Double SubTotal { get; set; }
        [Width(150)]
        public Int32 QuanityOfPOCreated { get; set; }
        [Width(150)]
        public Boolean IsPOComplete { get; set; }

        

    }
}