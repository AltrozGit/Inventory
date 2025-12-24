
namespace Indotalent.Projects.Project{

    @Serenity.Decorators.registerClass()
    export class ProjectGrid extends Serenity.EntityGrid<ProjectRow, any> {
        protected getColumnsKey() { return ProjectColumns.columnsKey; }
        protected getDialogType() { return ProjectDialog; }
        protected getIdProperty() { return ProjectRow.idProperty; }
        protected getInsertPermission() { return ProjectRow.insertPermission; }
        protected getLocalTextPrefix() { return ProjectRow.localTextPrefix; }
        protected getService() { return ProjectService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
        protected getColumns() {
            let columns = super.getColumns();

            //show amount in decimal format
            columns.forEach(col => {
                if (col.field === "TotalAllocatedFund") {
                    col.formatter = (row, cell, value, columnDef, dataContext) => {
                        return value !== null && value !== undefined ? value.toFixed(2) : ''; // Format to two decimals
                    };
                    col.cssClass = "text-right"; // This aligns the cell content to the right
                }
              
            });

         
            // Show amount in decimal format and red color if negative
            columns.forEach(col => {
                if (col.field === "TotalAvailableFund") {
                    col.formatter = (row, cell, value, columnDef, dataContext) => {
                        if (value === null || value === undefined) return '';
                        let formatted = value.toFixed(2);
                        if (value < 0) {
                            return `<span style="color: red;">${formatted}</span>`;
                        }
                        return formatted;
                    };
                    col.cssClass = "text-right"; // Align cell content to the right
                }
            });


            //show amount in decimal format
            columns.forEach(col => {
                if (col.field === "TotalProjectExpense") {
                    col.formatter = (row, cell, value, columnDef, dataContext) => {
                        return value !== null && value !== undefined ? value.toFixed(2) : ''; // Format to two decimals
                    };
                    col.cssClass = "text-right"; // This aligns the cell content to the right
                }
              
            });




            if (!Q.Authorization.hasPermission("Administration:Tenant")) {
                columns = columns.filter(x => x.field != ProjectRow.Fields.TenantName && x.field != ProjectRow.Fields.Id);
            }

            return columns;
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