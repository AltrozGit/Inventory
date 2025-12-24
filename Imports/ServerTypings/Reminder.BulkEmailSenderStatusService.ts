namespace Indotalent.Reminder {
    export namespace BulkEmailSenderStatusService {
        export const baseUrl = 'Reminder/BulkEmailSenderStatus';

        export declare function Create(request: Serenity.SaveRequest<BulkEmailSenderStatusRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<BulkEmailSenderStatusRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<BulkEmailSenderStatusRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Web.Modules.Reminder.BulkEmailSenderStatus.BulkEmailSenderStatusRequest, onSuccess?: (response: Serenity.ListResponse<BulkEmailSenderStatusRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "Reminder/BulkEmailSenderStatus/Create",
            Update = "Reminder/BulkEmailSenderStatus/Update",
            Delete = "Reminder/BulkEmailSenderStatus/Delete",
            Retrieve = "Reminder/BulkEmailSenderStatus/Retrieve",
            List = "Reminder/BulkEmailSenderStatus/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>BulkEmailSenderStatusService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}
