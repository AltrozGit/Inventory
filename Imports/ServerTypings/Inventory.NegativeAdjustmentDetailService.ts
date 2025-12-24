namespace Indotalent.Inventory {
    export namespace NegativeAdjustmentDetailService {
        export const baseUrl = 'Inventory/NegativeAdjustmentDetail';

        export declare function Create(request: Serenity.SaveRequest<NegativeAdjustmentDetailRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<NegativeAdjustmentDetailRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<NegativeAdjustmentDetailRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<NegativeAdjustmentDetailRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "Inventory/NegativeAdjustmentDetail/Create",
            Update = "Inventory/NegativeAdjustmentDetail/Update",
            Delete = "Inventory/NegativeAdjustmentDetail/Delete",
            Retrieve = "Inventory/NegativeAdjustmentDetail/Retrieve",
            List = "Inventory/NegativeAdjustmentDetail/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>NegativeAdjustmentDetailService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}
