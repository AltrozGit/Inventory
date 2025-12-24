
namespace Indotalent.Material {

    @Serenity.Decorators.registerClass()
    export class MaterialReturnDetailEditor extends Serenity.Extensions.GridEditorBase<MaterialReturnDetailRow> {
        protected getColumnsKey() { return MaterialReturnDetailColumns.columnsKey; }
        protected getDialogType() { return MaterialReturnDetailDialog; }
        protected getLocalTextPrefix() { return MaterialReturnDetailRow.localTextPrefix; }


        constructor(container: JQuery) {
            super(container);
        }

        protected validateEntity(row: MaterialReturnDetailRow, id: number) {
            if (!super.validateEntity(row, id))
                return false;

            row.ProductName = Merchandise.ProductRow.getLookup()
                .itemById[row.ProductId].Name;

            return true;
        }


    }



}