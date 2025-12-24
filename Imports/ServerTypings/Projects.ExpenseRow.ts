namespace Indotalent.Projects {
    export interface ExpenseRow {
        Id?: number;
        Name?: string;
        Description?: string;
        TenantId?: number;
        TenantName?: string;
        InsertUserId?: number;
        InsertDate?: string;
        UpdateUserId?: number;
        UpdateDate?: string;
    }

    export namespace ExpenseRow {
        export const idProperty = 'Id';
        export const nameProperty = 'Name';
        export const localTextPrefix = 'Projects.Expense';
        export const lookupKey = 'Projects.Expense';

        export function getLookup(): Q.Lookup<ExpenseRow> {
            return Q.getLookup<ExpenseRow>('Projects.Expense');
        }
        export const deletePermission = 'Projects:Expense';
        export const insertPermission = 'Projects:Expense';
        export const readPermission = 'Projects:Expense';
        export const updatePermission = 'Projects:Expense';

        export declare const enum Fields {
            Id = "Id",
            Name = "Name",
            Description = "Description",
            TenantId = "TenantId",
            TenantName = "TenantName",
            InsertUserId = "InsertUserId",
            InsertDate = "InsertDate",
            UpdateUserId = "UpdateUserId",
            UpdateDate = "UpdateDate"
        }
    }
}
