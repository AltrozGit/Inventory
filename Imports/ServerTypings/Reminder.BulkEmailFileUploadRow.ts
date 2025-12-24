namespace Indotalent.Reminder {
    export interface BulkEmailFileUploadRow {
        Id?: number;
        Title?: string;
        FilePath?: string;
        Description?: string;
        TenantId?: number;
        TenantName?: string;
        ScheduledDate?: string;
        UploadAttachments?: string;
        IsActive?: boolean;
        IsStopped?: boolean;
        FromAddress?: string;
        InsertUserId?: number;
        InsertDate?: string;
        UpdateUserId?: number;
        UpdateDate?: string;
    }

    export namespace BulkEmailFileUploadRow {
        export const idProperty = 'Id';
        export const nameProperty = 'FromAddress';
        export const localTextPrefix = 'Reminder.BulkEmailFileUpload';
        export const lookupKey = 'Reminder.BulkEmailFileUpload';

        export function getLookup(): Q.Lookup<BulkEmailFileUploadRow> {
            return Q.getLookup<BulkEmailFileUploadRow>('Reminder.BulkEmailFileUpload');
        }
        export const deletePermission = 'Reminder:BulkEmailFileUpload';
        export const insertPermission = 'Reminder:BulkEmailFileUpload';
        export const readPermission = 'Reminder:BulkEmailFileUpload';
        export const updatePermission = 'Reminder:BulkEmailFileUpload';

        export declare const enum Fields {
            Id = "Id",
            Title = "Title",
            FilePath = "FilePath",
            Description = "Description",
            TenantId = "TenantId",
            TenantName = "TenantName",
            ScheduledDate = "ScheduledDate",
            UploadAttachments = "UploadAttachments",
            IsActive = "IsActive",
            IsStopped = "IsStopped",
            FromAddress = "FromAddress",
            InsertUserId = "InsertUserId",
            InsertDate = "InsertDate",
            UpdateUserId = "UpdateUserId",
            UpdateDate = "UpdateDate"
        }
    }
}
