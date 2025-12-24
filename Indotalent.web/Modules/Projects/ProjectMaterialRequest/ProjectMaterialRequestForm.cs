using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;
using Indotalent.Material;

namespace Indotalent.Projects.Forms
{
    [FormScript("Projects.ProjectMaterialRequest")]
    [BasedOnRow(typeof(ProjectMaterialRequestRow), CheckNames = true)]
    public class ProjectMaterialRequestForm
    {
        [Tab("General")]
        [Category("Material Request")]
        public String Number { get; set; }
        [TextAreaEditor(Rows = 3)]
        public String Description { get; set; }
        [DefaultValue("now")]
        [HalfWidth]
        public DateTime RequestDate { get; set; }
        [HalfWidth]
        public DateTime DeliveryDate { get; set; }

        [Category("Project")]
        public Int32 ProjectId { get; set; }
        [Category("Detail")]
        [ProjectMaterialRequestDetailEditor]
        public List<ProjectMaterialRequestDetailRow> ItemList { get; set; }

        [Category("Summary")]
        [HalfWidth]
        public Double TotalQtyRequest { get; set; }
        [HalfWidth]
        public Double? Total {  get; set; }



	}
}