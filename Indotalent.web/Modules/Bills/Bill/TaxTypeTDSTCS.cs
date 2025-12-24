using Serenity.ComponentModel;
using System.ComponentModel;

namespace Indotalent.Web.Modules.Bills.Bill
{

    [EnumKey("Bill.TaxTypeTDSTCS")]
    public enum TaxTypeTDSTCS
    {
        [Description("TDS")]
        TDS = 1,
        [Description("TCS")]
        TCS = 2,

    }
}
