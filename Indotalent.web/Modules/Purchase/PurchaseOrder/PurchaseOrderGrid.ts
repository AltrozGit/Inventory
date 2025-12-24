namespace Indotalent.Purchase {

    @Serenity.Decorators.registerClass()
    export class PurchaseOrderGrid extends Serenity.EntityGrid<PurchaseOrderRow, any> {
        protected getColumnsKey() { return PurchaseOrderColumns.columnsKey; }
        protected getDialogType() { return PurchaseOrderDialog; }
        protected getIdProperty() { return PurchaseOrderRow.idProperty; }
        protected getInsertPermission() { return PurchaseOrderRow.insertPermission; }
        protected getLocalTextPrefix() { return PurchaseOrderRow.localTextPrefix; }
        protected getService() { return PurchaseOrderService.baseUrl; }

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

            columns.splice(3, 0, {
                field: 'OrderDate',
                name: 'Month - Year',
                width: 100,
                sortable: true,
                format: (ctx) => {
                    const orderItem = ctx.item as PurchaseOrderRow;
                    const date = new Date(orderItem.OrderDate);
                    const options: Intl.DateTimeFormatOptions = { month: 'short', year: 'numeric' };
                    return date.toLocaleDateString('en-US', options).replace(',', ' -');
                }
            });

            if (!Q.Authorization.hasPermission("Administration:Tenant")) {
                columns = columns.filter(x => x.field != PurchaseOrderRow.Fields.TenantName && x.field != PurchaseOrderRow.Fields.Id);
            }

            //columns.unshift({
            //    name: `<input type='checkbox' id='select-all' />`,
            //    field: "IsSelected",
            //    format: (ctx) => `<input type='checkbox' class='select-row' data-id='${ctx.item.ProductId}' />`,
            //    width: 50,
            //    sortable: false,
            //    cssClass: "align-center"
            //} as Slick.Column);

            //$(document).on('change', '#select-all',
            //    function () {
            //        const isChecked = $(this).is(':checked');
            //        $('.select-row').prop('checked', isChecked);
            //    });

            return columns;
        }

        protected onClick(e: JQueryEventObject, row: number, cell: number) {
            super.onClick(e, row, cell);

            if (e.isDefaultPrevented())
                return;

            var item = this.itemAt(row);
            var target = $(e.target);

            if (target.parent().hasClass('inline-action'))
                target = target.parent();

            if (target.hasClass('inline-action')) {
                e.preventDefault();
                //if (target.hasClass('SendEmail-action')) {
                //    alert("Email Send");
                //}

                if (target.hasClass('print-selected')) {
                    Serenity.Extensions.ReportHelper.execute({
                        reportKey: 'PurchaseOrderPrint',
                        params: {
                            Id: item.Id
                        }
                    });
                }
            }
        }
       
    }
}
