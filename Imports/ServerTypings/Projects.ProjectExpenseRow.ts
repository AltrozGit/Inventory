namespace Indotalent.Projects {
    export interface ProjectExpenseRow {
        Id?: number;
        ProjectId?: number;
        ExpenseId?: number;
        TenantId?: number;
        ProjectName?: string;
        ExpenseName?: string;
        Notes?: string;
        Cost?: number;
        TenantName?: string;
        ExpenseDate?: string;
        InsertUserId?: number;
        InsertDate?: string;
        UpdateUserId?: number;
        UpdateDate?: string;
    }

    export namespace ProjectExpenseRow {
        export const idProperty = 'Id';
        export const localTextPrefix = 'Projects.ProjectExpense';
        export const lookupKey = 'Projects.ProjectExpense';

        export function getLookup(): Q.Lookup<ProjectExpenseRow> {
            return Q.getLookup<ProjectExpenseRow>('Projects.ProjectExpense');
        }
        export const deletePermission = 'Projects:ProjectExpense';
        export const insertPermission = 'Projects:ProjectExpense';
        export const readPermission = 'Projects:ProjectExpense';
        export const updatePermission = 'Projects:ProjectExpense';

        export declare const enum Fields {
            Id = "Id",
            ProjectId = "ProjectId",
            ExpenseId = "ExpenseId",
            TenantId = "TenantId",
            ProjectName = "ProjectName",
            ExpenseName = "ExpenseName",
            Notes = "Notes",
            Cost = "Cost",
            TenantName = "TenantName",
            ExpenseDate = "ExpenseDate",
            InsertUserId = "InsertUserId",
            InsertDate = "InsertDate",
            UpdateUserId = "UpdateUserId",
            UpdateDate = "UpdateDate"
        }
    }
}
