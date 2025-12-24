namespace Indotalent.Material {
    export namespace IssueDetailService {
        export const baseUrl = 'Material/IssueDetail';

        export declare function Create(request: Serenity.SaveRequest<IssueDetailRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<IssueDetailRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<IssueDetailRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<IssueDetailRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function GetQuantityOfIssueCreated(request: Web.Modules.Material.Issue.RequestHandlers.IssueDetailGetQuantityOfIssueCreatedRequest, onSuccess?: (response: Web.Modules.Material.Issue.RequestHandlers.IssueDetailGetQuantityOfIssueCreatedResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "Material/IssueDetail/Create",
            Update = "Material/IssueDetail/Update",
            Delete = "Material/IssueDetail/Delete",
            Retrieve = "Material/IssueDetail/Retrieve",
            List = "Material/IssueDetail/List",
            GetQuantityOfIssueCreated = "Material/IssueDetail/GetQuantityOfIssueCreated"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List', 
            'GetQuantityOfIssueCreated'
        ].forEach(x => {
            (<any>IssueDetailService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}
