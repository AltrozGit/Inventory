
namespace Indotalent.Inventory {

    @Serenity.Decorators.registerClass()
    export class PositiveAdjustmentDetailGrid extends Serenity.EntityGrid<PositiveAdjustmentDetailRow, any> {
        protected getColumnsKey() { return PositiveAdjustmentDetailColumns.columnsKey; }
        protected getDialogType() { return PositiveAdjustmentDetailDialog; }
        protected getIdProperty() { return PositiveAdjustmentDetailRow.idProperty; }
        protected getInsertPermission() { return PositiveAdjustmentDetailRow.insertPermission; }
        protected getLocalTextPrefix() { return PositiveAdjustmentDetailRow.localTextPrefix; }
        protected getService() { return PositiveAdjustmentDetailService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}