namespace Indotalent.Material {
    export interface IssueRow {
        Id?: number;
        MaterialRequestId?: number;
        MaterialRequestNumber?: string;
        Number?: string;
        Description?: string;
        IssueDate?: string;
        ProjectId?: number;
        ProjectName?: string;
        ItemList?: IssueDetailRow[];
        TotalQtyIssue?: number;
        Total?: number;
        TenantId?: number;
        WarehouseId?: number;
        WarehouseName?: string;
        TenantName?: string;
        PurchaseReceiptId?: number;
        InsertUserId?: number;
        InsertDate?: string;
        UpdateUserId?: number;
        UpdateDate?: string;
    }

    export namespace IssueRow {
        export const idProperty = 'Id';
        export const nameProperty = 'Number';
        export const localTextPrefix = 'Material.Issue';
        export const lookupKey = 'Material.Issue';

        export function getLookup(): Q.Lookup<IssueRow> {
            return Q.getLookup<IssueRow>('Material.Issue');
        }
        export const deletePermission = 'Material:Issue';
        export const insertPermission = 'Material:Issue';
        export const readPermission = 'Material:Issue';
        export const updatePermission = 'Material:Issue';

        export declare const enum Fields {
            Id = "Id",
            MaterialRequestId = "MaterialRequestId",
            MaterialRequestNumber = "MaterialRequestNumber",
            Number = "Number",
            Description = "Description",
            IssueDate = "IssueDate",
            ProjectId = "ProjectId",
            ProjectName = "ProjectName",
            ItemList = "ItemList",
            TotalQtyIssue = "TotalQtyIssue",
            Total = "Total",
            TenantId = "TenantId",
            WarehouseId = "WarehouseId",
            WarehouseName = "WarehouseName",
            TenantName = "TenantName",
            PurchaseReceiptId = "PurchaseReceiptId",
            InsertUserId = "InsertUserId",
            InsertDate = "InsertDate",
            UpdateUserId = "UpdateUserId",
            UpdateDate = "UpdateDate"
        }
    }
}
