namespace Indotalent.Material {
    export interface MaterialRequestTrackingRow {
        Id?: number;
        MaterialRequestId?: number;
        MaterialRequestNumber?: string;
        Comment?: string;
        InsertDate?: string;
        InsertUserId?: number;
        TenantId?: number;
        TenantName?: string;
        InsertUserDisplayName?: string;
    }

    export namespace MaterialRequestTrackingRow {
        export const idProperty = 'Id';
        export const localTextPrefix = 'Material.MaterialRequestTracking';
        export const lookupKey = 'Material.MaterialRequestTracking';

        export function getLookup(): Q.Lookup<MaterialRequestTrackingRow> {
            return Q.getLookup<MaterialRequestTrackingRow>('Material.MaterialRequestTracking');
        }
        export const deletePermission = 'Material:MaterialRequestTracking';
        export const insertPermission = 'Material:MaterialRequestTracking';
        export const readPermission = 'Material:MaterialRequestTracking';
        export const updatePermission = 'Material:MaterialRequestTracking';

        export declare const enum Fields {
            Id = "Id",
            MaterialRequestId = "MaterialRequestId",
            MaterialRequestNumber = "MaterialRequestNumber",
            Comment = "Comment",
            InsertDate = "InsertDate",
            InsertUserId = "InsertUserId",
            TenantId = "TenantId",
            TenantName = "TenantName",
            InsertUserDisplayName = "InsertUserDisplayName"
        }
    }
}
