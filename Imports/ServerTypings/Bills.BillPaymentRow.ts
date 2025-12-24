namespace Indotalent.Bills {
    export interface BillPaymentRow {
        Id?: number;
        BillId?: number;
        Number?: string;
        Description?: string;
        PaymentDate?: string;
        CashBankId?: number;
        BillAmount?: number;
        PaymentAmount?: number;
        BillNumber?: string;
        CashBankName?: string;
        PurchaseOrderId?: number;
        VendorId?: number;
        VendorName?: string;
        VendorStreet?: string;
        VendorCity?: string;
        VendorState?: number;
        VendorStateName?: string;
        VendorZipCode?: string;
        VendorPhone?: string;
        VendorEmail?: string;
        ProcurementGroup?: string;
        CurrencyName?: string;
        TenantId?: number;
        TenantName?: string;
        InsertUserId?: number;
        InsertDate?: string;
        UpdateUserId?: number;
        UpdateDate?: string;
    }

    export namespace BillPaymentRow {
        export const idProperty = 'Id';
        export const nameProperty = 'Number';
        export const localTextPrefix = 'Bills.BillPayment';
        export const lookupKey = 'Bills.BillPayment';

        export function getLookup(): Q.Lookup<BillPaymentRow> {
            return Q.getLookup<BillPaymentRow>('Bills.BillPayment');
        }
        export const deletePermission = 'Bills:BillPayment';
        export const insertPermission = 'Bills:BillPayment';
        export const readPermission = 'Bills:BillPayment';
        export const updatePermission = 'Bills:BillPayment';

        export declare const enum Fields {
            Id = "Id",
            BillId = "BillId",
            Number = "Number",
            Description = "Description",
            PaymentDate = "PaymentDate",
            CashBankId = "CashBankId",
            BillAmount = "BillAmount",
            PaymentAmount = "PaymentAmount",
            BillNumber = "BillNumber",
            CashBankName = "CashBankName",
            PurchaseOrderId = "PurchaseOrderId",
            VendorId = "VendorId",
            VendorName = "VendorName",
            VendorStreet = "VendorStreet",
            VendorCity = "VendorCity",
            VendorState = "VendorState",
            VendorStateName = "VendorStateName",
            VendorZipCode = "VendorZipCode",
            VendorPhone = "VendorPhone",
            VendorEmail = "VendorEmail",
            ProcurementGroup = "ProcurementGroup",
            CurrencyName = "CurrencyName",
            TenantId = "TenantId",
            TenantName = "TenantName",
            InsertUserId = "InsertUserId",
            InsertDate = "InsertDate",
            UpdateUserId = "UpdateUserId",
            UpdateDate = "UpdateDate"
        }
    }
}
