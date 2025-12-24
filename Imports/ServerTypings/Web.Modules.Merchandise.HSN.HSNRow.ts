namespace Indotalent.Web.Modules.Merchandise.HSN {
    export interface HSNRow {
        Id?: number;
        HsnCode?: string;
        HsnDescription?: string;
    }

    export namespace HSNRow {
        export const idProperty = 'Id';
        export const nameProperty = 'HsnCode';
        export const localTextPrefix = 'InternalCode.HSN';
        export const deletePermission = 'InternalCode:HSN';
        export const insertPermission = 'InternalCode:HSN';
        export const readPermission = 'InternalCode:HSN';
        export const updatePermission = 'InternalCode:HSN';

        export declare const enum Fields {
            Id = "Id",
            HsnCode = "HsnCode",
            HsnDescription = "HsnDescription"
        }
    }
}
