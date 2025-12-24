
    using Serenity;
    using Serenity.ComponentModel;
    using System;
    using Serenity.Data;
    using System.ComponentModel;

namespace Indotalent.Material.Columns
{
    [ColumnsScript("Material.MaterialReturn")]
    [BasedOnRow(typeof(MaterialReturnRow), CheckNames = false)]
    public class MaterialReturnColumns
    {


        [EditLink]
        [SortOrder(1, descending: true)]
        [Width(200)]
        public String Number { get; set; }


        [Width(200)]
        public DateTime ReturnDate { get; set; }

        [Width(200)]
        public String MaterialIssueNumber { get; set; }



        [Width(200)]
        public Double TotalQtyReturn { get; set; }

        [Width(200)]
        public String TenantName { get; set; }


    }
}
