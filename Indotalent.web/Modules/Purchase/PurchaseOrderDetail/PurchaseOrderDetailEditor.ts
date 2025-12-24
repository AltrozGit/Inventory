
namespace Indotalent.Purchase {

    @Serenity.Decorators.registerClass()
    export class PurchaseOrderDetailEditor extends Serenity.Extensions.GridEditorBase<PurchaseOrderDetailRow> {
        protected getColumnsKey() { return PurchaseOrderDetailColumns.columnsKey; }
        protected getDialogType() { return PurchaseOrderDetailDialog; }
        protected getLocalTextPrefix() { return PurchaseOrderDetailRow.localTextPrefix; }
        columns: any;

        constructor(container: JQuery) {
            super(container);

            // Individual row checkbox click
            this.slickGrid.onClick.subscribe((e, args) => {
                let field = args.grid.getColumns()[args.cell].field;
                if (field === 'IsSelected') {
                    let item = this.itemAt(args.row);
                    item.IsSelected = !item.IsSelected;
                    this.view.refresh();

                    // Sync "Select All" checkbox
                    setTimeout(() => {
                        const allSelected = this.getItems().every(x => x.IsSelected);
                        (document.getElementById('select-all-rows') as HTMLInputElement).checked = allSelected;
                    });

                }
            });

            // Handle "Select All" checkbox click
            this.element.on('click', '#select-all-rows', e => {
                const checked = (e.target as HTMLInputElement).checked;

                for (let item of this.getItems()) {
                    item.IsSelected = checked;
                }

                this.view.setItems(this.getItems(), true); // force grid rebind
            });
        }

        protected getColumns(): Slick.Column[] {
            let columns = super.getColumns();

            columns.unshift({
                field: 'IsSelected',
                name: `<input type="checkbox" id="select-all-rows">`,
                width: 30,
                format: ctx => `<input type="checkbox" ${ctx.value ? 'checked' : ''}>`,
                sortable: false,
                headerCssClass: 'align-center',
                cssClass: 'align-center'
            });

            return columns;
        }



        protected onViewProcessData(response: Serenity.ListResponse<PurchaseOrderDetailRow>): Serenity.ListResponse<PurchaseOrderDetailRow> {
            response = super.onViewProcessData(response);


            for (let item of response.Entities) {
                if (item.IsSelected == null)
                    item.IsSelected = true;
            }

            return response;
        }

        protected validateEntity(row: PurchaseOrderDetailRow, id: number) {
            if (!super.validateEntity(row, id))
                return false;

            row.ProductName = Merchandise.ProductRow.getLookup()
                .itemById[row.ProductId].Name;

                


            return true;
        }
        
    }



}