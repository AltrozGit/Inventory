namespace Indotalent.Inventory {
    export interface LocationForm {
        Name: Serenity.StringEditor;
        Description: Serenity.TextAreaEditor;
    }

    export class LocationForm extends Serenity.PrefixedContext {
        static formKey = 'Inventory.Location';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!LocationForm.init)  {
                LocationForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;
                var w1 = s.TextAreaEditor;

                Q.initFormType(LocationForm, [
                    'Name', w0,
                    'Description', w1
                ]);
            }
        }
    }
}
