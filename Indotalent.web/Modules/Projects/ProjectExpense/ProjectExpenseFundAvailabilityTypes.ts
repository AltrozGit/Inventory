
namespace Indotalent.Projects {

   
    
    export interface ProjectExpenseFundAvailabilityRequest {
        ProjectId: number;
        NewExpense: number;
    }

    export interface ProjectExpenseFundAvailabilityResponse {
        vwProjectFundLists?: vwProjectFundRow[];
        IsFundAvailable: boolean;
    }

    export interface vwProjectFundRow {
        ProjectId?: number;
        AvailableFund?: number;
        // Add any other needed fields
    }
}
    
