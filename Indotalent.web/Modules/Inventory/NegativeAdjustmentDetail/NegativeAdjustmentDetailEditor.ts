
namespace Indotalent.Inventory {

    @Serenity.Decorators.registerClass()
    export class NegativeAdjustmentDetailEditor extends Serenity.Extensions.GridEditorBase<NegativeAdjustmentDetailRow> {
        protected getColumnsKey() { return NegativeAdjustmentDetailColumns.columnsKey; }
        protected getDialogType() { return NegativeAdjustmentDetailDialog; }
        protected getLocalTextPrefix() { return NegativeAdjustmentDetailRow.localTextPrefix; }


        constructor(container: JQuery) {
            super(container);
        }

        protected validateEntity(row: NegativeAdjustmentDetailRow, id: number) {
            if (!super.validateEntity(row, id))
                return false;

            row.ProductName = Merchandise.ProductRow.getLookup()
                .itemById[row.ProductId].Name;

            return true;
        }

    }
}