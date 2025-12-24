namespace Indotalent.Material {
    export interface MaterialRequestStatusForm {
        StatustId: Serenity.LookupEditor;
        Description: Serenity.TextAreaEditor;
    }

    export class MaterialRequestStatusForm extends Serenity.PrefixedContext {
        static formKey = 'Material.MaterialRequestStatus';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!MaterialRequestStatusForm.init)  {
                MaterialRequestStatusForm.init = true;

                var s = Serenity;
                var w0 = s.LookupEditor;
                var w1 = s.TextAreaEditor;

                Q.initFormType(MaterialRequestStatusForm, [
                    'StatustId', w0,
                    'Description', w1
                ]);
            }
        }
    }
}
