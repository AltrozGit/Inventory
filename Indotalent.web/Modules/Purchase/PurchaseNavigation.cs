using Serenity.Navigation;
using MyPages = Indotalent.Purchase.Pages;


[assembly: NavigationMenu(5901, "Purchase", icon: "fa-shopping-bag")]
//[assembly: NavigationMenu(5901, "Bills", icon: "fa-dollar")]
[assembly: NavigationLink(5901, "Purchase/Vendor", typeof(MyPages.VendorController), icon: "fa-folder")]
[assembly: NavigationLink(4901, "Purchase/Purchase Order", typeof(MyPages.PurchaseOrderController), "fa-folder")]
//[assembly: NavigationLink(5901, "Purchase/Bill", typeof(MyPages.BillController), icon: "fa-folder")]
//[assembly: NavigationLink(5901, "Purchase/Bill Payment", typeof(MyPages.BillPaymentController), "fa-folder")]
[assembly: NavigationLink(int.MaxValue, "Purchase/Purchase Receipt", typeof(MyPages.PurchaseReceiptController), icon: "fa-folder")]
//[assembly: NavigationLink(int.MaxValue, "Purchase/Purchase Receipt Detail", typeof(MyPages.PurchaseReceiptDetailController), icon: null)]
[assembly: NavigationLink(int.MaxValue, "Purchase/Purchase Return", typeof(MyPages.PurchaseReturnController), icon: "fa-folder")]
//[assembly: NavigationLink(int.MaxValue, "Purchase/Purchase Return Detail", typeof(MyPages.PurchaseReturnDetailController), icon: null)]
[assembly: NavigationLink(int.MaxValue, "Purchase/Payment Term", typeof(MyPages.PaymentTermController), icon: "fa-folder")]