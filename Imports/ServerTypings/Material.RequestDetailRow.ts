namespace Indotalent.Material {
    export interface RequestDetailRow {
        Id?: number;
        MaterialRequestId?: number;
        ProductId?: number;
        QtyRequest?: number;
        PurchasePrice?: number;
        SubTotal?: number;
        RequestId?: number;
        ItemId?: number;
        InternalCode?: string;
        QuanityOfPOCreated?: number;
        IsPOComplete?: boolean;
        TenantId?: number;
        TenantName?: string;
        IsActive?: boolean;
        MaterialRequestNumber?: string;
        ProductName?: string;
        PurchaseTaxId?: number;
        TaxRatePercentage?: number;
        SGST?: number;
        CGST?: number;
        IGST?: number;
        UomId?: number;
        UomName?: string;
        AvailableStock?: number;
        SacId?: number;
        SacName1?: string;
        HsnId?: number;
        HsnName1?: string;
        InsertUserId?: number;
        InsertDate?: string;
        UpdateUserId?: number;
        UpdateDate?: string;
    }

    export namespace RequestDetailRow {
        export const idProperty = 'Id';
        export const localTextPrefix = 'Material.RequestDetail';
        export const lookupKey = 'Material.RequestDetail';

        export function getLookup(): Q.Lookup<RequestDetailRow> {
            return Q.getLookup<RequestDetailRow>('Material.RequestDetail');
        }
        export const deletePermission = 'Material:RequestDetail';
        export const insertPermission = 'Material:RequestDetail';
        export const readPermission = 'Material:RequestDetail';
        export const updatePermission = 'Material:RequestDetail';

        export declare const enum Fields {
            Id = "Id",
            MaterialRequestId = "MaterialRequestId",
            ProductId = "ProductId",
            QtyRequest = "QtyRequest",
            PurchasePrice = "PurchasePrice",
            SubTotal = "SubTotal",
            RequestId = "RequestId",
            ItemId = "ItemId",
            InternalCode = "InternalCode",
            QuanityOfPOCreated = "QuanityOfPOCreated",
            IsPOComplete = "IsPOComplete",
            TenantId = "TenantId",
            TenantName = "TenantName",
            IsActive = "IsActive",
            MaterialRequestNumber = "MaterialRequestNumber",
            ProductName = "ProductName",
            PurchaseTaxId = "PurchaseTaxId",
            TaxRatePercentage = "TaxRatePercentage",
            SGST = "SGST",
            CGST = "CGST",
            IGST = "IGST",
            UomId = "UomId",
            UomName = "UomName",
            AvailableStock = "AvailableStock",
            SacId = "SacId",
            SacName1 = "SacName1",
            HsnId = "HsnId",
            HsnName1 = "HsnName1",
            InsertUserId = "InsertUserId",
            InsertDate = "InsertDate",
            UpdateUserId = "UpdateUserId",
            UpdateDate = "UpdateDate"
        }
    }
}
