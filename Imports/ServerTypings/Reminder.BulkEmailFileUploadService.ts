namespace Indotalent.Reminder {
    export namespace BulkEmailFileUploadService {
        export const baseUrl = 'Reminder/BulkEmailFileUpload';

        export declare function GetTenantId(request: Serenity.ServiceRequest, onSuccess?: (response: System.String) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Create(request: Serenity.SaveRequest<BulkEmailFileUploadRow>, onSuccess?: (response: Web.Modules.Reminder.BulkEmailFileUpload.CustomSaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function StopEmailNotifications(request: StopEmailNotificationsRequest, onSuccess?: (response: Serenity.ServiceResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function ToggleActiveStatus(request: ToggleIsActiveRequest, onSuccess?: (response: Serenity.ServiceResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<BulkEmailFileUploadRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<BulkEmailFileUploadRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<BulkEmailFileUploadRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            GetTenantId = "Reminder/BulkEmailFileUpload/GetTenantId",
            Create = "Reminder/BulkEmailFileUpload/Create",
            StopEmailNotifications = "Reminder/BulkEmailFileUpload/StopEmailNotifications",
            ToggleActiveStatus = "Reminder/BulkEmailFileUpload/ToggleActiveStatus",
            Update = "Reminder/BulkEmailFileUpload/Update",
            Delete = "Reminder/BulkEmailFileUpload/Delete",
            Retrieve = "Reminder/BulkEmailFileUpload/Retrieve",
            List = "Reminder/BulkEmailFileUpload/List"
        }

        [
            'GetTenantId', 
            'Create', 
            'StopEmailNotifications', 
            'ToggleActiveStatus', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>BulkEmailFileUploadService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}
