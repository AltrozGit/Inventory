namespace Indotalent.Administration {
    export namespace UserProjectsService {
        export const baseUrl = 'Administration/UserProjects';

        export declare function Update(request: UserProjectsUpdateRequest, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: UserProjectsListRequest, onSuccess?: (response: UserProjectsListResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Update = "Administration/UserProjects/Update",
            List = "Administration/UserProjects/List"
        }

        [
            'Update', 
            'List'
        ].forEach(x => {
            (<any>UserProjectsService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}
