namespace Indotalent.Common.DashboardInventory {
    export namespace MinStockService {
        export const baseUrl = 'Common/Dashboard/MinStock';

        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<MinStockRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            List = "Common/Dashboard/MinStock/List"
        }

        [
            'List'
        ].forEach(x => {
            (<any>MinStockService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}
