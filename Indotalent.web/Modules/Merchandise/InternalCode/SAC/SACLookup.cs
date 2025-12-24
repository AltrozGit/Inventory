using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Web;

using Indotalent.Administration.Lookups;
using Indotalent.Merchandise;

namespace Indotalent.Web.Modules.InternalCode.SAC
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
