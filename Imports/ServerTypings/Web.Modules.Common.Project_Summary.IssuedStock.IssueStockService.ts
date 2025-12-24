namespace Indotalent.Web.Modules.Common.Project_Summary.IssuedStock {
    export namespace IssueStockService {
        export const baseUrl = 'Common/Dashboard/Project/IssueStock';

        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<IssueStockRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            List = "Common/Dashboard/Project/IssueStock/List"
        }

        [
            'List'
        ].forEach(x => {
            (<any>IssueStockService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}
