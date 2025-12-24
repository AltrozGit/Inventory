namespace Indotalent.Reminder {
    export interface DueDateReminderRow {
        Id?: number;
        CustomerId?: number;
        CustomerName?: string;
        RelatedCustomerName?: string;
        CustomerPhone?: string;
        MessageBody?: string;
        Subject?: string;
        PlanId?: number;
        PlanName?: string;
        SendRemainderOnEmail?: boolean;
        SendRemainderOnWhatsapp?: boolean;
        IsActionComplete?: boolean;
        IsEnable?: boolean;
        ConsentDueDate?: string;
        Remainder1?: string;
        Remainder2?: string;
        ReminderInCC?: string;
        ToEmail?: string;
        TenantEmail?: string;
        Attachment?: string;
        TenantId?: number;
        TenantName?: string;
        TenantPhone?: string;
        WhatsAppId?: number;
        TemplateName?: string;
        BroadcastName?: string;
        Url?: string;
        InsertUserId?: number;
        InsertDate?: string;
        UpdateUserId?: number;
        UpdateDate?: string;
    }

    export namespace DueDateReminderRow {
        export const idProperty = 'Id';
        export const nameProperty = 'CustomerName';
        export const localTextPrefix = 'Reminder.DueDateReminder';
        export const lookupKey = 'Reminder.DueDateReminder';

        export function getLookup(): Q.Lookup<DueDateReminderRow> {
            return Q.getLookup<DueDateReminderRow>('Reminder.DueDateReminder');
        }
        export const deletePermission = 'Reminder:DueDateReminder';
        export const insertPermission = 'Reminder:DueDateReminder';
        export const readPermission = 'Reminder:DueDateReminder';
        export const updatePermission = 'Reminder:DueDateReminder';

        export declare const enum Fields {
            Id = "Id",
            CustomerId = "CustomerId",
            CustomerName = "CustomerName",
            RelatedCustomerName = "RelatedCustomerName",
            CustomerPhone = "CustomerPhone",
            MessageBody = "MessageBody",
            Subject = "Subject",
            PlanId = "PlanId",
            PlanName = "PlanName",
            SendRemainderOnEmail = "SendRemainderOnEmail",
            SendRemainderOnWhatsapp = "SendRemainderOnWhatsapp",
            IsActionComplete = "IsActionComplete",
            IsEnable = "IsEnable",
            ConsentDueDate = "ConsentDueDate",
            Remainder1 = "Remainder1",
            Remainder2 = "Remainder2",
            ReminderInCC = "ReminderInCC",
            ToEmail = "ToEmail",
            TenantEmail = "TenantEmail",
            Attachment = "Attachment",
            TenantId = "TenantId",
            TenantName = "TenantName",
            TenantPhone = "TenantPhone",
            WhatsAppId = "WhatsAppId",
            TemplateName = "TemplateName",
            BroadcastName = "BroadcastName",
            Url = "Url",
            InsertUserId = "InsertUserId",
            InsertDate = "InsertDate",
            UpdateUserId = "UpdateUserId",
            UpdateDate = "UpdateDate"
        }
    }
}
