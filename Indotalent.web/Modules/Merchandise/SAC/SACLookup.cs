using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Web;

using Indotalent.Administration.Lookups;
using Indotalent.Merchandise;

namespace Indotalent.Web.Modules.Merchandise.SAC

{
    [LookupScript]
    public sealed class SACLookup : RowLookupScript<SACRow>
    {
        public SACLookup(ISqlConnections sqlConnections)
            : base(sqlConnections)
        {
        }
    }
}
