namespace Indotalent.Settings {
    export interface CountryForm {
        CountryCode: Serenity.StringEditor;
        Name: Serenity.StringEditor;
    }

    export class CountryForm extends Serenity.PrefixedContext {
        static formKey = 'Settings.Country';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!CountryForm.init)  {
                CountryForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;

                Q.initFormType(CountryForm, [
                    'CountryCode', w0,
                    'Name', w0
                ]);
            }
        }
    }
}
