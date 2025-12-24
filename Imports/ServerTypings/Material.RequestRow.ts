namespace Indotalent.Material {
    export interface RequestRow {
        Id?: number;
        Number?: string;
        Description?: string;
        RequestDate?: string;
        ProjectId?: number;
        ProjectName?: string;
        DeliveryDate?: string;
        IsPOComplete?: boolean;
        IsIssueCreated?: boolean;
        ItemList?: RequestDetailRow[];
        TotalQtyRequest?: number;
        Total?: number;
        CommentList?: MaterialRequestTrackingRow[];
        StatusList?: MaterialRequestStatusRow[];
        TenantId?: number;
        TenantName?: string;
        RequestStatus?: Web.Modules.Material.Request.RequestStatus;
        ProjectMaterialRequestId?: number;
        InsertUserId?: number;
        InsertDate?: string;
        UpdateUserId?: number;
        UpdateDate?: string;
    }

    export namespace RequestRow {
        export const idProperty = 'Id';
        export const nameProperty = 'Number';
        export const localTextPrefix = 'Material.Request';
        export const lookupKey = 'Material.Request';

        export function getLookup(): Q.Lookup<RequestRow> {
            return Q.getLookup<RequestRow>('Material.Request');
        }
        export const deletePermission = 'Material:Request';
        export const insertPermission = 'Material:Request';
        export const readPermission = 'Material:Request';
        export const updatePermission = 'Material:Request';

        export declare const enum Fields {
            Id = "Id",
            Number = "Number",
            Description = "Description",
            RequestDate = "RequestDate",
            ProjectId = "ProjectId",
            ProjectName = "ProjectName",
            DeliveryDate = "DeliveryDate",
            IsPOComplete = "IsPOComplete",
            IsIssueCreated = "IsIssueCreated",
            ItemList = "ItemList",
            TotalQtyRequest = "TotalQtyRequest",
            Total = "Total",
            CommentList = "CommentList",
            StatusList = "StatusList",
            TenantId = "TenantId",
            TenantName = "TenantName",
            RequestStatus = "RequestStatus",
            ProjectMaterialRequestId = "ProjectMaterialRequestId",
            InsertUserId = "InsertUserId",
            InsertDate = "InsertDate",
            UpdateUserId = "UpdateUserId",
            UpdateDate = "UpdateDate"
        }
    }
}
