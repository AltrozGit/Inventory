namespace Indotalent.Sales {

    @Serenity.Decorators.registerClass()
    export class SalesOrderGrid extends Serenity.EntityGrid<SalesOrderRow, any> {
        protected getColumnsKey() { return SalesOrderColumns.columnsKey; }
        protected getDialogType() { return SalesOrderDialog; }
        protected getIdProperty() { return SalesOrderRow.idProperty; }
        protected getInsertPermission() { return SalesOrderRow.insertPermission; }
        protected getLocalTextPrefix() { return SalesOrderRow.localTextPrefix; }
        protected getService() { return SalesOrderService.baseUrl; }

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
                if (col.field === "FinalTotalPostTDS_TCS") {
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
                field: 'OrderDate',
                name: 'Month - Year',
                width: 100,
                format: (ctx) => {
                    const orderItem = ctx.item as SalesOrderRow;
                    const date = new Date(orderItem.OrderDate);
                    const options: Intl.DateTimeFormatOptions = { month: 'short', year: 'numeric' };
                    return date.toLocaleDateString('en-US', options).replace(',', ' -');
                }
            });

            if (!Q.Authorization.hasPermission("Administration:Tenant")) {
                columns = columns.filter(x => x.field != SalesOrderRow.Fields.TenantName && x.field != SalesOrderRow.Fields.Id);
            }

            return columns;
        }
       
        protected getAddButtonCaption() {
            return "New Customer Order";
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
                        reportKey: 'SalesOrderPrint',
                        params: {
                            Id: item.Id
                        }
                    });
                }
            }
        }
    }
}
