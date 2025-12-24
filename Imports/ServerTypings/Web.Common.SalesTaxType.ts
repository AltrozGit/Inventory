namespace Indotalent.Web.Common {
    export enum SalesTaxType {
        GST = 1,
        TCS = 2,
        TDS = 3
    }
    Serenity.Decorators.registerEnumType(SalesTaxType, 'Indotalent.Web.Common.SalesTaxType', 'SalesTax.SalesTaxType');
}
