namespace Indotalent.Material {
    export interface StatusMasterForm {
        MaterialRequestStatusName: Serenity.StringEditor;
        MaterialRequestStatusDescription: Serenity.TextAreaEditor;
    }

    export class StatusMasterForm extends Serenity.PrefixedContext {
        static formKey = 'Material.StatusMaster';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!StatusMasterForm.init)  {
                StatusMasterForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;
                var w1 = s.TextAreaEditor;

                Q.initFormType(StatusMasterForm, [
                    'MaterialRequestStatusName', w0,
                    'MaterialRequestStatusDescription', w1
                ]);
            }
        }
    }
}
