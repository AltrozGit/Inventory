namespace Indotalent.Merchandise {
    export interface ConfigurationForm {
        Description: Serenity.StringEditor;
        Key: Serenity.StringEditor;
        Value: Serenity.StringEditor;
        InsertDate: Serenity.DateEditor;
        InsertUserId: Serenity.IntegerEditor;
        UpdateDate: Serenity.DateEditor;
        UpdateUserId: Serenity.IntegerEditor;
        TenantId: Serenity.IntegerEditor;
    }

    export class ConfigurationForm extends Serenity.PrefixedContext {
        static formKey = 'Merchandise.Configuration';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!ConfigurationForm.init)  {
                ConfigurationForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;
                var w1 = s.DateEditor;
                var w2 = s.IntegerEditor;

                Q.initFormType(ConfigurationForm, [
                    'Description', w0,
                    'Key', w0,
                    'Value', w0,
                    'InsertDate', w1,
                    'InsertUserId', w2,
                    'UpdateDate', w1,
                    'UpdateUserId', w2,
                    'TenantId', w2
                ]);
            }
        }
    }
}
