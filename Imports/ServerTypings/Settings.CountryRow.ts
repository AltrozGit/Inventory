namespace Indotalent.Settings {
    export interface CountryRow {
        Id?: number;
        Name?: string;
        CountryCode?: string;
    }

    export namespace CountryRow {
        export const idProperty = 'Id';
        export const nameProperty = 'Name';
        export const localTextPrefix = 'Settings.Country';
        export const lookupKey = 'Settings.Country';

        export function getLookup(): Q.Lookup<CountryRow> {
            return Q.getLookup<CountryRow>('Settings.Country');
        }
        export const deletePermission = 'Settings:Country';
        export const insertPermission = 'Settings:Country';
        export const readPermission = 'Settings:Country';
        export const updatePermission = 'Settings:Country';

        export declare const enum Fields {
            Id = "Id",
            Name = "Name",
            CountryCode = "CountryCode"
        }
    }
}
