namespace Indotalent.Reminder {
    export interface BulkEmailFileUploadForm {
        FromAddress: Serenity.LookupEditor;
        ScheduledDate: Serenity.DateTimeEditor;
        FilePath: Serenity.ImageUploadEditor;
        UploadAttachments: Serenity.MultipleImageUploadEditor;
        Title: Serenity.StringEditor;
        Description: Serenity.TextAreaEditor;
    }

    export class BulkEmailFileUploadForm extends Serenity.PrefixedContext {
        static formKey = 'Reminder.BulkEmailFileUpload';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!BulkEmailFileUploadForm.init)  {
                BulkEmailFileUploadForm.init = true;

                var s = Serenity;
                var w0 = s.LookupEditor;
                var w1 = s.DateTimeEditor;
                var w2 = s.ImageUploadEditor;
                var w3 = s.MultipleImageUploadEditor;
                var w4 = s.StringEditor;
                var w5 = s.TextAreaEditor;

                Q.initFormType(BulkEmailFileUploadForm, [
                    'FromAddress', w0,
                    'ScheduledDate', w1,
                    'FilePath', w2,
                    'UploadAttachments', w3,
                    'Title', w4,
                    'Description', w5
                ]);
            }
        }
    }
}
