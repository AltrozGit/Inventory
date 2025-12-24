namespace Indotalent.Web.Common {
    export enum PurchaseTaxType {
        GST = 1,
        TCS = 2,
        TDS = 3
    }
    Serenity.Decorators.registerEnumType(PurchaseTaxType, 'Indotalent.Web.Common.PurchaseTaxType', 'PurchaseTax.PurchaseTaxType');
}
