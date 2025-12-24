using Serenity.ComponentModel;
using System.ComponentModel;

namespace Indotalent.Web.Modules.Purchase.PurchaseOrder
{
    [EnumKey("Purchase.TaxTypeTDSTCS")]
    public enum TaxTypeTDSTCS
    {
        [Description("TDS")]
        TDS = 1,
        [Description("TCS")]
        TCS = 2,
       
    }
}
