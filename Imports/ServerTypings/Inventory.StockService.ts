namespace Indotalent.Inventory {
    export namespace StockService {
        export const baseUrl = 'Inventory/Stock';

        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<StockRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            List = "Inventory/Stock/List"
        }

        [
            'List'
        ].forEach(x => {
            (<any>StockService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}
