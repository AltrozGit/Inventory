using DocumentFormat.OpenXml.Spreadsheet;
using Indotalent.Merchandise;
using Microsoft.AspNetCore.Http;
using Serenity.Abstractions;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Web;

namespace Indotalent.Web.Modules.Reminder.PlanSetting
{
    [LookupScript("Product.SAASProductLookup")]
    public class SAASProductLookup : RowLookupScript<ProductRow>
    {
        public SAASProductLookup(ISqlConnections connections)
           : base(connections)
        {
            IdField = ProductRow.Fields.Id.PropertyName;
            TextField = ProductRow.Fields.Name.PropertyName;
        }

        protected override void PrepareQuery(SqlQuery query)
        {
            var fld = ProductRow.Fields;
            query
                .Select(fld.Id,fld.Name)
               .Where(fld.CategoryName == "SAASProducts");
        }
    }
}
