
namespace Indotalent.Material {

    @Serenity.Decorators.registerClass()
    export class RequestDetailEditor extends Serenity.Extensions.GridEditorBase<RequestDetailRow> {
        protected getColumnsKey() { return RequestDetailColumns.columnsKey; }
        protected getDialogType() { return RequestDetailDialog; }
        protected getLocalTextPrefix() { return RequestDetailRow.localTextPrefix; }


        constructor(container: JQuery) {
            super(container);
        }

        protected validateEntity(row: RequestDetailRow, id: number) {
            if (!super.validateEntity(row, id))
                return false;

            row.ProductName = Merchandise.ProductRow.getLookup()
                .itemById[row.ProductId].Name;

            return true;
        }
    }
}