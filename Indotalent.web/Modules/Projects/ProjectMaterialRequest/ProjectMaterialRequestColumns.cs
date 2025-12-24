using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Projects.Columns
{
    [ColumnsScript("Projects.ProjectMaterialRequest")]
    [BasedOnRow(typeof(ProjectMaterialRequestRow), CheckNames = true)]
    public class ProjectMaterialRequestColumns
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
        public Double? Total {  get; set; }

		[Width(150)]
		public Int32 RequestStatus { get; set; }


	}
}