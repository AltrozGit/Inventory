namespace Indotalent.Merchandise {
    export interface SACRow {
        Id?: number;
        SacName?: string;
        SacCode?: string;
        SacDescription?: string;
    }

    export namespace SACRow {
        export const idProperty = 'Id';
        export const nameProperty = 'SacName';
        export const localTextPrefix = 'Merchandise.SAC';
        export const lookupKey = 'Merchandise.SAC';

        export function getLookup(): Q.Lookup<SACRow> {
            return Q.getLookup<SACRow>('Merchandise.SAC');
        }
        export const deletePermission = 'Merchandise:Product';
        export const insertPermission = 'Merchandise:Product';
        export const readPermission = 'Merchandise:SAC';
        export const updatePermission = 'Merchandise:Product';

        export declare const enum Fields {
            Id = "Id",
            SacName = "SacName",
            SacCode = "SacCode",
            SacDescription = "SacDescription"
        }
    }
}
