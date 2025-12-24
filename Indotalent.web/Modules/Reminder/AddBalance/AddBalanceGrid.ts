
namespace Indotalent.Reminder {

    @Serenity.Decorators.registerClass()
    export class AddBalanceGrid extends Serenity.EntityGrid<AddBalanceRow, any> {
        protected getColumnsKey() { return AddBalanceColumns.columnsKey; }
        protected getDialogType() { return AddBalanceDialog; }
        protected getIdProperty() { return AddBalanceRow.idProperty; }
        protected getInsertPermission() { return AddBalanceRow.insertPermission; }
        protected getLocalTextPrefix() { return AddBalanceRow.localTextPrefix; }
        protected getService() { return AddBalanceService.baseUrl; }

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
        private addNewPlan() {
            // Logic to add a new plan
            let dialog = new PlanSettingDialog();
            
            dialog.dialogOpen();
        }
    }
}