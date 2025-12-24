namespace Indotalent.Reminder {
    export interface DueDateReminderForm {
        SendRemainderOnWhatsapp: Serenity.BooleanEditor;
        CustomerId: Serenity.LookupEditor;
        CustomerPhone: Serenity.StringEditor;
        TenantPhone: Serenity.StringEditor;
        WhatsAppId: Serenity.LookupEditor;
        SendRemainderOnEmail: Serenity.BooleanEditor;
        TenantEmail: Serenity.StringEditor;
        ToEmail: Serenity.StringEditor;
        ReminderInCC: Serenity.StringEditor;
        Subject: Serenity.StringEditor;
        MessageBody: Serenity.TextAreaEditor;
        ConsentDueDate: Serenity.DateEditor;
        Remainder1: Serenity.DateEditor;
        Remainder2: Serenity.DateEditor;
        Attachment: Serenity.ImageUploadEditor;
        IsEnable: Serenity.BooleanEditor;
        IsActionComplete: Serenity.BooleanEditor;
    }

    export class DueDateReminderForm extends Serenity.PrefixedContext {
        static formKey = 'Reminder.DueDateReminder';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!DueDateReminderForm.init)  {
                DueDateReminderForm.init = true;

                var s = Serenity;
                var w0 = s.BooleanEditor;
                var w1 = s.LookupEditor;
                var w2 = s.StringEditor;
                var w3 = s.TextAreaEditor;
                var w4 = s.DateEditor;
                var w5 = s.ImageUploadEditor;

                Q.initFormType(DueDateReminderForm, [
                    'SendRemainderOnWhatsapp', w0,
                    'CustomerId', w1,
                    'CustomerPhone', w2,
                    'TenantPhone', w2,
                    'WhatsAppId', w1,
                    'SendRemainderOnEmail', w0,
                    'TenantEmail', w2,
                    'ToEmail', w2,
                    'ReminderInCC', w2,
                    'Subject', w2,
                    'MessageBody', w3,
                    'ConsentDueDate', w4,
                    'Remainder1', w4,
                    'Remainder2', w4,
                    'Attachment', w5,
                    'IsEnable', w0,
                    'IsActionComplete', w0
                ]);
            }
        }
    }
}
