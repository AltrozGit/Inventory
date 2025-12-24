
namespace Indotalent.Inventory {

    @Serenity.Decorators.registerClass()
    export class PositiveAdjustmentDetailEditor extends Serenity.Extensions.GridEditorBase<PositiveAdjustmentDetailRow> {
        protected getColumnsKey() { return PositiveAdjustmentDetailColumns.columnsKey; }
        protected getDialogType() { return PositiveAdjustmentDetailDialog; }
        protected getLocalTextPrefix() { return PositiveAdjustmentDetailRow.localTextPrefix; }


        constructor(container: JQuery) {
            super(container);
        }

        protected validateEntity(row: PositiveAdjustmentDetailRow, id: number) {
            if (!super.validateEntity(row, id))
                return false;

            row.ProductName = Merchandise.ProductRow.getLookup()
                .itemById[row.ProductId].Name;

            return true;
        }

    }
}