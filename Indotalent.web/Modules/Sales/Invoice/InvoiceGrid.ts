
namespace Indotalent.Sales {

    @Serenity.Decorators.registerClass()
    export class InvoiceGrid extends Serenity.EntityGrid<InvoiceRow, any> {
        protected getColumnsKey() { return InvoiceColumns.columnsKey; }
        protected getDialogType() { return InvoiceDialog; }
        protected getIdProperty() { return InvoiceRow.idProperty; }
        protected getInsertPermission() { return InvoiceRow.insertPermission; }
        protected getLocalTextPrefix() { return InvoiceRow.localTextPrefix; }
        protected getService() { return InvoiceService.baseUrl; }

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
                field: 'InvoiceDate',
                name: 'Month - Year',
                width: 100,
                format: (ctx) => {
                    const invoiceItem = ctx.item as InvoiceRow;
                    const date = new Date(invoiceItem.InvoiceDate);
                    const options: Intl.DateTimeFormatOptions = { month: 'short', year: 'numeric' };
                    return date.toLocaleDateString('en-US', options).replace(',', ' -');
                }
            });
            if (!Q.Authorization.hasPermission("Administration:Tenant")) {
                columns = columns.filter(x => x.field != InvoiceRow.Fields.TenantName && x.field != InvoiceRow.Fields.Id);
            }

            //columns.push({
            //    id: '',
            //    field: null,
            //    name: 'Take Action',
            //    format: ctx => {
            //        var item = ctx.item;

            //        return '<a class="inline-action SendEmail-action" font-weight: bold;" title="Send Email">' +
            //            '<i class="fa fa-envelope"></i>&nbsp;Send Email</a>';

            //    },
            //    width: 200,
            //    minWidth: 200,
            //    maxWidth: 200
            //});
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
                    //if (target.hasClass('SendEmail-action')) {
                    //    alert("Email Send");
                    //}
                e.preventDefault();

                if (target.hasClass('print-selected')) {
                    Serenity.Extensions.ReportHelper.execute({
                        reportKey: 'InvoicePrint',
                        params: {
                            Id: item.Id
                        }
                    });
                }
            }
        }
    }
}