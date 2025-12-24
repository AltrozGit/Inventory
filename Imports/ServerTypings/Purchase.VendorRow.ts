namespace Indotalent.Purchase {
    export interface VendorRow {
        Id?: number;
        Name?: string;
        Address?: string;
        Description?: string;
        Street?: string;
        City?: string;
        CountryId?: number;
        CountryName?: string;
        StateId?: number;
        StateName?: string;
        ZipCode?: string;
        Phone?: string;
        Email?: string;
        PaymentTermId?: number;
        TermName?: string;
        GSTNumber?: string;
        BankName?: string;
        BankBranch?: string;
        AccountNumber?: string;
        IFSCCode?: string;
        PanNumber?: string;
        TenantId?: number;
        TenantName?: string;
        Logo?: string;
        ContactList?: VendorContactRow[];
        InsertUserId?: number;
        InsertDate?: string;
        UpdateUserId?: number;
        UpdateDate?: string;
    }

    export namespace VendorRow {
        export const idProperty = 'Id';
        export const nameProperty = 'Name';
        export const localTextPrefix = 'Purchase.Vendor';
        export const lookupKey = 'Purchase.Vendor';

        export function getLookup(): Q.Lookup<VendorRow> {
            return Q.getLookup<VendorRow>('Purchase.Vendor');
        }
        export const deletePermission = 'Purchase:Vendor';
        export const insertPermission = 'Purchase:Vendor';
        export const readPermission = 'Purchase:Vendor';
        export const updatePermission = 'Purchase:Vendor';

        export declare const enum Fields {
            Id = "Id",
            Name = "Name",
            Address = "Address",
            Description = "Description",
            Street = "Street",
            City = "City",
            CountryId = "CountryId",
            CountryName = "CountryName",
            StateId = "StateId",
            StateName = "StateName",
            ZipCode = "ZipCode",
            Phone = "Phone",
            Email = "Email",
            PaymentTermId = "PaymentTermId",
            TermName = "TermName",
            GSTNumber = "GSTNumber",
            BankName = "BankName",
            BankBranch = "BankBranch",
            AccountNumber = "AccountNumber",
            IFSCCode = "IFSCCode",
            PanNumber = "PanNumber",
            TenantId = "TenantId",
            TenantName = "TenantName",
            Logo = "Logo",
            ContactList = "ContactList",
            InsertUserId = "InsertUserId",
            InsertDate = "InsertDate",
            UpdateUserId = "UpdateUserId",
            UpdateDate = "UpdateDate"
        }
    }
}
