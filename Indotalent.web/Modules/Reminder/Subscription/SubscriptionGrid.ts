
namespace Indotalent.Reminder {

    @Serenity.Decorators.registerClass()
    export class SubscriptionGrid extends Serenity.EntityGrid<SubscriptionRow, any> {
        protected getColumnsKey() { return SubscriptionColumns.columnsKey; }
        protected getDialogType() { return SubscriptionDialog; }
        protected getIdProperty() { return SubscriptionRow.idProperty; }
        protected getInsertPermission() { return SubscriptionRow.insertPermission; }
        protected getLocalTextPrefix() { return SubscriptionRow.localTextPrefix; }
        protected getService() { return SubscriptionService.baseUrl; }

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