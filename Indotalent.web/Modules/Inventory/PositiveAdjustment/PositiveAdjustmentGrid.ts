
namespace Indotalent.Inventory {

    @Serenity.Decorators.registerClass()
    export class PositiveAdjustmentGrid extends Serenity.EntityGrid<PositiveAdjustmentRow, any> {
        protected getColumnsKey() { return PositiveAdjustmentColumns.columnsKey; }
        protected getDialogType() { return PositiveAdjustmentDialog; }
        protected getIdProperty() { return PositiveAdjustmentRow.idProperty; }
        protected getInsertPermission() { return PositiveAdjustmentRow.insertPermission; }
        protected getLocalTextPrefix() { return PositiveAdjustmentRow.localTextPrefix; }
        protected getService() { return PositiveAdjustmentService.baseUrl; }

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


        protected getColumns() {
            var columns = super.getColumns();

            //show amount in decimal format
            columns.forEach(col => {
                if (col.field === "TotalQty") {
                    col.formatter = (row, cell, value, columnDef, dataContext) => {
                        return value !== null && value !== undefined ? value.toFixed(2) : ''; // Format to two decimals
                    };
                    col.cssClass = "text-right"; // This aligns the cell content to the right
                }
            });

            columns.splice(1, 0, {
                id: 'Print Selected',
                field: null,
                name: '',
                format: ctx => '<a class="inline-action print-selected" title="print-selected">' +
                    '<i class="fa fa-file-pdf-o text-red"></i></a>',
                width: 24,
                minWidth: 24,
                maxWidth: 24
            });
            columns.splice(2, 0, {
                field: 'AdjustmentDate',
                name: 'Month - Year',
                width: 100,
                sortable: true,
                format: (ctx) => {
                    const adjustmentItem = ctx.item as PositiveAdjustmentRow;
                    const date = new Date(adjustmentItem.AdjustmentDate);
                    const options: Intl.DateTimeFormatOptions = { month: 'short', year: 'numeric' };
                    return date.toLocaleDateString('en-US', options).replace(',', ' -');
                }
            });
            if (!Q.Authorization.hasPermission("Administration:Tenant")) {
                columns = columns.filter(x => x.field != PositiveAdjustmentRow.Fields.TenantName && x.field != PositiveAdjustmentRow.Fields.Id);
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
                        reportKey: 'PositiveAdjustmentPrint',
                        params: {
                            Id: item.Id
                        }
                    });
                }
            }
        }
    }
}