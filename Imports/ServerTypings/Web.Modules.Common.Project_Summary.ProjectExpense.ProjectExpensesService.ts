namespace Indotalent.Web.Modules.Common.Project_Summary.ProjectExpense {
    export namespace ProjectExpensesService {
        export const baseUrl = 'Common/Dashboard/Project/ProjectExpenses';

        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<ProjectExpensesRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            List = "Common/Dashboard/Project/ProjectExpenses/List"
        }

        [
            'List'
        ].forEach(x => {
            (<any>ProjectExpensesService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}
