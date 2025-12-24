namespace Indotalent.Projects {
    export interface QuotationRow {
        Id?: number;
        Number?: string;
        Description?: string;
        ExternalReferenceNumber?: string;
        CustomerId?: number;
        QuotationDate?: string;
        ProjectId?: number;
        SubTotal?: number;
        Discount?: number;
        BeforeTax?: number;
        TaxAmount?: number;
        Total?: number;
        OtherCharge?: number;
        CurrencyName?: string;
        CustomerName?: string;
        CustomerStreet?: string;
        CustomerCity?: string;
        CustomerCountry?: number;
        CustomerCountryName?: string;
        CustomerState?: number;
        CustomerStateName?: string;
        TenantState?: number;
        CustomerZipCode?: string;
        CustomerPhone?: string;
        CustomerEmail?: string;
        BillingAddress?: string;
        ShippingAddress?: string;
        TenantId?: number;
        ProjectName?: string;
        ItemList?: QuotationDetailRow[];
        TenantName?: string;
        Street?: string;
        City?: string;
        State?: string;
        ZipCode?: string;
        Phone?: string;
        Email?: string;
        InsertUserId?: number;
        InsertDate?: string;
        UpdateUserId?: number;
        UpdateDate?: string;
    }

    export namespace QuotationRow {
        export const idProperty = 'Id';
        export const nameProperty = 'Number';
        export const localTextPrefix = 'Projects.Quotation';
        export const lookupKey = 'Projects.Quotation';

        export function getLookup(): Q.Lookup<QuotationRow> {
            return Q.getLookup<QuotationRow>('Projects.Quotation');
        }
        export const deletePermission = 'Projects:Quotation';
        export const insertPermission = 'Projects:Quotation';
        export const readPermission = 'Projects:Quotation';
        export const updatePermission = 'Projects:Quotation';

        export declare const enum Fields {
            Id = "Id",
            Number = "Number",
            Description = "Description",
            ExternalReferenceNumber = "ExternalReferenceNumber",
            CustomerId = "CustomerId",
            QuotationDate = "QuotationDate",
            ProjectId = "ProjectId",
            SubTotal = "SubTotal",
            Discount = "Discount",
            BeforeTax = "BeforeTax",
            TaxAmount = "TaxAmount",
            Total = "Total",
            OtherCharge = "OtherCharge",
            CurrencyName = "CurrencyName",
            CustomerName = "CustomerName",
            CustomerStreet = "CustomerStreet",
            CustomerCity = "CustomerCity",
            CustomerCountry = "CustomerCountry",
            CustomerCountryName = "CustomerCountryName",
            CustomerState = "CustomerState",
            CustomerStateName = "CustomerStateName",
            TenantState = "TenantState",
            CustomerZipCode = "CustomerZipCode",
            CustomerPhone = "CustomerPhone",
            CustomerEmail = "CustomerEmail",
            BillingAddress = "BillingAddress",
            ShippingAddress = "ShippingAddress",
            TenantId = "TenantId",
            ProjectName = "ProjectName",
            ItemList = "ItemList",
            TenantName = "TenantName",
            Street = "Street",
            City = "City",
            State = "State",
            ZipCode = "ZipCode",
            Phone = "Phone",
            Email = "Email",
            InsertUserId = "InsertUserId",
            InsertDate = "InsertDate",
            UpdateUserId = "UpdateUserId",
            UpdateDate = "UpdateDate"
        }
    }
}
