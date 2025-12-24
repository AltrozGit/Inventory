
namespace Indotalent.Projects {

    @Serenity.Decorators.registerClass()
    export class ProjectExpenseGrid extends Serenity.EntityGrid<ProjectExpenseRow, any> {
        protected getColumnsKey() { return ProjectExpenseColumns.columnsKey; }
        protected getDialogType() { return ProjectExpenseDialog; }
        protected getIdProperty() { return ProjectExpenseRow.idProperty; }
        protected getInsertPermission() { return ProjectExpenseRow.insertPermission; }
        protected getLocalTextPrefix() { return ProjectExpenseRow.localTextPrefix; }
        protected getService() { return ProjectExpenseService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
        protected getColumns(): Slick.Column[] {

            var columns = super.getColumns();

            // Directly modify the "Cost" column formatter
            columns.forEach(col => {
                if (col.field === "Cost") {
                    col.formatter = (row, cell, value, columnDef, dataContext) => {
                        return value !== null && value !== undefined ? value.toFixed(2) : ''; // Format to two decimals
                    };
                    col.cssClass = "text-right"; // This aligns the cell content to the right
                }
            });

            columns.push(
                {
                    field: "DeleteRow",
                    name: "",
                    format: ctx => {
                        return "<a class='inline-action delete-row' title='delete'></a>";
                    },
                    width: 24,
                    minWidth: 24,
                    maxWidth: 24
                });

            return columns;
        }

        protected onClick(e: JQueryEventObject, row: number, cell: number): void {
            super.onClick(e, row, cell);

            let item = this.itemAt(row);

            if ($(e.target).hasClass('delete-row')) {
                e.preventDefault();
                ProjectExpenseService.Delete({ EntityId: item.Id }, (r) => this.refresh());
            }
        }
    }
}