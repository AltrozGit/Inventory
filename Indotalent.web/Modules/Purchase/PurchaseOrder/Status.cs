using Serenity.ComponentModel;
using System.ComponentModel;

namespace Indotalent.Web.Modules.Purchase.PurchaseOrder
{
	[EnumKey("PurchaseOrder.PurchaseOrderStatus")]
	public enum Status
	{
		[Description("Pending")]
		Pending = 1,
		[Description("Complete")]
		Complete = 2,
		
		


	}

}
