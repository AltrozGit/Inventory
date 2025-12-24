
namespace Indotalent.Reminder {

    @Serenity.Decorators.registerClass()
    export class PlanGrid extends Serenity.EntityGrid<PlanRow, any> {
        protected getColumnsKey() { return PlanColumns.columnsKey; }
        protected getDialogType() { return PlanDialog; }
        protected getIdProperty() { return PlanRow.idProperty; }
        protected getInsertPermission() { return PlanRow.insertPermission; }
        protected getLocalTextPrefix() { return PlanRow.localTextPrefix; }
        protected getService() { return PlanService.baseUrl; }

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

    }
}