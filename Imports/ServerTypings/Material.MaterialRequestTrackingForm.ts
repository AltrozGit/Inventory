namespace Indotalent.Material {
    export interface MaterialRequestTrackingForm {
        Comment: Serenity.TextAreaEditor;
    }

    export class MaterialRequestTrackingForm extends Serenity.PrefixedContext {
        static formKey = 'Material.MaterialRequestTracking';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!MaterialRequestTrackingForm.init)  {
                MaterialRequestTrackingForm.init = true;

                var s = Serenity;
                var w0 = s.TextAreaEditor;

                Q.initFormType(MaterialRequestTrackingForm, [
                    'Comment', w0
                ]);
            }
        }
    }
}
