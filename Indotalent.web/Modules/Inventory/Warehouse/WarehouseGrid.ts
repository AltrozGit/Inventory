
namespace Indotalent.Inventory {

    @Serenity.Decorators.registerClass()
    export class WarehouseGrid extends Serenity.EntityGrid<WarehouseRow, any> {
        protected getColumnsKey() { return WarehouseColumns.columnsKey; }
        protected getDialogType() { return WarehouseDialog; }
        protected getIdProperty() { return WarehouseRow.idProperty; }
        protected getInsertPermission() { return WarehouseRow.insertPermission; }
        protected getLocalTextPrefix() { return WarehouseRow.localTextPrefix; }
        protected getService() { return WarehouseService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }

        protected getColumns() {
            let columns = super.getColumns();

            if (!Q.Authorization.hasPermission("Administration:Tenant")) {
                columns = columns.filter(x => x.field != WarehouseRow.Fields.TenantName && x.field != WarehouseRow.Fields.Id);
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