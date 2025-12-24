using Indotalent.Administration;
using Indotalent.Inventory;
using Indotalent.Purchase;
using Indotalent.Sales;
using Microsoft.AspNetCore.Mvc;
using Serenity;
using Serenity.Abstractions;
using Serenity.Data;
using Serenity.Web;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Indotalent.Common.DashboardInventory.Pages
{
    [PageAuthorize]
    [ReadPermission("Dashboard:Inventory")]
    public class DashboardController : Controller
    {
        protected ISqlConnections SqlConnections { get; }
        protected IUserRetrieveService UserRetrieveService { get; }

        public DashboardController(ISqlConnections sqlConnections, IUserRetrieveService userRetrieveService)
        {
            SqlConnections = sqlConnections;
            UserRetrieveService = userRetrieveService;
        }

        [PageAuthorize, HttpGet, Route("~/")]
        public ActionResult Default()
        {
            return View(MVC.Views.Common.DashboardInventory.Default);
        }
            
        [PageAuthorize, HttpGet, Route("Dashboard/Inventory")]
        public ActionResult Index()
        {
            var dashboardPageModel = new DashboardPageModel();
            var currentMonth = DateTime.Now.Month;
            var currentYear = DateTime.Now.Year;
            var currentDay = new DateTime(currentYear, currentMonth, 1);

            var user = (UserDefinition)User.GetUserDefinition(UserRetrieveService);
            using (var connection = SqlConnections.NewFor<TenantRow>())
            {
                var tenant = connection.ById<TenantRow>(user.TenantId);

                
                dashboardPageModel.CurrentMonthSalesReturn = new DashboardPageModel.MonthlyQty();
                dashboardPageModel.CurrentMonthPurchaseReturn = new DashboardPageModel.MonthlyQty();
                dashboardPageModel.CurrentMonthPositiveAdjustment = new DashboardPageModel.MonthlyQty();
                dashboardPageModel.CurrentMonthNegativeAdjustment = new DashboardPageModel.MonthlyQty();

                var sales = connection.List<Sales.SalesDeliveryRow>(x => x
                                        .SelectTableFields()
                                        .Select(Sales.SalesDeliveryRow.Fields.ShipperName)
                                        .Where(Sales.SalesDeliveryRow.Fields.TenantId == tenant.TenantId.Value));

                var currentSales = sales.Where(x => 
                                            x.DeliveryDate.Value.Year == currentYear && 
                                            x.DeliveryDate.Value.Month == currentMonth);

                var purchase = connection.List<Purchase.PurchaseReceiptRow>(x => x
                                            .SelectTableFields()
                                            .Select(Purchase.PurchaseReceiptRow.Fields.VendorName)
                                            .Where(Purchase.PurchaseReceiptRow.Fields.TenantId == tenant.TenantId.Value));

                var currentPurchase = purchase.Where(x =>
                                                x.ReceiptDate.Value.Year == currentYear &&
                                                x.ReceiptDate.Value.Month == currentMonth);

                var transSales = currentSales.Sum(x => x.TotalQtyDelivered);
                var transPurchase = currentPurchase.Sum(x => x.TotalQtyReceive);
                var transTotal = transSales + transPurchase;
                
                dashboardPageModel.CurrentMonthSalesDeliveryPercentage = new DashboardPageModel.Kpi { Name = "Delivery", Value = (int)(transSales * 100.0 / transTotal) };
                dashboardPageModel.CurrentMonthPurchaseReceiptPercentage = new DashboardPageModel.Kpi { Name = "Receive", Value = (int)(transPurchase * 100.0 / transTotal) };

                var salesGrouped = sales.GroupBy(x => x.ShipperName)
                                        .Select(x => new DashboardPageModel.Grouped { Key = x.Key, Value = x.Sum(y => y.TotalQtyDelivered.Value) })
                                        .OrderByDescending(x => x.Value)
                                        .ToList();

                dashboardPageModel.CurrentMonthSalesDelivery = new DashboardPageModel.MonthlyQty { Month = DateTime.Now.ToString("MMM"), Qty = transSales.Value };
                dashboardPageModel.CurrentMonthPurchaseReceipt = new DashboardPageModel.MonthlyQty { Month = DateTime.Now.ToString("MMM"), Qty = transPurchase.Value };

                var salesReturn = connection.List<Sales.SalesReturnRow>(x => x
                                        .SelectTableFields()
                                        .Where(Sales.SalesReturnRow.Fields.TenantId == tenant.TenantId.Value));

                var currentSalesReturn = salesReturn.Where(x =>
                                            x.ReturnDate.Value.Year == currentYear &&
                                            x.ReturnDate.Value.Month == currentMonth);

                dashboardPageModel.CurrentMonthSalesReturn = new DashboardPageModel.MonthlyQty { Month = DateTime.Now.ToString("MMM"), Qty = currentSalesReturn.Sum(x => x.TotalQtyReturn.Value) };

                var purchaseReturn = connection.List<Purchase.PurchaseReturnRow>(x => x
                                        .SelectTableFields()
                                        .Where(Purchase.PurchaseReturnRow.Fields.TenantId == tenant.TenantId.Value));

                var currentPurchaseReturn = purchaseReturn.Where(x =>
                                            x.ReturnDate.Value.Year == currentYear &&
                                            x.ReturnDate.Value.Month == currentMonth);

                dashboardPageModel.CurrentMonthPurchaseReturn = new DashboardPageModel.MonthlyQty { Month = DateTime.Now.ToString("MMM"), Qty = currentPurchaseReturn.Sum(x => x.TotalQtyReturn.Value) };


                var positiveAdjustment = connection.List<PositiveAdjustmentRow>(x => x
                                        .SelectTableFields()
                                        .Where(PositiveAdjustmentRow.Fields.TenantId == tenant.TenantId.Value));

                var currentPositiveAdjustment = positiveAdjustment.Where(x =>
                                            x.AdjustmentDate.Value.Year == currentYear &&
                                            x.AdjustmentDate.Value.Month == currentMonth);

                dashboardPageModel.CurrentMonthPositiveAdjustment = new DashboardPageModel.MonthlyQty { Month = DateTime.Now.ToString("MMM"), Qty = currentPositiveAdjustment.Sum(x => x.TotalQty.Value) };

                var negativeAdjustment = connection.List<NegativeAdjustmentRow>(x => x
                                        .SelectTableFields()
                                        .Where(NegativeAdjustmentRow.Fields.TenantId == tenant.TenantId.Value));

                var currentNegativeAdjustment = negativeAdjustment.Where(x =>
                                            x.AdjustmentDate.Value.Year == currentYear &&
                                            x.AdjustmentDate.Value.Month == currentMonth);

                dashboardPageModel.CurrentMonthNegativeAdjustment = new DashboardPageModel.MonthlyQty { Month = DateTime.Now.ToString("MMM"), Qty = currentNegativeAdjustment.Sum(x => x.TotalQty.Value) };

                var salesKPI1 = new DashboardPageModel.Kpi
                {
                    Name = "KPI1",
                    Value = 0
                };

                var salesKPI2 = new DashboardPageModel.Kpi
                {
                    Name = "KPI2",
                    Value = 0
                };

                var salesKPI3 = new DashboardPageModel.Kpi
                {
                    Name = "KPI3",
                    Value = 0
                };

                var index = 0;
				foreach (var item in salesGrouped)
				{
					if (index == 0)
                    {
                        salesKPI1.Name = salesGrouped[0].Key;
                        salesKPI1.Value = (int)(salesGrouped[0].Value * 100.0 / salesGrouped.Sum(x => x.Value));
                    }

					if (index == 1)
                    {
                        salesKPI2.Name = salesGrouped[1].Key;
                        salesKPI2.Value = (int)(salesGrouped[1].Value * 100.0 / salesGrouped.Sum(x => x.Value));
                    }

					if (index == 2)
                    {
                        salesKPI3.Name = salesGrouped[2].Key;
                        salesKPI3.Value = (int)(salesGrouped[2].Value * 100.0 / salesGrouped.Sum(x => x.Value));
                    }

                    index++;
				}

                dashboardPageModel.SalesKPI1 = salesKPI1;
                dashboardPageModel.SalesKPI2 = salesKPI2;
                dashboardPageModel.SalesKPI3 = salesKPI3;

                var purchaseGrouped = purchase.GroupBy(x => x.VendorName)
                                        .Select(x => new DashboardPageModel.Grouped { Key = x.Key, Value = x.Sum(y => y.TotalQtyReceive.Value) })
                                        .OrderByDescending(x => x.Value)
                                        .ToList();

                var purchaseKPI1 = new DashboardPageModel.Kpi
                {
                    Name = "KPI1",
                    Value = 0
                };

                var purchaseKPI2 = new DashboardPageModel.Kpi
                {
                    Name = "KPI2",
                    Value = 0
                };

                var purchaseKPI3 = new DashboardPageModel.Kpi
                {
                    Name = "KPI3",
                    Value = 0
                };

                index = 0;
                foreach (var item in purchaseGrouped)
                {
                    if (index == 0)
                    {
                        purchaseKPI1.Name = purchaseGrouped[0].Key;
                        purchaseKPI1.Value = (int)(purchaseGrouped[0].Value * 100.0 / purchaseGrouped.Sum(x => x.Value));
                    }

                    if (index == 1)
                    {
                        purchaseKPI2.Name = purchaseGrouped[1].Key;
                        purchaseKPI2.Value = (int)(purchaseGrouped[1].Value * 100.0 / purchaseGrouped.Sum(x => x.Value));
                    }

                    if (index == 2)
                    {
                        purchaseKPI3.Name = purchaseGrouped[2].Key;
                        purchaseKPI3.Value = (int)(purchaseGrouped[2].Value * 100.0 / purchaseGrouped.Sum(x => x.Value));
                    }

                    index++;
                }

                dashboardPageModel.PurchaseKPI1 = purchaseKPI1;
                dashboardPageModel.PurchaseKPI2 = purchaseKPI2;
                dashboardPageModel.PurchaseKPI3 = purchaseKPI3;

                var purchaseMonthly = new List<DashboardPageModel.MonthlyQty>();
                var salesMonthly = new List<DashboardPageModel.MonthlyQty>();

                var endDate = new DateTime(currentYear, currentMonth, 1);
                var startDate = endDate.AddMonths(-5);
				while (startDate <= endDate)
                {
                    purchaseMonthly.Add(new DashboardPageModel.MonthlyQty { Month = startDate.ToString("yyyy-MM"), Qty = purchase.Where(x => x.ReceiptDate.Value.Year == startDate.Year && x.ReceiptDate.Value.Month == startDate.Month).Sum(x => x.TotalQtyReceive.Value) });
                    salesMonthly.Add(new DashboardPageModel.MonthlyQty { Month = startDate.ToString("yyyy-MM"), Qty = sales.Where(x => x.DeliveryDate.Value.Year == startDate.Year && x.DeliveryDate.Value.Month == startDate.Month).Sum(x => x.TotalQtyDelivered.Value) });
                    startDate = startDate.AddMonths(1);
                }

                dashboardPageModel.PurchaseGraph = purchaseMonthly;
                dashboardPageModel.SalesGraph = salesMonthly;
            }


            return View(MVC.Views.Common.DashboardInventory.DashboardIndex, dashboardPageModel);
        }
    }
}
