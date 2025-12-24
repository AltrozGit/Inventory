namespace Indotalent.Inventory {
    export namespace NegativeAdjustmentService {
        export const baseUrl = 'Inventory/NegativeAdjustment';

        export declare function Create(request: Serenity.SaveRequest<NegativeAdjustmentRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<NegativeAdjustmentRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<NegativeAdjustmentRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<NegativeAdjustmentRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "Inventory/NegativeAdjustment/Create",
            Update = "Inventory/NegativeAdjustment/Update",
            Delete = "Inventory/NegativeAdjustment/Delete",
            Retrieve = "Inventory/NegativeAdjustment/Retrieve",
            List = "Inventory/NegativeAdjustment/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>NegativeAdjustmentService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}
