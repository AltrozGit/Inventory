namespace Indotalent.Bills {
    export interface BillRow {
        Id?: number;
        Number?: string;
        Description?: string;
        ExternalReferenceNumber?: string;
        BillDate?: string;
        PurchaseOrderId?: number;
        ProjectId?: number;
        IsBillPaymentGenerated?: boolean;
        PurchaseOrderNumber?: string;
        PurchaseReceiptId?: number;
        PurchaseReceiptNumber?: string;
        SubTotal?: number;
        Discount?: number;
        BeforeTax?: number;
        TaxAmount?: number;
        TDS?: number;
        TCS?: number;
        TaxType?: Web.Modules.Bills.Bill.TaxTypeTDSTCS;
        TcsTdsTaxAmount?: number;
        Total?: number;
        FinalTotalPostTDS_TCS?: number;
        OtherCharge?: number;
        DispatchedBy?: string;
        DispatchedTo?: string;
        DispatchDetails?: string;
        VendorId?: number;
        VendorName?: string;
        VendorStreet?: string;
        VendorCity?: string;
        VendorState?: number;
        VendorStateName?: string;
        VendorZipCode?: string;
        VendorPhone?: string;
        VendorEmail?: string;
        VendorGSTNumber?: string;
        VendorAccountNumber?: string;
        VendorIFSCCode?: string;
        ProcurementGroup?: string;
        CurrencyName?: string;
        TenantId?: number;
        TenantName?: string;
        ItemList?: BillDetailRow[];
        BillPaymentList?: BillPaymentRow[];
    }

    export namespace BillRow {
        export const idProperty = 'Id';
        export const nameProperty = 'Number';
        export const localTextPrefix = 'Bills.Bill';
        export const lookupKey = 'Bills.Bill';

        export function getLookup(): Q.Lookup<BillRow> {
            return Q.getLookup<BillRow>('Bills.Bill');
        }
        export const deletePermission = 'Bills:Bill';
        export const insertPermission = 'Bills:Bill';
        export const readPermission = 'Bills:Bill';
        export const updatePermission = 'Bills:Bill';

        export declare const enum Fields {
            Id = "Id",
            Number = "Number",
            Description = "Description",
            ExternalReferenceNumber = "ExternalReferenceNumber",
            BillDate = "BillDate",
            PurchaseOrderId = "PurchaseOrderId",
            ProjectId = "ProjectId",
            IsBillPaymentGenerated = "IsBillPaymentGenerated",
            PurchaseOrderNumber = "PurchaseOrderNumber",
            PurchaseReceiptId = "PurchaseReceiptId",
            PurchaseReceiptNumber = "PurchaseReceiptNumber",
            SubTotal = "SubTotal",
            Discount = "Discount",
            BeforeTax = "BeforeTax",
            TaxAmount = "TaxAmount",
            TDS = "TDS",
            TCS = "TCS",
            TaxType = "TaxType",
            TcsTdsTaxAmount = "TcsTdsTaxAmount",
            Total = "Total",
            FinalTotalPostTDS_TCS = "FinalTotalPostTDS_TCS",
            OtherCharge = "OtherCharge",
            DispatchedBy = "DispatchedBy",
            DispatchedTo = "DispatchedTo",
            DispatchDetails = "DispatchDetails",
            VendorId = "VendorId",
            VendorName = "VendorName",
            VendorStreet = "VendorStreet",
            VendorCity = "VendorCity",
            VendorState = "VendorState",
            VendorStateName = "VendorStateName",
            VendorZipCode = "VendorZipCode",
            VendorPhone = "VendorPhone",
            VendorEmail = "VendorEmail",
            VendorGSTNumber = "VendorGSTNumber",
            VendorAccountNumber = "VendorAccountNumber",
            VendorIFSCCode = "VendorIFSCCode",
            ProcurementGroup = "ProcurementGroup",
            CurrencyName = "CurrencyName",
            TenantId = "TenantId",
            TenantName = "TenantName",
            ItemList = "ItemList",
            BillPaymentList = "BillPaymentList"
        }
    }
}
