
namespace Indotalent.Projects {

    @Serenity.Decorators.registerClass()
    export class QuotationGrid extends Serenity.EntityGrid<QuotationRow, any> {
        protected getColumnsKey() { return QuotationColumns.columnsKey; }
        protected getDialogType() { return QuotationDialog; }
        protected getIdProperty() { return QuotationRow.idProperty; }
        protected getInsertPermission() { return QuotationRow.insertPermission; }
        protected getLocalTextPrefix() { return QuotationRow.localTextPrefix; }
        protected getService() { return QuotationService.baseUrl; }

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
                if (col.field === "Total") {
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
                field: 'PaymentDate',
                name: 'Month - Year',
                width: 100,
                format: (ctx) => {
                    const paymentItem = ctx.item as QuotationRow;
                    const date = new Date(paymentItem.QuotationDate);
                    const options: Intl.DateTimeFormatOptions = { month: 'short', year: 'numeric' };
                    return date.toLocaleDateString('en-US', options).replace(',', ' -');
                }
            });

            if (!Q.Authorization.hasPermission("Administration:Tenant")) {
                columns = columns.filter(x => x.field != QuotationRow.Fields.TenantName && x.field != QuotationRow.Fields.Id);
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
                        reportKey: 'QuotationPrint',
                        params: {
                            Id: item.Id
                        }
                    });
                }
            }
        }
    }
}
   