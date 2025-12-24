namespace Indotalent.Sales {
    export interface CustomerForm {
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
        BillingAddress: Serenity.StringEditor;
        ShippingAddress: Serenity.StringEditor;
        GSTNumber: Serenity.StringEditor;
        ContactList: CustomerContactEditor;
    }

    export class CustomerForm extends Serenity.PrefixedContext {
        static formKey = 'Sales.Customer';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!CustomerForm.init)  {
                CustomerForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;
                var w1 = s.TextAreaEditor;
                var w2 = s.ImageUploadEditor;
                var w3 = s.LookupEditor;
                var w4 = CustomerContactEditor;

                Q.initFormType(CustomerForm, [
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
                    'BillingAddress', w0,
                    'ShippingAddress', w0,
                    'GSTNumber', w0,
                    'ContactList', w4
                ]);
            }
        }
    }
}
