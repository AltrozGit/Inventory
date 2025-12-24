using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;
using Indotalent.Material;

namespace Indotalent.Material.Forms
{
    [FormScript("Material.Request")]
    [BasedOnRow(typeof(RequestRow), CheckNames = true)]
    public class RequestForm
    {
        [Tab("General")]
        [Category("Material Request")]
        public String Number { get; set; }
        [TextAreaEditor(Rows = 3)]
        public String Description { get; set; }
       
      //  public Int32? ProjectMaterialRequestId { get; set; }

       [DefaultValue("now")]
        [HalfWidth]
        public DateTime RequestDate { get; set; }

        [HalfWidth]
        public DateTime DeliveryDate { get; set; }

        [Category("Project")]
        public Int32 ProjectId { get; set; }

        [Category("Detail")]
        [RequestDetailEditor]
        public List<RequestDetailRow> ItemList { get; set; }

        [Category("Summary")]
        [HalfWidth]
        public Double TotalQtyRequest { get; set; }
        [HalfWidth]
        public Double? Total { get; set; }

        [Hidden]
        public Boolean IsPOComplete { get; set; }

        [Hidden]
        public Boolean IsIssueCreated { get; set; }

        [Tab("Request Tracking")]
        [NotesEditor]
        public List<MaterialRequestTrackingRow> CommentList { get; set; }
        [Tab("Status")]
        [MaterialRequestStatusEditor]

        public List<MaterialRequestStatusRow> StatusList { get; set; }
        




    }


}
