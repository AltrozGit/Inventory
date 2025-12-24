
namespace Indotalent.Common.DashboardInventory {

    @Serenity.Decorators.registerClass()
    export class MinStockGrid extends Serenity.EntityGrid<MinStockRow, any> {
        protected getColumnsKey() { return MinStockColumns.columnsKey; }
        protected getIdProperty() { return MinStockRow.idProperty; }
        protected getNameProperty() { return MinStockRow.nameProperty; }
        protected getLocalTextPrefix() { return MinStockRow.localTextPrefix; }
        protected getService() { return MinStockService.baseUrl; }

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
                service: this.getService() + '/ListExcel',
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