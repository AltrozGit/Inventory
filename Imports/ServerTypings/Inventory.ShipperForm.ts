namespace Indotalent.Inventory {
    export interface ShipperForm {
        Name: Serenity.StringEditor;
        Description: Serenity.TextAreaEditor;
        Street: Serenity.StringEditor;
        City: Serenity.StringEditor;
        State: Serenity.StringEditor;
        ZipCode: Serenity.StringEditor;
        Phone: Serenity.StringEditor;
        Email: Serenity.StringEditor;
    }

    export class ShipperForm extends Serenity.PrefixedContext {
        static formKey = 'Inventory.Shipper';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!ShipperForm.init)  {
                ShipperForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;
                var w1 = s.TextAreaEditor;

                Q.initFormType(ShipperForm, [
                    'Name', w0,
                    'Description', w1,
                    'Street', w0,
                    'City', w0,
                    'State', w0,
                    'ZipCode', w0,
                    'Phone', w0,
                    'Email', w0
                ]);
            }
        }
    }
}
