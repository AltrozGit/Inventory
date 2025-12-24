
namespace Indotalent.Purchase {

    @Serenity.Decorators.registerClass()
    export class PurchaseReceiptDetailEditor extends Serenity.Extensions.GridEditorBase<PurchaseReceiptDetailRow> {
        protected getColumnsKey() { return PurchaseReceiptDetailColumns.columnsKey; }
        protected getDialogType() { return PurchaseReceiptDetailDialog; }
        protected getLocalTextPrefix() { return PurchaseReceiptDetailRow.localTextPrefix; }


        constructor(container: JQuery) {
            super(container);
        }

        protected validateEntity(row: PurchaseReceiptDetailRow, id: number) {
            if (!super.validateEntity(row, id))
                return false;

            row.ProductName = Merchandise.ProductRow.getLookup()
                .itemById[row.ProductId].Name;

            return true;
        }


    }



}