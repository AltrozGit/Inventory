namespace Indotalent.Settings {
    export interface StateForm {
        StateCode: Serenity.StringEditor;
        Name: Serenity.StringEditor;
        CountryId: Serenity.LookupEditor;
    }

    export class StateForm extends Serenity.PrefixedContext {
        static formKey = 'Settings.State';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!StateForm.init)  {
                StateForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;
                var w1 = s.LookupEditor;

                Q.initFormType(StateForm, [
                    'StateCode', w0,
                    'Name', w0,
                    'CountryId', w1
                ]);
            }
        }
    }
}
