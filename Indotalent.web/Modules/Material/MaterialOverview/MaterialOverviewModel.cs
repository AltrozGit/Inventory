namespace Indotalent.Material
{
    public class MaterialOverviewModel
    {
        //For Material Request
        public int MaterialRequestsToday { get; set; }
        public int MaterialRequestsThisMonth { get; set; }
       // public int MaterialRequestsThisYear { get; set; }
        
        public int TotalMaterialRequests { get; set; }


        //For Issue Request
        public int MaterialIssuesToday { get; set; }
        
        public int MaterialIssuesThisMonth { get; set; }

        public int TotalMaterialIssue {  get; set; }
        //public int MaterialIssuesThisYear { get; set; }


        //For Purchase Order

        public int PurchaseOrderToday { get; set; }
        public int PurchaseOrderThisMonth { get; set; }
        public int TotalPurchaseOrder { get; set; }

        // Total count of material
        public int TotalRequestMonthCount { get; set; } 

        public int TotalRequestCount { get; set; }


    }
}