namespace Indotalent.Material {
    export namespace IssueService {
        export const baseUrl = 'Material/Issue';

        export declare function Create(request: Serenity.SaveRequest<IssueRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<IssueRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<IssueRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<IssueRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function GetPurchaseReceiptIdsByMaterialRequestId(request: Web.Modules.Material.Issue.RequestHandlers.IssueGetPurchaseReceiptIdRequest, onSuccess?: (response: Web.Modules.Material.Issue.RequestHandlers.IssueGetPurchaseReceiptIdResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function GetBillCretedPRId(request: Web.Modules.Material.Issue.RequestHandlers.IssuecheckPurchaseReceiptIdRequest, onSuccess?: (response: Web.Modules.Material.Issue.RequestHandlers.IssuecheckPurchaseReceiptIdResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "Material/Issue/Create",
            Update = "Material/Issue/Update",
            Delete = "Material/Issue/Delete",
            Retrieve = "Material/Issue/Retrieve",
            List = "Material/Issue/List",
            GetPurchaseReceiptIdsByMaterialRequestId = "Material/Issue/GetPurchaseReceiptIdsByMaterialRequestId",
            GetBillCretedPRId = "Material/Issue/GetBillCretedPRId"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List', 
            'GetPurchaseReceiptIdsByMaterialRequestId', 
            'GetBillCretedPRId'
        ].forEach(x => {
            (<any>IssueService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}
