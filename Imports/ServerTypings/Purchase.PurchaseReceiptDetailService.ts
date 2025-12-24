namespace Indotalent.Purchase {
    export namespace PurchaseReceiptDetailService {
        export const baseUrl = 'Purchase/PurchaseReceiptDetail';

        export declare function Create(request: Serenity.SaveRequest<PurchaseReceiptDetailRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<PurchaseReceiptDetailRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<PurchaseReceiptDetailRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<PurchaseReceiptDetailRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function GetQuantityOfPRCreated(request: Web.Modules.Purchase.PurchaseOrderDetail.RequestHandlers.PurchaseReceipDetailGetQuantityOfPRCreatedRequest, onSuccess?: (response: Web.Modules.Purchase.PurchaseOrderDetail.RequestHandlers.PurchaseReceipDetailGetQuantityOfPRCreatedResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "Purchase/PurchaseReceiptDetail/Create",
            Update = "Purchase/PurchaseReceiptDetail/Update",
            Delete = "Purchase/PurchaseReceiptDetail/Delete",
            Retrieve = "Purchase/PurchaseReceiptDetail/Retrieve",
            List = "Purchase/PurchaseReceiptDetail/List",
            GetQuantityOfPRCreated = "Purchase/PurchaseReceiptDetail/GetQuantityOfPRCreated"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List', 
            'GetQuantityOfPRCreated'
        ].forEach(x => {
            (<any>PurchaseReceiptDetailService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}
