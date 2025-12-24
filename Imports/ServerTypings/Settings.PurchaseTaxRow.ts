namespace Indotalent.Settings {
    export interface PurchaseTaxRow {
        Id?: number;
        Name?: string;
        Description?: string;
        TaxRatePercentage?: number;
        TenantId?: number;
        TenantName?: string;
        TaxType?: Web.Common.PurchaseTaxType;
        SGST?: number;
        CGST?: number;
        IGST?: number;
        InsertUserId?: number;
        InsertDate?: string;
        UpdateUserId?: number;
        UpdateDate?: string;
    }

    export namespace PurchaseTaxRow {
        export const idProperty = 'Id';
        export const nameProperty = 'Name';
        export const localTextPrefix = 'Settings.PurchaseTax';
        export const lookupKey = 'Settings.PurchaseTax';

        export function getLookup(): Q.Lookup<PurchaseTaxRow> {
            return Q.getLookup<PurchaseTaxRow>('Settings.PurchaseTax');
        }
        export const deletePermission = 'Settings:PurchaseTax';
        export const insertPermission = 'Settings:PurchaseTax';
        export const readPermission = 'Settings:PurchaseTax';
        export const updatePermission = 'Settings:PurchaseTax';

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
