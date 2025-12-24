
namespace Indotalent.Inventory {

    @Serenity.Decorators.registerClass()
    export class MovementGrid extends Serenity.EntityGrid<MovementRow, any> {
        protected getColumnsKey() { return MovementColumns.columnsKey; }
        protected getIdProperty() { return MovementRow.idProperty; }
        protected getNameProperty() { return MovementRow.nameProperty; }
        protected getLocalTextPrefix() { return MovementRow.localTextPrefix; }
        protected getService() { return MovementService.baseUrl; }

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
                service: MovementService.baseUrl + '/ListExcel',
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