
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Web;

using Indotalent.Administration.Lookups;
using Indotalent.Merchandise;
using Indotalent.Web.Modules.Merchandise.HSN;

namespace Indotalent.Web.Modules.InternalCode.HSN
{
    [LookupScript]
    public sealed class HSNLookup : RowLookupScript<Indotalent.Merchandise.HSNRow>
    {
        public HSNLookup(ISqlConnections sqlConnections)
            : base(sqlConnections)
        {
        }
    }
}
