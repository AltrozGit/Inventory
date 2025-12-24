
namespace Indotalent.Common{

    @Serenity.Decorators.registerClass()
    export class IssueStockGrid extends Serenity.EntityGrid<Indotalent.Web.Modules.Common.Project_Summary.IssuedStock.IssueStockRow, any> {
        protected getColumnsKey() { return Indotalent.Web.Modules.Common.Project_Summary.IssuedStock.IssueStockColumns.columnsKey; }
        protected getIdProperty() { return Indotalent.Web.Modules.Common.Project_Summary.IssuedStock.IssueStockRow.idProperty; }
        //protected getNameProperty() { return IssueStockRow.nameProperty; }
        protected getLocalTextPrefix() { return Indotalent.Web.Modules.Common.Project_Summary.IssuedStock.IssueStockRow.localTextPrefix; }
        protected getService() { return Indotalent.Web.Modules.Common.Project_Summary.IssuedStock.IssueStockService.baseUrl; }

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