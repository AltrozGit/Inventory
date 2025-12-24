
using System;
using System.Collections.Generic;

namespace Indotalent.Common.DashboardInventory
{

    public class DashboardPageModel
    {
        public class MonthlyQty
        {
            public string Month { get; set; } = DateTime.Now.ToString("MMM");
            public double Qty { get; set; } = 0;
        }

        public class Kpi
        {
            public string Name { get; set; } = DateTime.Now.ToString("MMM");
            public int Value { get; set; } = 0;
        }

        public class Grouped
		{
            public string Key { get; set; }
            public double Value { get; set; }
		}

        public MonthlyQty CurrentMonthSalesDelivery { get; set; }
        public MonthlyQty CurrentMonthSalesReturn { get; set; }
        public MonthlyQty CurrentMonthPurchaseReceipt { get; set; }
        public MonthlyQty CurrentMonthPurchaseReturn { get; set; }
        public MonthlyQty CurrentMonthPositiveAdjustment { get; set; }
        public MonthlyQty CurrentMonthNegativeAdjustment { get; set; }
        public Kpi CurrentMonthSalesDeliveryPercentage { get; set; }
        public Kpi CurrentMonthPurchaseReceiptPercentage { get; set; }
        public List<MonthlyQty> PurchaseGraph { get; set; }
        public List<MonthlyQty> SalesGraph { get; set; }
        public Kpi PurchaseKPI1 { get; set; }
        public Kpi PurchaseKPI2 { get; set; }
        public Kpi PurchaseKPI3 { get; set; }
        public Kpi SalesKPI1 { get; set; }
        public Kpi SalesKPI2 { get; set; }
        public Kpi SalesKPI3 { get; set; }
    }
}