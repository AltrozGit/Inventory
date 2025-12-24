namespace Indotalent.Web.Modules.Common.Project_Summary.ProjectExpense {
    export interface ProjectExpensesRow {
        Id?: number;
        ProjectId?: number;
        ProjectName?: string;
        ExpenseId?: number;
        TenantId?: number;
        ExpenseName?: string;
        Cost?: number;
        TenantName?: string;
        ExpenseDate?: string;
    }

    export namespace ProjectExpensesRow {
        export const idProperty = 'Id';
        export const localTextPrefix = 'Web.Modules.Common.Project_Summary.ProjectExpense.ProjectExpenses';
        export const deletePermission = '*';
        export const insertPermission = '*';
        export const readPermission = '*';
        export const updatePermission = '*';

        export declare const enum Fields {
            Id = "Id",
            ProjectId = "ProjectId",
            ProjectName = "ProjectName",
            ExpenseId = "ExpenseId",
            TenantId = "TenantId",
            ExpenseName = "ExpenseName",
            Cost = "Cost",
            TenantName = "TenantName",
            ExpenseDate = "ExpenseDate"
        }
    }
}
