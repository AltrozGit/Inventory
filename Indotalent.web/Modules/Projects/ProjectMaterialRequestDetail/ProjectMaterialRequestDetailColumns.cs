using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Projects.Columns
{
    [ColumnsScript("Projects.ProjectMaterialRequestDetail")]
    [BasedOnRow(typeof(ProjectMaterialRequestDetailRow), CheckNames = true)]
    public class ProjectMaterialRequestDetailColumns
    {
		//public Boolean? IsSelected { get; set; }
		[EditLink]
		public String ProductName { get; set; }

        public Double QtyRequest { get; set; }
        [Width(200)]
        public Double PendingMaterialRequestQty { get; set; }
        [Width(150)]
        public Double? PurchasePrice { get; set; }
        public Double SubTotal { get; set; }
        [Width(80)]
        public String UomName { get; set; }

        //[Width(80)]
        //public String SacName1 { get; set; }
        [Width(150)]
        public Boolean? IsCompleteMRCreated { get; set; }

    }
}