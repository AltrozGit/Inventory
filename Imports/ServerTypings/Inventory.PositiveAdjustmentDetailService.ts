namespace Indotalent.Inventory {
    export namespace PositiveAdjustmentDetailService {
        export const baseUrl = 'Inventory/PositiveAdjustmentDetail';

        export declare function Create(request: Serenity.SaveRequest<PositiveAdjustmentDetailRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<PositiveAdjustmentDetailRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<PositiveAdjustmentDetailRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<PositiveAdjustmentDetailRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "Inventory/PositiveAdjustmentDetail/Create",
            Update = "Inventory/PositiveAdjustmentDetail/Update",
            Delete = "Inventory/PositiveAdjustmentDetail/Delete",
            Retrieve = "Inventory/PositiveAdjustmentDetail/Retrieve",
            List = "Inventory/PositiveAdjustmentDetail/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>PositiveAdjustmentDetailService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}
