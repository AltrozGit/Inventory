namespace Indotalent.Purchase {
    export interface PurchaseOrderRow {
        Id?: number;
        Number?: string;
        MaterialRequestId?: number;
        MaterialRequestNumber?: string;
        ProcurementGroup?: string;
        VendorId?: number;
        QuotationReferenceNumber?: string;
        OrderDate?: string;
        IsPRCreate?: boolean;
        Description?: string;
        DispatchedBy?: string;
        DispatchedTo?: string;
        DispatchDetails?: string;
        SubTotal?: number;
        Discount?: number;
        BeforeTax?: number;
        TaxAmount?: number;
        SGST?: number;
        CGST?: number;
        IGST?: number;
        TDS?: number;
        TCS?: number;
        TaxType?: Web.Modules.Purchase.PurchaseOrder.TaxTypeTDSTCS;
        TcsTdsTaxAmount?: number;
        Total?: number;
        FinalTotalPostTDS_TCS?: number;
        OtherCharge?: number;
        VendorName?: string;
        VendorStreet?: string;
        VendorCity?: string;
        VendorCountry?: number;
        VendorCountryName?: string;
        VendorState?: number;
        VendorStateName?: string;
        TenantState?: number;
        VendorZipCode?: string;
        VendorPhone?: string;
        VendorEmail?: string;
        VendorGSTNumber?: string;
        VendorAccountNumber?: string;
        VendorIFSCCode?: string;
        UploadQuotation?: string;
        CurrencyName?: string;
        TenantId?: number;
        TenantName?: string;
        ItemList?: PurchaseOrderDetailRow[];
        BillList?: Bills.BillRow[];
        ProjectId?: number;
        ProjectName?: string;
        IsBillGenerated?: boolean;
        IsBillCreated?: boolean;
        Status?: Web.Modules.Purchase.PurchaseOrder.Status;
        InsertUserId?: number;
        InsertDate?: string;
        UpdateUserId?: number;
        UpdateDate?: string;
    }

    export namespace PurchaseOrderRow {
        export const idProperty = 'Id';
        export const nameProperty = 'Number';
        export const localTextPrefix = 'Purchase.PurchaseOrder';
        export const lookupKey = 'Purchase.PurchaseOrder';

        export function getLookup(): Q.Lookup<PurchaseOrderRow> {
            return Q.getLookup<PurchaseOrderRow>('Purchase.PurchaseOrder');
        }
        export const deletePermission = 'Purchase:PurchaseOrder';
        export const insertPermission = 'Purchase:PurchaseOrder';
        export const readPermission = 'Purchase:PurchaseOrder';
        export const updatePermission = 'Purchase:PurchaseOrder';

        export declare const enum Fields {
            Id = "Id",
            Number = "Number",
            MaterialRequestId = "MaterialRequestId",
            MaterialRequestNumber = "MaterialRequestNumber",
            ProcurementGroup = "ProcurementGroup",
            VendorId = "VendorId",
            QuotationReferenceNumber = "QuotationReferenceNumber",
            OrderDate = "OrderDate",
            IsPRCreate = "IsPRCreate",
            Description = "Description",
            DispatchedBy = "DispatchedBy",
            DispatchedTo = "DispatchedTo",
            DispatchDetails = "DispatchDetails",
            SubTotal = "SubTotal",
            Discount = "Discount",
            BeforeTax = "BeforeTax",
            TaxAmount = "TaxAmount",
            SGST = "SGST",
            CGST = "CGST",
            IGST = "IGST",
            TDS = "TDS",
            TCS = "TCS",
            TaxType = "TaxType",
            TcsTdsTaxAmount = "TcsTdsTaxAmount",
            Total = "Total",
            FinalTotalPostTDS_TCS = "FinalTotalPostTDS_TCS",
            OtherCharge = "OtherCharge",
            VendorName = "VendorName",
            VendorStreet = "VendorStreet",
            VendorCity = "VendorCity",
            VendorCountry = "VendorCountry",
            VendorCountryName = "VendorCountryName",
            VendorState = "VendorState",
            VendorStateName = "VendorStateName",
            TenantState = "TenantState",
            VendorZipCode = "VendorZipCode",
            VendorPhone = "VendorPhone",
            VendorEmail = "VendorEmail",
            VendorGSTNumber = "VendorGSTNumber",
            VendorAccountNumber = "VendorAccountNumber",
            VendorIFSCCode = "VendorIFSCCode",
            UploadQuotation = "UploadQuotation",
            CurrencyName = "CurrencyName",
            TenantId = "TenantId",
            TenantName = "TenantName",
            ItemList = "ItemList",
            BillList = "BillList",
            ProjectId = "ProjectId",
            ProjectName = "ProjectName",
            IsBillGenerated = "IsBillGenerated",
            IsBillCreated = "IsBillCreated",
            Status = "Status",
            InsertUserId = "InsertUserId",
            InsertDate = "InsertDate",
            UpdateUserId = "UpdateUserId",
            UpdateDate = "UpdateDate"
        }
    }
}
