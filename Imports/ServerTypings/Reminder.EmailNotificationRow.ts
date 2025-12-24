namespace Indotalent.Reminder {
    export interface EmailNotificationRow {
        Id?: number;
        ToEmail?: string;
        CC?: string;
        RecipientName?: string;
        CompanyName?: string;
        FromAddress?: string;
        Subject?: string;
        Body?: string;
        Attachment?: string;
        IsSent?: boolean;
        IsActive?: boolean;
        SentOn?: string;
        Placeholder?: string;
        Placeholder1?: string;
        RetryCount?: number;
        BulkEmailSenderId?: number;
        ScheduledDate?: string;
        TenantId?: number;
        TenantName?: string;
        InsertUserId?: number;
        InsertDate?: string;
        UpdateUserId?: number;
        UpdateDate?: string;
    }

    export namespace EmailNotificationRow {
        export const idProperty = 'Id';
        export const nameProperty = 'ToEmail';
        export const localTextPrefix = 'Reminder.EmailNotification';
        export const deletePermission = 'Reminder:EmailNotification';
        export const insertPermission = 'Reminder:EmailNotification';
        export const readPermission = 'Reminder:EmailNotification';
        export const updatePermission = 'Reminder:EmailNotification';

        export declare const enum Fields {
            Id = "Id",
            ToEmail = "ToEmail",
            CC = "CC",
            RecipientName = "RecipientName",
            CompanyName = "CompanyName",
            FromAddress = "FromAddress",
            Subject = "Subject",
            Body = "Body",
            Attachment = "Attachment",
            IsSent = "IsSent",
            IsActive = "IsActive",
            SentOn = "SentOn",
            Placeholder = "Placeholder",
            Placeholder1 = "Placeholder1",
            RetryCount = "RetryCount",
            BulkEmailSenderId = "BulkEmailSenderId",
            ScheduledDate = "ScheduledDate",
            TenantId = "TenantId",
            TenantName = "TenantName",
            InsertUserId = "InsertUserId",
            InsertDate = "InsertDate",
            UpdateUserId = "UpdateUserId",
            UpdateDate = "UpdateDate"
        }
    }
}
