
namespace Indotalent.Common.DashboardInventory {

    @Serenity.Decorators.registerClass()
    export class MostSoldGrid extends Serenity.EntityGrid<MostSoldRow, any> {
        protected getColumnsKey() { return MostSoldColumns.columnsKey; }
        protected getIdProperty() { return MostSoldRow.idProperty; }
        protected getNameProperty() { return MostSoldRow.nameProperty; }
        protected getLocalTextPrefix() { return MostSoldRow.localTextPrefix; }
        protected getService() { return MostSoldService.baseUrl; }

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