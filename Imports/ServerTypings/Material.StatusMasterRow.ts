namespace Indotalent.Material {
    export interface StatusMasterRow {
        Id?: number;
        MaterialRequestStatusName?: string;
        MaterialRequestStatusDescription?: string;
        TenantId?: number;
        TenantName?: string;
        InsertUserId?: number;
        InsertDate?: string;
        UpdateUserId?: number;
        UpdateDate?: string;
    }

    export namespace StatusMasterRow {
        export const idProperty = 'Id';
        export const nameProperty = 'MaterialRequestStatusName';
        export const localTextPrefix = 'Material.StatusMaster';
        export const lookupKey = 'Material.StatusMaster';

        export function getLookup(): Q.Lookup<StatusMasterRow> {
            return Q.getLookup<StatusMasterRow>('Material.StatusMaster');
        }
        export const deletePermission = 'Material:StatusMaster';
        export const insertPermission = 'Material:StatusMaster';
        export const readPermission = 'Material:StatusMaster';
        export const updatePermission = 'Material:StatusMaster';

        export declare const enum Fields {
            Id = "Id",
            MaterialRequestStatusName = "MaterialRequestStatusName",
            MaterialRequestStatusDescription = "MaterialRequestStatusDescription",
            TenantId = "TenantId",
            TenantName = "TenantName",
            InsertUserId = "InsertUserId",
            InsertDate = "InsertDate",
            UpdateUserId = "UpdateUserId",
            UpdateDate = "UpdateDate"
        }
    }
}
