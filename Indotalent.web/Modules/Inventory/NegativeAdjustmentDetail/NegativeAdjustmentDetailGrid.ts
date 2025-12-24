
namespace Indotalent.Inventory {

    @Serenity.Decorators.registerClass()
    export class NegativeAdjustmentDetailGrid extends Serenity.EntityGrid<NegativeAdjustmentDetailRow, any> {
        protected getColumnsKey() { return NegativeAdjustmentDetailColumns.columnsKey; }
        protected getDialogType() { return NegativeAdjustmentDetailDialog; }
        protected getIdProperty() { return NegativeAdjustmentDetailRow.idProperty; }
        protected getInsertPermission() { return NegativeAdjustmentDetailRow.insertPermission; }
        protected getLocalTextPrefix() { return NegativeAdjustmentDetailRow.localTextPrefix; }
        protected getService() { return NegativeAdjustmentDetailService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}