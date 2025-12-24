
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Web;

using Indotalent.Administration.Lookups;
using Indotalent.Merchandise;
using Indotalent.Web.Modules.Merchandise.HSN;

namespace Indotalent.Web.Modules.Merchandise.HSN
{
    [LookupScript]
    public sealed class HSNLookup : RowLookupScript<HSNRow>
    {
        public HSNLookup(ISqlConnections sqlConnections)
            : base(sqlConnections)
        {
        }
       
    }
}
