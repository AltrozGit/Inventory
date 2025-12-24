
namespace Indotalent.Purchase {

    @Serenity.Decorators.registerClass()
    export class PaymentTermGrid extends Serenity.EntityGrid<PaymentTermRow, any> {
        protected getColumnsKey() { return PaymentTermColumns.columnsKey; }
        protected getDialogType() { return PaymentTermDialog; }
        protected getIdProperty() { return PaymentTermRow.idProperty; }
        protected getInsertPermission() { return PaymentTermRow.insertPermission; }
        protected getLocalTextPrefix() { return PaymentTermRow.localTextPrefix; }
        protected getService() { return PaymentTermService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}