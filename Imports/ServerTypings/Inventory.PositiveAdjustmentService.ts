namespace Indotalent.Inventory {
    export namespace PositiveAdjustmentService {
        export const baseUrl = 'Inventory/PositiveAdjustment';

        export declare function Create(request: Serenity.SaveRequest<PositiveAdjustmentRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<PositiveAdjustmentRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<PositiveAdjustmentRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<PositiveAdjustmentRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "Inventory/PositiveAdjustment/Create",
            Update = "Inventory/PositiveAdjustment/Update",
            Delete = "Inventory/PositiveAdjustment/Delete",
            Retrieve = "Inventory/PositiveAdjustment/Retrieve",
            List = "Inventory/PositiveAdjustment/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>PositiveAdjustmentService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}
