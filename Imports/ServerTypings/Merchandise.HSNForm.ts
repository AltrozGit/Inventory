namespace Indotalent.Merchandise {
    export interface HSNForm {
        HsnCode: Serenity.StringEditor;
        HsnDescription: Serenity.StringEditor;
        HsnName: Serenity.StringEditor;
    }

    export class HSNForm extends Serenity.PrefixedContext {
        static formKey = 'Merchandise.HSN';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!HSNForm.init)  {
                HSNForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;

                Q.initFormType(HSNForm, [
                    'HsnCode', w0,
                    'HsnDescription', w0,
                    'HsnName', w0
                ]);
            }
        }
    }
}
