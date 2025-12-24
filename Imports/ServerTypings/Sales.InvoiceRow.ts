namespace Indotalent.Sales {
    export interface InvoiceRow {
        Id?: number;
        Number?: string;
        Description?: string;
        InvoiceDate?: string;
        IsGenerated?: boolean;
        IsInvoiceGenerated?: boolean;
        SalesOrderId?: number;
        SalesOrderNumber?: string;
        SubTotal?: number;
        IsInvoicePaymentGenerated?: boolean;
        Discount?: number;
        BeforeTax?: number;
        TaxAmount?: number;
        Total?: number;
        OtherCharge?: number;
        TDS?: number;
        TCS?: number;
        TaxType?: Web.Modules.Sales.Invoice.TaxTypeTDSTCS;
        TcsTdsTaxAmount?: number;
        FinalTotalPostTDS_TCS?: number;
        DispatchedBy?: string;
        DispatchedTo?: string;
        PlaceOfSupply?: string;
        CustomerId?: number;
        CustomerName?: string;
        CustomerStreet?: string;
        CustomerCity?: string;
        CustomerCountry?: number;
        CustomerCountryName?: string;
        CustomerState?: number;
        CustomerStateName?: string;
        CustomerZipCode?: string;
        CustomerPhone?: string;
        CustomerEmail?: string;
        SalesGroup?: string;
        CurrencyName?: string;
        CustomerPONumber?: string;
        PONumberDate?: string;
        PyamentTerm?: string;
        TenantId?: number;
        TenantName?: string;
        TenantState?: number;
        ItemList?: InvoiceDetailRow[];
        InvoicePaymentList?: InvoicePaymentRow[];
        InsertUserId?: number;
        InsertDate?: string;
        UpdateUserId?: number;
        UpdateDate?: string;
    }

    export namespace InvoiceRow {
        export const idProperty = 'Id';
        export const nameProperty = 'Number';
        export const localTextPrefix = 'Sales.Invoice';
        export const lookupKey = 'Sales.Invoice';

        export function getLookup(): Q.Lookup<InvoiceRow> {
            return Q.getLookup<InvoiceRow>('Sales.Invoice');
        }
        export const deletePermission = 'Sales:Invoice';
        export const insertPermission = 'Sales:Invoice';
        export const readPermission = 'Sales:Invoice';
        export const updatePermission = 'Sales:Invoice';

        export declare const enum Fields {
            Id = "Id",
            Number = "Number",
            Description = "Description",
            InvoiceDate = "InvoiceDate",
            IsGenerated = "IsGenerated",
            IsInvoiceGenerated = "IsInvoiceGenerated",
            SalesOrderId = "SalesOrderId",
            SalesOrderNumber = "SalesOrderNumber",
            SubTotal = "SubTotal",
            IsInvoicePaymentGenerated = "IsInvoicePaymentGenerated",
            Discount = "Discount",
            BeforeTax = "BeforeTax",
            TaxAmount = "TaxAmount",
            Total = "Total",
            OtherCharge = "OtherCharge",
            TDS = "TDS",
            TCS = "TCS",
            TaxType = "TaxType",
            TcsTdsTaxAmount = "TcsTdsTaxAmount",
            FinalTotalPostTDS_TCS = "FinalTotalPostTDS_TCS",
            DispatchedBy = "DispatchedBy",
            DispatchedTo = "DispatchedTo",
            PlaceOfSupply = "PlaceOfSupply",
            CustomerId = "CustomerId",
            CustomerName = "CustomerName",
            CustomerStreet = "CustomerStreet",
            CustomerCity = "CustomerCity",
            CustomerCountry = "CustomerCountry",
            CustomerCountryName = "CustomerCountryName",
            CustomerState = "CustomerState",
            CustomerStateName = "CustomerStateName",
            CustomerZipCode = "CustomerZipCode",
            CustomerPhone = "CustomerPhone",
            CustomerEmail = "CustomerEmail",
            SalesGroup = "SalesGroup",
            CurrencyName = "CurrencyName",
            CustomerPONumber = "CustomerPONumber",
            PONumberDate = "PONumberDate",
            PyamentTerm = "PyamentTerm",
            TenantId = "TenantId",
            TenantName = "TenantName",
            TenantState = "TenantState",
            ItemList = "ItemList",
            InvoicePaymentList = "InvoicePaymentList",
            InsertUserId = "InsertUserId",
            InsertDate = "InsertDate",
            UpdateUserId = "UpdateUserId",
            UpdateDate = "UpdateDate"
        }
    }
}
