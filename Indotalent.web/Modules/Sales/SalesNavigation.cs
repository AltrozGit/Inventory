using Serenity.Navigation;
using MyPages = Indotalent.Sales.Pages;


[assembly: NavigationMenu(5900, "Sales", icon: "fa-shopping-cart")]
[assembly: NavigationLink(5900, "Sales/Sales Channel", typeof(MyPages.SalesChannelController), icon: "fa-folder")]
[assembly: NavigationLink(5900, "Sales/Customer", typeof(MyPages.CustomerController), icon: "fa-folder")]
[assembly: NavigationLink(5900, "Sales/Customer Order", typeof(MyPages.SalesOrderController), icon: "fa-folder")]
[assembly: NavigationLink(5900, "Sales/Invoice", typeof(MyPages.InvoiceController), icon: "fa-folder")]
[assembly: NavigationLink(5900, "Sales/Invoice Payment", typeof(MyPages.InvoicePaymentController), icon: "fa-folder")]
[assembly: NavigationLink(int.MaxValue, "Sales/Sales Delivery", typeof(MyPages.SalesDeliveryController), icon: "fa-folder")]
//[assembly: NavigationLink(int.MaxValue, "Sales/Sales Delivery Detail", typeof(MyPages.SalesDeliveryDetailController), icon: null)]
[assembly: NavigationLink(int.MaxValue, "Sales/Sales Return", typeof(MyPages.SalesReturnController), icon: "fa-folder")]
//[assembly: NavigationLink(int.MaxValue, "Sales/Sales Return Detail", typeof(MyPages.SalesReturnDetailController), icon: null)]

[assembly: NavigationLink(6900, "Sales/Sales Overview", url: "~/Sales/SalesOverview", permission: "Sales:SalesOverview", icon: "fa-folder")]
