namespace Indotalent.Reminder {
    export interface BulkEmailSenderStatusRow {
        Id?: number;
        ToEmail?: string;
        Subject?: string;
        Body?: string;
        Attachment?: string;
        IsSent?: Web.Common.EmailSentStatus;
        SentOn?: string;
        RetryCount?: number;
        TenantId?: number;
        BulkEmailSenderId?: number;
        CC?: string;
        RecipientName?: string;
        CompanyName?: string;
        BulkEmailSenderTitle?: string;
        TenantName?: string;
        IsSentDisplay?: string;
    }

    export namespace BulkEmailSenderStatusRow {
        export const idProperty = 'Id';
        export const nameProperty = 'ToEmail';
        export const localTextPrefix = 'Reminder.BulkEmailSenderStatus';
        export const lookupKey = 'Reminder.BulkEmailSenderStatus';

        export function getLookup(): Q.Lookup<BulkEmailSenderStatusRow> {
            return Q.getLookup<BulkEmailSenderStatusRow>('Reminder.BulkEmailSenderStatus');
        }
        export const deletePermission = 'Reminder:BulkEmailSenderStatus';
        export const insertPermission = 'Reminder:BulkEmailSenderStatus';
        export const readPermission = 'Reminder:BulkEmailSenderStatus';
        export const updatePermission = 'Reminder:BulkEmailSenderStatus';

        export declare const enum Fields {
            Id = "Id",
            ToEmail = "ToEmail",
            Subject = "Subject",
            Body = "Body",
            Attachment = "Attachment",
            IsSent = "IsSent",
            SentOn = "SentOn",
            RetryCount = "RetryCount",
            TenantId = "TenantId",
            BulkEmailSenderId = "BulkEmailSenderId",
            CC = "CC",
            RecipientName = "RecipientName",
            CompanyName = "CompanyName",
            BulkEmailSenderTitle = "BulkEmailSenderTitle",
            TenantName = "TenantName",
            IsSentDisplay = "IsSentDisplay"
        }
    }
}
