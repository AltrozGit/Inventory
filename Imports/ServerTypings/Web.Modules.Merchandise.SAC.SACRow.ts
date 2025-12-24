namespace Indotalent.Web.Modules.Merchandise.SAC {
    export interface SACRow {
        Id?: number;
        SacCode?: string;
        SacDescription?: string;
    }

    export namespace SACRow {
        export const idProperty = 'Id';
        export const nameProperty = 'SacCode';
        export const localTextPrefix = 'InternalCode.SAC';
        export const deletePermission = 'InternalCode:SAC';
        export const insertPermission = 'InternalCode:SAC';
        export const readPermission = 'InternalCode:SAC';
        export const updatePermission = 'InternalCode:SAC';

        export declare const enum Fields {
            Id = "Id",
            SacCode = "SacCode",
            SacDescription = "SacDescription"
        }
    }
}
