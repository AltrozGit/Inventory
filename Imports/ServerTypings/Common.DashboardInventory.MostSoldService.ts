namespace Indotalent.Common.DashboardInventory {
    export namespace MostSoldService {
        export const baseUrl = 'Common/Dashboard/MostSold';

        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<MostSoldRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            List = "Common/Dashboard/MostSold/List"
        }

        [
            'List'
        ].forEach(x => {
            (<any>MostSoldService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}
