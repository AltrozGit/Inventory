namespace Indotalent.Inventory {
    export interface TransferOrderRow {
        Id?: number;
        Number?: string;
        Description?: string;
        TransferDate?: string;
        ProjectFromId?: number;
        ProjectToId?: number;
        FromId?: number;
        ToId?: number;
        TotalQty?: number;
        ProjectFromName?: string;
        ProjectFromStreet?: string;
        ProjectFromCity?: string;
        ProjectFromState?: string;
        ProjectFromZipCode?: string;
        ProjectFromPhone?: string;
        ProjectFromEmail?: string;
        ProjectToName?: string;
        ProjectToStreet?: string;
        ProjectToCity?: string;
        ProjectToState?: string;
        ProjectToZipCode?: string;
        ProjectToPhone?: string;
        ProjectToEmail?: string;
        FromName?: string;
        FromStreet?: string;
        FromCity?: string;
        FromState?: string;
        FromZipCode?: string;
        FromPhone?: string;
        FromEmail?: string;
        ToName?: string;
        ToStreet?: string;
        ToCity?: string;
        ToState?: string;
        ToZipCode?: string;
        ToPhone?: string;
        ToEmail?: string;
        ItemList?: TransferOrderDetailRow[];
        TenantId?: number;
        TenantName?: string;
        InsertUserId?: number;
        InsertDate?: string;
        UpdateUserId?: number;
        UpdateDate?: string;
    }

    export namespace TransferOrderRow {
        export const idProperty = 'Id';
        export const nameProperty = 'Number';
        export const localTextPrefix = 'Inventory.TransferOrder';
        export const lookupKey = 'Inventory.TransferOrder';

        export function getLookup(): Q.Lookup<TransferOrderRow> {
            return Q.getLookup<TransferOrderRow>('Inventory.TransferOrder');
        }
        export const deletePermission = 'Inventory:TransferOrder';
        export const insertPermission = 'Inventory:TransferOrder';
        export const readPermission = 'Inventory:TransferOrder';
        export const updatePermission = 'Inventory:TransferOrder';

        export declare const enum Fields {
            Id = "Id",
            Number = "Number",
            Description = "Description",
            TransferDate = "TransferDate",
            ProjectFromId = "ProjectFromId",
            ProjectToId = "ProjectToId",
            FromId = "FromId",
            ToId = "ToId",
            TotalQty = "TotalQty",
            ProjectFromName = "ProjectFromName",
            ProjectFromStreet = "ProjectFromStreet",
            ProjectFromCity = "ProjectFromCity",
            ProjectFromState = "ProjectFromState",
            ProjectFromZipCode = "ProjectFromZipCode",
            ProjectFromPhone = "ProjectFromPhone",
            ProjectFromEmail = "ProjectFromEmail",
            ProjectToName = "ProjectToName",
            ProjectToStreet = "ProjectToStreet",
            ProjectToCity = "ProjectToCity",
            ProjectToState = "ProjectToState",
            ProjectToZipCode = "ProjectToZipCode",
            ProjectToPhone = "ProjectToPhone",
            ProjectToEmail = "ProjectToEmail",
            FromName = "FromName",
            FromStreet = "FromStreet",
            FromCity = "FromCity",
            FromState = "FromState",
            FromZipCode = "FromZipCode",
            FromPhone = "FromPhone",
            FromEmail = "FromEmail",
            ToName = "ToName",
            ToStreet = "ToStreet",
            ToCity = "ToCity",
            ToState = "ToState",
            ToZipCode = "ToZipCode",
            ToPhone = "ToPhone",
            ToEmail = "ToEmail",
            ItemList = "ItemList",
            TenantId = "TenantId",
            TenantName = "TenantName",
            InsertUserId = "InsertUserId",
            InsertDate = "InsertDate",
            UpdateUserId = "UpdateUserId",
            UpdateDate = "UpdateDate"
        }
    }
}
