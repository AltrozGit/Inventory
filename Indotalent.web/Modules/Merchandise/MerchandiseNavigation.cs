using Serenity.Navigation;
using MyPages = Indotalent.Merchandise.Pages;

[assembly: NavigationMenu(8900, "Merchandise", icon: "fa-th")]
[assembly: NavigationLink(8900, "Merchandise/Uom", typeof(MyPages.UomController), icon: "fa-folder")]
[assembly: NavigationLink(8900, "Merchandise/Size", typeof(MyPages.SizeController), icon: "fa-folder")]
[assembly: NavigationLink(8900, "Merchandise/Colour", typeof(MyPages.ColourController), icon: "fa-folder")]
[assembly: NavigationLink(8900, "Merchandise/Flavour", typeof(MyPages.FlavourController), icon: "fa-folder")]
[assembly: NavigationLink(6900, "Merchandise/Brand", typeof(MyPages.BrandController), icon: "fa-folder")]
[assembly: NavigationLink(7900, "Merchandise/Category", typeof(MyPages.CategoryController), icon: "fa-folder")]
[assembly: NavigationLink(5900, "Merchandise/Product", typeof(MyPages.ProductController), icon: "fa-folder")]
//[assembly: NavigationLink(5900, "Merchandise/InternalCode", typeof(MyPages.ProductController), icon: "fa-folder")]
[assembly: NavigationLink(int.MaxValue, "Merchandise/HSN", typeof(MyPages.HSNController), icon: "fa-folder")]
[assembly: NavigationLink(int.MaxValue, "Merchandise/SAC", typeof(MyPages.SACController), icon: "fa-folder")]
[assembly: NavigationLink(int.MaxValue, "Merchandise/Configuration", typeof(MyPages.ConfigurationController), icon: null)]
