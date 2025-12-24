namespace Indotalent.Merchandise {
    export interface HSNRow {
        Id?: number;
        HsnName?: string;
        HsnCode?: string;
        HsnDescription?: string;
    }

    export namespace HSNRow {
        export const idProperty = 'Id';
        export const nameProperty = 'HsnName';
        export const localTextPrefix = 'Merchandise.HSN';
        export const lookupKey = 'Merchandise.HSN';

        export function getLookup(): Q.Lookup<HSNRow> {
            return Q.getLookup<HSNRow>('Merchandise.HSN');
        }
        export const deletePermission = 'Merchandise:Product';
        export const insertPermission = 'Merchandise:Product';
        export const readPermission = 'Merchandise:HSN';
        export const updatePermission = 'Merchandise:Product';

        export declare const enum Fields {
            Id = "Id",
            HsnName = "HsnName",
            HsnCode = "HsnCode",
            HsnDescription = "HsnDescription"
        }
    }
}
