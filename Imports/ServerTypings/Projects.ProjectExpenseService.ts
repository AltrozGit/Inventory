namespace Indotalent.Projects {
    export namespace ProjectExpenseService {
        export const baseUrl = 'Projects/ProjectExpense';

        export declare function Create(request: Serenity.SaveRequest<ProjectExpenseRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<ProjectExpenseRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<ProjectExpenseRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<ProjectExpenseRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function GetProjectExpenseFundAvailability(request: Web.Modules.Material.Issue.RequestHandlers.ProjectExpenseFundAvailabilityRequest, onSuccess?: (response: Web.Modules.Material.Issue.RequestHandlers.ProjectExpenseFundAvailabilityResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "Projects/ProjectExpense/Create",
            Update = "Projects/ProjectExpense/Update",
            Delete = "Projects/ProjectExpense/Delete",
            Retrieve = "Projects/ProjectExpense/Retrieve",
            List = "Projects/ProjectExpense/List",
            GetProjectExpenseFundAvailability = "Projects/ProjectExpense/GetProjectExpenseFundAvailability"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List', 
            'GetProjectExpenseFundAvailability'
        ].forEach(x => {
            (<any>ProjectExpenseService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}
