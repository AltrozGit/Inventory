namespace Indotalent.Settings {
    export interface SalesTaxForm {
        TaxType: Serenity.EnumEditor;
        Name: Serenity.StringEditor;
        Description: Serenity.TextAreaEditor;
        TaxRatePercentage: Serenity.DecimalEditor;
        SGST: Serenity.DecimalEditor;
        CGST: Serenity.DecimalEditor;
        IGST: Serenity.DecimalEditor;
    }

    export class SalesTaxForm extends Serenity.PrefixedContext {
        static formKey = 'Settings.SalesTax';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!SalesTaxForm.init)  {
                SalesTaxForm.init = true;

                var s = Serenity;
                var w0 = s.EnumEditor;
                var w1 = s.StringEditor;
                var w2 = s.TextAreaEditor;
                var w3 = s.DecimalEditor;

                Q.initFormType(SalesTaxForm, [
                    'TaxType', w0,
                    'Name', w1,
                    'Description', w2,
                    'TaxRatePercentage', w3,
                    'SGST', w3,
                    'CGST', w3,
                    'IGST', w3
                ]);
            }
        }
    }
}
