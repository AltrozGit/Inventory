namespace Indotalent.Web.Modules.Sales.Invoice {
    export enum TaxTypeTDSTCS {
        TDS = 1,
        TCS = 2
    }
    Serenity.Decorators.registerEnumType(TaxTypeTDSTCS, 'Indotalent.Web.Modules.Sales.Invoice.TaxTypeTDSTCS', 'Sales.TaxTypeTDSTCS');
}
