
namespace Indotalent.Inventory {

    @Serenity.Decorators.registerClass()
    export class TransferOrderDetailEditor extends Serenity.Extensions.GridEditorBase<TransferOrderDetailRow> {
        protected getColumnsKey() { return TransferOrderDetailColumns.columnsKey; }
        protected getDialogType() { return TransferOrderDetailDialog; }
        protected getLocalTextPrefix() { return TransferOrderDetailRow.localTextPrefix; }


        constructor(container: JQuery) {
            super(container);
        }

        protected validateEntity(row: TransferOrderDetailRow, id: number) {
            if (!super.validateEntity(row, id))
                return false;

            row.ProductName = Merchandise.ProductRow.getLookup()
                .itemById[row.ProductId].Name;

            return true;
        }

    }
}