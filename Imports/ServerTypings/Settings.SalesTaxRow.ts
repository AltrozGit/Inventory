namespace Indotalent.Settings {
    export interface SalesTaxRow {
        Id?: number;
        Name?: string;
        Description?: string;
        TaxRatePercentage?: number;
        TenantId?: number;
        TenantName?: string;
        TaxType?: Web.Common.SalesTaxType;
        SGST?: number;
        CGST?: number;
        IGST?: number;
        InsertUserId?: number;
        InsertDate?: string;
        UpdateUserId?: number;
        UpdateDate?: string;
    }

    export namespace SalesTaxRow {
        export const idProperty = 'Id';
        export const nameProperty = 'Name';
        export const localTextPrefix = 'Settings.SalesTax';
        export const lookupKey = 'Settings.SalesTax';

        export function getLookup(): Q.Lookup<SalesTaxRow> {
            return Q.getLookup<SalesTaxRow>('Settings.SalesTax');
        }
        export const deletePermission = 'Settings:SalesTax';
        export const insertPermission = 'Settings:SalesTax';
        export const readPermission = 'Settings:SalesTax';
        export const updatePermission = 'Settings:SalesTax';

        export declare const enum Fields {
            Id = "Id",
            Name = "Name",
            Description = "Description",
            TaxRatePercentage = "TaxRatePercentage",
            TenantId = "TenantId",
            TenantName = "TenantName",
            TaxType = "TaxType",
            SGST = "SGST",
            CGST = "CGST",
            IGST = "IGST",
            InsertUserId = "InsertUserId",
            InsertDate = "InsertDate",
            UpdateUserId = "UpdateUserId",
            UpdateDate = "UpdateDate"
        }
    }
}
