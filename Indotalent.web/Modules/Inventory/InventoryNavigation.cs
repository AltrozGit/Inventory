using Serenity.Navigation;
using MyPages = Indotalent.Inventory.Pages;
using Pages1 = Indotalent.Projects.Pages;

[assembly: NavigationMenu(6900, "Inventory", icon: "fa-archive")]

[assembly: NavigationLink(6900, "Inventory/Shipper", typeof(MyPages.ShipperController), icon: "fa-folder")]
[assembly: NavigationLink(6900, "Inventory/Location", typeof(MyPages.LocationController), icon: "fa-folder")]
[assembly: NavigationLink(6900, "Inventory/Warehouse", typeof(MyPages.WarehouseController), icon: "fa-folder")]

//Moving Sales Delivery and Sales Return Into Sales Module Mayuri (dt. 1/08/2024)     

//[assembly: NavigationLink(6900, "Inventory/Sales Delivery", typeof(MyPages.SalesDeliveryController), "fa-folder")]
//[assembly: NavigationLink(6900, "Inventory/Sales Return", typeof(MyPages.SalesReturnController), icon: "fa-folder")]


//Moving Puchase Receipt and Purchase Return into Purchase module Mayuri (dt. 1/08/2024)

//[assembly: NavigationLink(6900, "Inventory/Purchase Receipt", typeof(MyPages.PurchaseReceiptController), "fa-folder")]
//[assembly: NavigationLink(6900, "Inventory/Purchase Return", typeof(MyPages.PurchaseReturnController), icon: "fa-folder")]

//[assembly: NavigationLink(5901, "Inventory/Purchase Receipt", typeof(MyPages.PurchaseReceiptController), "fa-folder")]
//[assembly: NavigationLink(5901, "Inventory/Purchase Return", typeof(MyPages.PurchaseReturnController), icon: "fa-folder")]
[assembly: NavigationLink(6900, "Inventory/Positive Adjustment", typeof(MyPages.PositiveAdjustmentController), icon: "fa-folder")]
[assembly: NavigationLink(6900, "Inventory/Negative Adjustment", typeof(MyPages.NegativeAdjustmentController), icon: "fa-folder")]
[assembly: NavigationLink(6900, "Inventory/Transfer Order", typeof(MyPages.TransferOrderController), icon: "fa-folder")]
[assembly: NavigationLink(6900, "Inventory/Stock", typeof(MyPages.StockController), icon: "fa-folder")]
[assembly: NavigationLink(6900, "Inventory/Movement", typeof(MyPages.MovementController), icon: "fa-folder")]
