namespace Indotalent.Purchase {
    export interface VendorForm {
        Name: Serenity.StringEditor;
        Description: Serenity.TextAreaEditor;
        Logo: Serenity.ImageUploadEditor;
        Street: Serenity.StringEditor;
        City: Serenity.StringEditor;
        CountryId: Serenity.LookupEditor;
        StateId: Serenity.LookupEditor;
        ZipCode: Serenity.StringEditor;
        Phone: Serenity.StringEditor;
        Email: Serenity.StringEditor;
        PaymentTermId: Serenity.LookupEditor;
        GSTNumber: Serenity.StringEditor;
        BankName: Serenity.StringEditor;
        BankBranch: Serenity.StringEditor;
        AccountNumber: Serenity.StringEditor;
        IFSCCode: Serenity.StringEditor;
        PanNumber: Serenity.StringEditor;
        ContactList: VendorContactEditor;
    }

    export class VendorForm extends Serenity.PrefixedContext {
        static formKey = 'Purchase.Vendor';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!VendorForm.init)  {
                VendorForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;
                var w1 = s.TextAreaEditor;
                var w2 = s.ImageUploadEditor;
                var w3 = s.LookupEditor;
                var w4 = VendorContactEditor;

                Q.initFormType(VendorForm, [
                    'Name', w0,
                    'Description', w1,
                    'Logo', w2,
                    'Street', w0,
                    'City', w0,
                    'CountryId', w3,
                    'StateId', w3,
                    'ZipCode', w0,
                    'Phone', w0,
                    'Email', w0,
                    'PaymentTermId', w3,
                    'GSTNumber', w0,
                    'BankName', w0,
                    'BankBranch', w0,
                    'AccountNumber', w0,
                    'IFSCCode', w0,
                    'PanNumber', w0,
                    'ContactList', w4
                ]);
            }
        }
    }
}
