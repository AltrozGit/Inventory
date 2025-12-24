namespace Indotalent.Reminder {
    export interface BulkEmailSenderStatusForm {
        ToEmail: Serenity.StringEditor;
        Subject: Serenity.StringEditor;
        Body: Serenity.StringEditor;
        Attachment: Serenity.StringEditor;
        IsSent: Serenity.EnumEditor;
        SentOn: Serenity.DateEditor;
        RetryCount: Serenity.IntegerEditor;
        InsertDate: Serenity.DateEditor;
        TenantId: Serenity.IntegerEditor;
        BulkEmailSenderId: Serenity.IntegerEditor;
    }

    export class BulkEmailSenderStatusForm extends Serenity.PrefixedContext {
        static formKey = 'Reminder.BulkEmailSenderStatus';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!BulkEmailSenderStatusForm.init)  {
                BulkEmailSenderStatusForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;
                var w1 = s.EnumEditor;
                var w2 = s.DateEditor;
                var w3 = s.IntegerEditor;

                Q.initFormType(BulkEmailSenderStatusForm, [
                    'ToEmail', w0,
                    'Subject', w0,
                    'Body', w0,
                    'Attachment', w0,
                    'IsSent', w1,
                    'SentOn', w2,
                    'RetryCount', w3,
                    'InsertDate', w2,
                    'TenantId', w3,
                    'BulkEmailSenderId', w3
                ]);
            }
        }
    }
}
