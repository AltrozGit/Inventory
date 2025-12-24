
namespace Indotalent.Sales {

    @Serenity.Decorators.registerClass()
    export class SalesReturnDetailEditor extends Serenity.Extensions.GridEditorBase<SalesReturnDetailRow> {
        protected getColumnsKey() { return SalesReturnDetailColumns.columnsKey; }
        protected getDialogType() { return SalesReturnDetailDialog; }
        protected getLocalTextPrefix() { return SalesReturnDetailRow.localTextPrefix; }


        constructor(container: JQuery) {
            super(container);
        }

        protected validateEntity(row: SalesReturnDetailRow, id: number) {
            if (!super.validateEntity(row, id))
                return false;

            row.ProductName = Merchandise.ProductRow.getLookup()
                .itemById[row.ProductId].Name;

            return true;
        }


    }



}