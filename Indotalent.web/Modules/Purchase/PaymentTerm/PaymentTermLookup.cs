using Indotalent.Purchase;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Web;

namespace Indotalent.Web.Modules.Purchase.PaymentTerm
{
	[LookupScript]
	public sealed class PaymentTermLookup : RowLookupScript<PaymentTermRow>
	{
		public PaymentTermLookup(ISqlConnections sqlConnections)
			: base(sqlConnections)
		{
		}
	}
}
