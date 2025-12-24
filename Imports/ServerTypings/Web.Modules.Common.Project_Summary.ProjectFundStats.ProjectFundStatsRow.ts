namespace Indotalent.Web.Modules.Common.Project_Summary.ProjectFundStats {
    export interface ProjectFundStatsRow {
        ProjectId?: number;
        ProjectName?: string;
        TotalAllocatedFund?: number;
        TotalExpense?: number;
        AvailableFund?: number;
    }

    export namespace ProjectFundStatsRow {
        export const localTextPrefix = 'Web.Modules.Common.Project_Summary.ProjectFundStats.ProjectFundStats';
        export const deletePermission = '*';
        export const insertPermission = '*';
        export const readPermission = '*';
        export const updatePermission = '*';

        export declare const enum Fields {
            ProjectId = "ProjectId",
            ProjectName = "ProjectName",
            TotalAllocatedFund = "TotalAllocatedFund",
            TotalExpense = "TotalExpense",
            AvailableFund = "AvailableFund"
        }
    }
}
