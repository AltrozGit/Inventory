
namespace Indotalent.Sales {

    @Serenity.Decorators.registerClass()
    export class SalesDeliveryDetailEditor extends Serenity.Extensions.GridEditorBase<SalesDeliveryDetailRow> {
        protected getColumnsKey() { return SalesDeliveryDetailColumns.columnsKey; }
        protected getDialogType() { return SalesDeliveryDetailDialog; }
        protected getLocalTextPrefix() { return SalesDeliveryDetailRow.localTextPrefix; }


        constructor(container: JQuery) {
            super(container);
        }

        protected validateEntity(row: SalesDeliveryDetailRow, id: number) {
            if (!super.validateEntity(row, id))
                return false;

            row.ProductName = Merchandise.ProductRow.getLookup()
                .itemById[row.ProductId].Name;

            return true;
        }


    }



}