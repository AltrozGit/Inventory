
namespace Indotalent.Projects {

    @Serenity.Decorators.registerClass()
    export class QuotationDetailEditor extends Serenity.Extensions.GridEditorBase<QuotationDetailRow> {
        protected getColumnsKey() { return QuotationDetailColumns.columnsKey; }
        protected getDialogType() { return QuotationDetailDialog; }
        protected getLocalTextPrefix() { return QuotationDetailRow.localTextPrefix; }

        public CustomerId: string;

        public set CustomerState(value: string) {
            this.CustomerId = value;
        }

        initDialog(dlg: QuotationDetailDialog) {
            super.initDialog(dlg);
            dlg.CustomerIdFromEditor = this.CustomerId;
        }
        constructor(container: JQuery) {
            super(container);
        }

        protected validateEntity(row: QuotationDetailRow, id: number) {
            if (!super.validateEntity(row, id))
                return false;

            row.ProductName = Merchandise.ProductRow.getLookup()
                .itemById[row.ProductId].Name;

            return true;
        }

    }
}