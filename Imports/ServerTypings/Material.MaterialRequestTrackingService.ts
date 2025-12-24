namespace Indotalent.Material {
    export namespace MaterialRequestTrackingService {
        export const baseUrl = 'Material/MaterialRequestTracking';

        export declare function Create(request: Serenity.SaveRequest<MaterialRequestTrackingRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<MaterialRequestTrackingRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<MaterialRequestTrackingRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<MaterialRequestTrackingRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "Material/MaterialRequestTracking/Create",
            Update = "Material/MaterialRequestTracking/Update",
            Delete = "Material/MaterialRequestTracking/Delete",
            Retrieve = "Material/MaterialRequestTracking/Retrieve",
            List = "Material/MaterialRequestTracking/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>MaterialRequestTrackingService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}
