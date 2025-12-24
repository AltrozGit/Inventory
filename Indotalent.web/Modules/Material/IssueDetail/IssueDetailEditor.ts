
namespace Indotalent.Material {

    @Serenity.Decorators.registerClass()
    export class IssueDetailEditor extends Serenity.Extensions.GridEditorBase<IssueDetailRow> {
        protected getColumnsKey() { return IssueDetailColumns.columnsKey; }
        protected getDialogType() { return IssueDetailDialog; }
        protected getLocalTextPrefix() { return IssueDetailRow.localTextPrefix; }


        constructor(container: JQuery) {
            super(container);
        }

        protected validateEntity(row: IssueDetailRow, id: number) {
            if (!super.validateEntity(row, id))
                return false;

            row.ProductName = Merchandise.ProductRow.getLookup()
                .itemById[row.ProductId].Name;
          
            return true;
        }

    }
}