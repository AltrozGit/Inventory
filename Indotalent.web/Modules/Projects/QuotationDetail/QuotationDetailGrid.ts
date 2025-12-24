
namespace Indotalent.Projects {

    @Serenity.Decorators.registerClass()
    export class QuotationDetailGrid extends Serenity.EntityGrid<QuotationDetailRow, any> {
        protected getColumnsKey() { return QuotationDetailColumns.columnsKey; }
        protected getDialogType() { return QuotationDetailDialog; }
        protected getIdProperty() { return QuotationDetailRow.idProperty; }
        protected getInsertPermission() { return QuotationDetailRow.insertPermission; }
        protected getLocalTextPrefix() { return QuotationDetailRow.localTextPrefix; }
        protected getService() { return QuotationDetailService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}