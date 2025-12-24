
namespace Indotalent.Reminder {

    @Serenity.Decorators.registerClass()
    export class TenantUnitTransactionGrid extends Serenity.EntityGrid<TenantUnitTransactionRow, any> {
        protected getColumnsKey() { return TenantUnitTransactionColumns.columnsKey; }
        protected getDialogType() { return TenantUnitTransactionDialog; }
        protected getIdProperty() { return TenantUnitTransactionRow.idProperty; }
        protected getInsertPermission() { return TenantUnitTransactionRow.insertPermission; }
        protected getLocalTextPrefix() { return TenantUnitTransactionRow.localTextPrefix; }
        protected getService() { return TenantUnitTransactionService.baseUrl; }

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