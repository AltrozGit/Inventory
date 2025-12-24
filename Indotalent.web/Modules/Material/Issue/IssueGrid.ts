
namespace Indotalent.Material {

    @Serenity.Decorators.registerClass()
    export class IssueGrid extends Serenity.EntityGrid<IssueRow, any> {
        protected getColumnsKey() { return IssueColumns.columnsKey; }
        protected getDialogType() { return IssueDialog; }
        protected getIdProperty() { return IssueRow.idProperty; }
        protected getInsertPermission() { return IssueRow.insertPermission; }
        protected getLocalTextPrefix() { return IssueRow.localTextPrefix; }
        protected getService() { return IssueService.baseUrl; }

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
        protected getColumns(){
            var columns = super.getColumns();

            //show amount should be in decimal 
            columns.forEach(col => {
                // List the columns that should have decimal formatting using indexOf
                if (["TotalQtyIssue", "Total"].indexOf(col.field) !== -1) {
                    col.formatter = (row, cell, value, columnDef, dataContext) => {
                        return value !== null && value !== undefined ? value.toFixed(2) : ''; // Format to two decimals
                    };
                    col.cssClass = "text-right"; // This aligns the cell content to the right
                }
            });

            columns.splice(1, 0, {
                id: 'Print Selected',
                field: null,
                name: 'Delivery challan',
                format: ctx => '<a class="inline-action print-selected" title="print-selected">' +
                    '<i class="fa fa-file-pdf-o text-red"></i></a>',
                width: 100,
                sortable: true,
            });
            columns.splice(2, 0, {
                field: 'IssueDate',
                name: 'Month - Year',
                width: 100,
                sortable: true,
                format: (ctx) => {
                    const issueItem = ctx.item as IssueRow;
                    const date = new Date(issueItem.IssueDate);
                    const options: Intl.DateTimeFormatOptions = { month: 'short', year: 'numeric' };
                    return date.toLocaleDateString('en-US', options).replace(',', ' -');
                }
            });

            if (!Q.Authorization.hasPermission("Administration:Tenant")) {
                columns = columns.filter(x => x.field != IssueRow.Fields.TenantName && x.field != IssueRow.Fields.Id);
            }


            return columns;
        }
        protected onClick(e: JQueryEventObject, row: number, cell: number) {
            super.onClick(e, row, cell);

            if (e.isDefaultPrevented())
                return;

            var item = this.itemAt(row);
            var target = $(e.target);

            // if user clicks "i" element, e.g. icon
            if (target.parent().hasClass('inline-action'))
                target = target.parent();

            if (target.hasClass('inline-action')) {
                e.preventDefault();

                if (target.hasClass('print-selected')) {
                    Serenity.Extensions.ReportHelper.execute({
                        reportKey: 'IssuePrint',
                        params: {
                            Id: item.Id
                        }
                    });

                }

            }

        }
    }
}