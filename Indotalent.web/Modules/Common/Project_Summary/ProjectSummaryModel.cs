
using System.Collections.Generic;

namespace Indotalent.Common
{

    public class ProjectSummaryModel
    {
		public string Currency { get; set; }

		public double AllocatedFund { get; set; }	
        public double CurrentProjectCost { get; set; }
        public double CurrentBalanceFund { get; set; }
	}
}