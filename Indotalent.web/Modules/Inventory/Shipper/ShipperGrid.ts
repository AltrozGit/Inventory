
namespace Indotalent.Inventory {

    @Serenity.Decorators.registerClass()
    export class ShipperGrid extends Serenity.EntityGrid<ShipperRow, any> {
        protected getColumnsKey() { return ShipperColumns.columnsKey; }
        protected getDialogType() { return ShipperDialog; }
        protected getIdProperty() { return ShipperRow.idProperty; }
        protected getInsertPermission() { return ShipperRow.insertPermission; }
        protected getLocalTextPrefix() { return ShipperRow.localTextPrefix; }
        protected getService() { return ShipperService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }

        protected getColumns() {
            let columns = super.getColumns();

            if (!Q.Authorization.hasPermission("Administration:Tenant")) {
                columns = columns.filter(x => x.field != ShipperRow.Fields.TenantName && x.field != ShipperRow.Fields.Id);
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