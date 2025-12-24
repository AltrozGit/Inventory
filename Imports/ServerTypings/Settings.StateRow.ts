namespace Indotalent.Settings {
    export interface StateRow {
        Id?: number;
        Name?: string;
        StateCode?: string;
        CountryId?: number;
        CountryName?: string;
    }

    export namespace StateRow {
        export const idProperty = 'Id';
        export const nameProperty = 'Name';
        export const localTextPrefix = 'Settings.State';
        export const lookupKey = 'Settings.State';

        export function getLookup(): Q.Lookup<StateRow> {
            return Q.getLookup<StateRow>('Settings.State');
        }
        export const deletePermission = 'Settings:State';
        export const insertPermission = 'Settings:State';
        export const readPermission = 'Settings:State';
        export const updatePermission = 'Settings:State';

        export declare const enum Fields {
            Id = "Id",
            Name = "Name",
            StateCode = "StateCode",
            CountryId = "CountryId",
            CountryName = "CountryName"
        }
    }
}
