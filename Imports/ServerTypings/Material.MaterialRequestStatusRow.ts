namespace Indotalent.Material {
    export interface MaterialRequestStatusRow {
        Id?: number;
        MaterialRequestId?: number;
        StatustId?: number;
        Description?: string;
        TenantId?: number;
        MaterialRequestNumber?: string;
        TenantName?: string;
        MaterialRequestStatusName?: string;
        InsertDate?: string;
        InsertUserId?: number;
        InsertUserDisplayName?: string;
    }

    export namespace MaterialRequestStatusRow {
        export const idProperty = 'Id';
        export const nameProperty = 'Description';
        export const localTextPrefix = 'Material.MaterialRequestStatus';
        export const lookupKey = 'Material.MaterialRequestStatus';

        export function getLookup(): Q.Lookup<MaterialRequestStatusRow> {
            return Q.getLookup<MaterialRequestStatusRow>('Material.MaterialRequestStatus');
        }
        export const deletePermission = 'Material:MaterialRequestStatus';
        export const insertPermission = 'Material:MaterialRequestStatus';
        export const readPermission = 'Material:MaterialRequestStatus';
        export const updatePermission = 'Material:MaterialRequestStatus';

        export declare const enum Fields {
            Id = "Id",
            MaterialRequestId = "MaterialRequestId",
            StatustId = "StatustId",
            Description = "Description",
            TenantId = "TenantId",
            MaterialRequestNumber = "MaterialRequestNumber",
            TenantName = "TenantName",
            MaterialRequestStatusName = "MaterialRequestStatusName",
            InsertDate = "InsertDate",
            InsertUserId = "InsertUserId",
            InsertUserDisplayName = "InsertUserDisplayName"
        }
    }
}
