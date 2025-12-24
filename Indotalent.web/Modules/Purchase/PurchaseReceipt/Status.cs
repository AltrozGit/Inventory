using Serenity.ComponentModel;
using System.ComponentModel;

namespace Indotalent.Web.Modules.Purchase.PurchaseReceipt
{
	[EnumKey("PurchaseOrder.PurchaseReceiptStatus")]
	public enum Status
	{
		[Description("Open")]
		Pending = 1,
		[Description("Closed")]
		Complete = 2,
		
		


	}

}
