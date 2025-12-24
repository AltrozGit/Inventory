namespace Indotalent.Projects {
    export interface ProjectRow {
        Id?: number;
        Name?: string;
        CustomerName?: string;
        Description?: string;
        Street?: string;
        City?: string;
        State?: string;
        ZipCode?: string;
        Phone?: string;
        Email?: string;
        TenantId?: number;
        TenantName?: string;
        TotalAllocatedFund?: number;
        TotalAvailableFund?: number;
        TotalProjectExpense?: number;
        FundList?: ProjectFundRow[];
        InsertUserId?: number;
        InsertDate?: string;
        UpdateUserId?: number;
        UpdateDate?: string;
    }

    export namespace ProjectRow {
        export const idProperty = 'Id';
        export const nameProperty = 'Name';
        export const localTextPrefix = 'Projects.Project';
        export const lookupKey = 'Projects.Project';

        export function getLookup(): Q.Lookup<ProjectRow> {
            return Q.getLookup<ProjectRow>('Projects.Project');
        }
        export const deletePermission = 'Projects:Project';
        export const insertPermission = 'Projects:Project';
        export const readPermission = 'Projects:Project';
        export const updatePermission = 'Projects:Project';

        export declare const enum Fields {
            Id = "Id",
            Name = "Name",
            CustomerName = "CustomerName",
            Description = "Description",
            Street = "Street",
            City = "City",
            State = "State",
            ZipCode = "ZipCode",
            Phone = "Phone",
            Email = "Email",
            TenantId = "TenantId",
            TenantName = "TenantName",
            TotalAllocatedFund = "TotalAllocatedFund",
            TotalAvailableFund = "TotalAvailableFund",
            TotalProjectExpense = "TotalProjectExpense",
            FundList = "FundList",
            InsertUserId = "InsertUserId",
            InsertDate = "InsertDate",
            UpdateUserId = "UpdateUserId",
            UpdateDate = "UpdateDate"
        }
    }
}
