
namespace Indotalent.Reminder {

    @Serenity.Decorators.registerClass()
    export class DueDateReminderGrid extends Serenity.EntityGrid<DueDateReminderRow, any> {
        protected getColumnsKey() { return DueDateReminderColumns.columnsKey; }
        protected getDialogType() { return DueDateReminderDialog; }
        protected getIdProperty() { return DueDateReminderRow.idProperty; }
        protected getInsertPermission() { return DueDateReminderRow.insertPermission; }
        protected getLocalTextPrefix() { return DueDateReminderRow.localTextPrefix; }
        protected getService() { return DueDateReminderService.baseUrl; }

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