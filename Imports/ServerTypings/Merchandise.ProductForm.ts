namespace Indotalent.Merchandise {
    export interface ProductForm {
        Name: Serenity.StringEditor;
        ProductType: Serenity.EnumEditor;
        HsnId: Serenity.LookupEditor;
        SacId: Serenity.LookupEditor;
        UomId: Serenity.LookupEditor;
        Barcode: Serenity.StringEditor;
        Description: Serenity.TextAreaEditor;
        MinimumQty: Serenity.DecimalEditor;
        Picture: Serenity.ImageUploadEditor;
        BrandId: Serenity.LookupEditor;
        CategoryId: Serenity.LookupEditor;
        SizeId: Serenity.LookupEditor;
        ColourId: Serenity.LookupEditor;
        FlavourId: Serenity.LookupEditor;
        CurrencyName: Serenity.StringEditor;
        PurchasePrice: Serenity.DecimalEditor;
        PurchaseTaxId: Serenity.LookupEditor;
        SalesPrice: Serenity.DecimalEditor;
        SalesTaxId: Serenity.LookupEditor;
        InternalCode: Serenity.StringEditor;
    }

    export class ProductForm extends Serenity.PrefixedContext {
        static formKey = 'Merchandise.Product';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!ProductForm.init)  {
                ProductForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;
                var w1 = s.EnumEditor;
                var w2 = s.LookupEditor;
                var w3 = s.TextAreaEditor;
                var w4 = s.DecimalEditor;
                var w5 = s.ImageUploadEditor;

                Q.initFormType(ProductForm, [
                    'Name', w0,
                    'ProductType', w1,
                    'HsnId', w2,
                    'SacId', w2,
                    'UomId', w2,
                    'Barcode', w0,
                    'Description', w3,
                    'MinimumQty', w4,
                    'Picture', w5,
                    'BrandId', w2,
                    'CategoryId', w2,
                    'SizeId', w2,
                    'ColourId', w2,
                    'FlavourId', w2,
                    'CurrencyName', w0,
                    'PurchasePrice', w4,
                    'PurchaseTaxId', w2,
                    'SalesPrice', w4,
                    'SalesTaxId', w2,
                    'InternalCode', w0
                ]);
            }
        }
    }
}
