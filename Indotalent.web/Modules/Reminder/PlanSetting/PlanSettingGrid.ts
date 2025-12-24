
namespace Indotalent.Reminder {

    @Serenity.Decorators.registerClass()
    export class PlanSettingGrid extends Serenity.EntityGrid<PlanSettingRow, any> {
        protected getColumnsKey() { return PlanSettingColumns.columnsKey; }
        protected getDialogType() { return PlanSettingDialog; }
        protected getIdProperty() { return PlanSettingRow.idProperty; }
        protected getInsertPermission() { return PlanSettingRow.insertPermission; }
        protected getLocalTextPrefix() { return PlanSettingRow.localTextPrefix; }
        protected getService() { return PlanSettingService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
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
        protected updateInterface(): void {
            super.updateInterface();
            if (!Q.Authorization.hasPermission("Reminder:PlanSetting")) {
                var addButton = this.toolbar.findButton('add-button');
                var updateButton = this.toolbar.findButton('update-button');
                updateButton.hide();
                addButton.hide();

            }

        }
    }
}