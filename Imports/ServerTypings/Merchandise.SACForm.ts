namespace Indotalent.Merchandise {
    export interface SACForm {
        SacCode: Serenity.StringEditor;
        SacDescription: Serenity.StringEditor;
        SacName: Serenity.StringEditor;
    }

    export class SACForm extends Serenity.PrefixedContext {
        static formKey = 'Merchandise.SAC';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!SACForm.init)  {
                SACForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;

                Q.initFormType(SACForm, [
                    'SacCode', w0,
                    'SacDescription', w0,
                    'SacName', w0
                ]);
            }
        }
    }
}
