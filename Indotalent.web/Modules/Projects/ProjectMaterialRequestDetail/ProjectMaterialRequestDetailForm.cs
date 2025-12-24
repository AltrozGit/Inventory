using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace Indotalent.Projects.Forms
{
    [FormScript("Projects.ProjectMaterialRequestDetail")]
    [BasedOnRow(typeof(ProjectMaterialRequestDetailRow), CheckNames = true)]
    public class ProjectMaterialRequestDetailForm
    {
        [Tab("General")]
        [Category("Product to Request")]
        //public Boolean? IsSelected { get; set; }
		public Int32 ProductId { get; set; }
        public Double? PurchasePrice { get; set; }
        public Int32 UomId { get; set; }

        //public Int32 SacId { get; set; }
        [Category("Quantity Request and Total Price")]
        [HalfWidth]
        public Double QtyRequest { get; set; }
        [HalfWidth]
        [Hidden]
        public Double PendingMaterialRequestQty { get; set; }

        [HalfWidth]
        public Double SubTotal { get; set; }

        [Hidden] 
        public Boolean? IsCompleteMRCreated { get; set; }
    }
}