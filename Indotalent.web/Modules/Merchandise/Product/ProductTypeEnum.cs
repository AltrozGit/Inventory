using Serenity.ComponentModel;
using System.ComponentModel;

namespace Indotalent.Web.Modules.Merchandise.Product
{

    [EnumKey("Product.ProductType")]
    public enum ProductType
    {
        [Description("Goods")]
        Goods = 1,
        [Description("Service")]
        Service = 2

    }
}