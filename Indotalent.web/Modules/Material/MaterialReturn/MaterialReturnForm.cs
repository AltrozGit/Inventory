using Serenity;

using Serenity.ComponentModel;

using Serenity.Data;

using System;

using System.ComponentModel;

using System.Collections.Generic;

using System.IO;

namespace Indotalent.Material.Forms

{

    [FormScript("Material.MaterialReturn")]

    [BasedOnRow(typeof(MaterialReturnRow), CheckNames = true)]

    public class MaterialReturnForm

    {

        [Tab("General")]

        [Category("Material Return")]

        [HalfWidth]

        public String Number { get; set; }

        [HalfWidth]

        public DateTime ReturnDate { get; set; }

        [HalfWidth]

        [TextAreaEditor(Rows = 3)]

        public String Description { get; set; }

     

        [HalfWidth]

        public Int32 MaterialIssueId { get; set; }

        [Category("Outbound")]

        public Int32 ProjectId { get; set; }

        public Int32 WarehouseId { get; set; }

        public Int32 LocationId { get; set; }

        [Category("Detail")]

        [MaterialReturnDetailEditor]

        public List<MaterialReturnDetailRow> ItemList { get; set; }

        [Category("Summary")]

        public Double TotalQtyReturn { get; set; }

       

    }

}
