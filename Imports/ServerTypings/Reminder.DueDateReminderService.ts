namespace Indotalent.Reminder {
    export namespace DueDateReminderService {
        export const baseUrl = 'Reminder/DueDateReminder';

        export declare function GetTenantDetails(request: Web.Modules.Reminder.DueDateReminder.TenantDetailsRequest, onSuccess?: (response: Web.Modules.Reminder.DueDateReminder.TenantDetailsResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Create(request: Serenity.SaveRequest<DueDateReminderRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<DueDateReminderRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<DueDateReminderRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<DueDateReminderRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            GetTenantDetails = "Reminder/DueDateReminder/GetTenantDetails",
            Create = "Reminder/DueDateReminder/Create",
            Update = "Reminder/DueDateReminder/Update",
            Delete = "Reminder/DueDateReminder/Delete",
            Retrieve = "Reminder/DueDateReminder/Retrieve",
            List = "Reminder/DueDateReminder/List"
        }

        [
            'GetTenantDetails', 
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>DueDateReminderService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}
