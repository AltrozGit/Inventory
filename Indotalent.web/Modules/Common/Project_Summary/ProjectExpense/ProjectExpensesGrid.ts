
namespace Indotalent.Common {

    @Serenity.Decorators.registerClass()
    export class ProjectExpensesGrid extends Serenity.EntityGrid<Indotalent.Web.Modules.Common.Project_Summary.ProjectExpense.ProjectExpensesRow, any> {
        protected getColumnsKey() { return Indotalent.Web.Modules.Common.Project_Summary.ProjectExpense.ProjectExpensesColumns.columnsKey; }
        protected getIdProperty() { return Indotalent.Web.Modules.Common.Project_Summary.ProjectExpense.ProjectExpensesRow.idProperty; }
        //protected getNameProperty() { return ProjectExpensesRow.nameProperty; }
        protected getLocalTextPrefix() { return Indotalent.Web.Modules.Common.Project_Summary.ProjectExpense.ProjectExpensesRow.localTextPrefix; }
        protected getService() { return Indotalent.Web.Modules.Common.Project_Summary.ProjectExpense.ProjectExpensesService.baseUrl; }

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