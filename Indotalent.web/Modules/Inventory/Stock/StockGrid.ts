
namespace Indotalent.Inventory {

    @Serenity.Decorators.registerClass()
    export class StockGrid extends Serenity.EntityGrid<StockRow, any> {
        protected getColumnsKey() { return StockColumns.columnsKey; }
        protected getIdProperty() { return StockRow.idProperty; }
        protected getNameProperty() { return StockRow.nameProperty; }
        protected getLocalTextPrefix() { return StockRow.localTextPrefix; }
        protected getService() { return StockService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }


        protected updateInterface(): void {
            super.updateInterface();
            var addButton = this.toolbar.findButton('add-button');
            addButton.hide();
        }


        protected getButtons() {
            var buttons = super.getButtons();

            buttons.push(Serenity.Extensions.ExcelExportHelper.createToolButton({
                grid: this,
                service: StockService.baseUrl + '/ListExcel',
                onViewSubmit: () => this.onViewSubmit(),
                separator: true
            }));

            buttons.push(Serenity.Extensions.PdfExportHelper.createToolButton({
                grid: this,
                onViewSubmit: () => this.onViewSubmit()
            }));

            return buttons;
        }
    }
}