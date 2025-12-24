namespace Indotalent.Merchandise {
    export interface ConfigurationRow {
        Id?: number;
        Description?: string;
        Key?: string;
        Value?: string;
        InsertDate?: string;
        InsertUserId?: number;
        UpdateDate?: string;
        UpdateUserId?: number;
        TenantId?: number;
    }

    export namespace ConfigurationRow {
        export const idProperty = 'Id';
        export const nameProperty = 'Description';
        export const localTextPrefix = 'Merchandise.Configuration';
        export const deletePermission = 'Merchandise:Configuration';
        export const insertPermission = 'Merchandise:Configuration';
        export const readPermission = 'Merchandise:Configuration';
        export const updatePermission = 'Merchandise:Configuration';

        export declare const enum Fields {
            Id = "Id",
            Description = "Description",
            Key = "Key",
            Value = "Value",
            InsertDate = "InsertDate",
            InsertUserId = "InsertUserId",
            UpdateDate = "UpdateDate",
            UpdateUserId = "UpdateUserId",
            TenantId = "TenantId"
        }
    }
}
