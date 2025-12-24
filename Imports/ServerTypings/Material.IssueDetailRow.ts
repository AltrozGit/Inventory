namespace Indotalent.Material {
    export interface IssueDetailRow {
        Id?: number;
        MaterialIssueId?: number;
        ProductId?: number;
        PurchasedQty?: number;
        Qty?: number;
        QtyIssue?: number;
        QtyRequest?: number;
        SubTotal?: number;
        TenantId?: number;
        TenantName?: string;
        MaterialIssueNumber?: string;
        MaterialRequestId?: number;
        MaterialRequestNumber?: string;
        PurchasePrice?: number;
        PurchaseTaxId?: number;
        ProductName?: string;
        AvailableStock?: number;
        TaxRatePercentage?: number;
        UomId?: number;
        UomName?: string;
        SacId?: number;
        SacName1?: string;
        HsnId?: number;
        HsnName1?: string;
        InternalCode?: string;
        PurchaseReceiptId?: number;
        QuanityOfIssueCreated?: number;
        InsertUserId?: number;
        InsertDate?: string;
        UpdateUserId?: number;
        UpdateDate?: string;
    }

    export namespace IssueDetailRow {
        export const idProperty = 'Id';
        export const localTextPrefix = 'Material.IssueDetail';
        export const lookupKey = 'Material.IssueDetail';

        export function getLookup(): Q.Lookup<IssueDetailRow> {
            return Q.getLookup<IssueDetailRow>('Material.IssueDetail');
        }
        export const deletePermission = 'Material:IssueDetail';
        export const insertPermission = 'Material:IssueDetail';
        export const readPermission = 'Material:IssueDetail';
        export const updatePermission = 'Material:IssueDetail';

        export declare const enum Fields {
            Id = "Id",
            MaterialIssueId = "MaterialIssueId",
            ProductId = "ProductId",
            PurchasedQty = "PurchasedQty",
            Qty = "Qty",
            QtyIssue = "QtyIssue",
            QtyRequest = "QtyRequest",
            SubTotal = "SubTotal",
            TenantId = "TenantId",
            TenantName = "TenantName",
            MaterialIssueNumber = "MaterialIssueNumber",
            MaterialRequestId = "MaterialRequestId",
            MaterialRequestNumber = "MaterialRequestNumber",
            PurchasePrice = "PurchasePrice",
            PurchaseTaxId = "PurchaseTaxId",
            ProductName = "ProductName",
            AvailableStock = "AvailableStock",
            TaxRatePercentage = "TaxRatePercentage",
            UomId = "UomId",
            UomName = "UomName",
            SacId = "SacId",
            SacName1 = "SacName1",
            HsnId = "HsnId",
            HsnName1 = "HsnName1",
            InternalCode = "InternalCode",
            PurchaseReceiptId = "PurchaseReceiptId",
            QuanityOfIssueCreated = "QuanityOfIssueCreated",
            InsertUserId = "InsertUserId",
            InsertDate = "InsertDate",
            UpdateUserId = "UpdateUserId",
            UpdateDate = "UpdateDate"
        }
    }
}
