namespace Indotalent.Inventory {
    export namespace MovementService {
        export const baseUrl = 'Inventory/Movement';

        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<MovementRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            List = "Inventory/Movement/List"
        }

        [
            'List'
        ].forEach(x => {
            (<any>MovementService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}
