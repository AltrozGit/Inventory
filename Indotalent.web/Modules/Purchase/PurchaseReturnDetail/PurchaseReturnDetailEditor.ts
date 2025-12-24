
namespace Indotalent.Purchase {

    @Serenity.Decorators.registerClass()
    export class PurchaseReturnDetailEditor extends Serenity.Extensions.GridEditorBase<PurchaseReturnDetailRow> {
        protected getColumnsKey() { return PurchaseReturnDetailColumns.columnsKey; }
        protected getDialogType() { return PurchaseReturnDetailDialog; }
        protected getLocalTextPrefix() { return PurchaseReturnDetailRow.localTextPrefix; }


        constructor(container: JQuery) {
            super(container);
        }

        protected validateEntity(row: PurchaseReturnDetailRow, id: number) {
            if (!super.validateEntity(row, id))
                return false;

            row.ProductName = Merchandise.ProductRow.getLookup()
                .itemById[row.ProductId].Name;

            return true;
        }


    }



}