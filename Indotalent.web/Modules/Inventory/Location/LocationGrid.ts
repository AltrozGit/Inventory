
namespace Indotalent.Inventory {

    @Serenity.Decorators.registerClass()
    export class LocationGrid extends Serenity.EntityGrid<LocationRow, any> {
        protected getColumnsKey() { return LocationColumns.columnsKey; }
        protected getDialogType() { return LocationDialog; }
        protected getIdProperty() { return LocationRow.idProperty; }
        protected getInsertPermission() { return LocationRow.insertPermission; }
        protected getLocalTextPrefix() { return LocationRow.localTextPrefix; }
        protected getService() { return LocationService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }

        protected getColumns() {
            let columns = super.getColumns();

            if (!Q.Authorization.hasPermission("Administration:Tenant")) {
                columns = columns.filter(x => x.field != LocationRow.Fields.TenantName && x.field != LocationRow.Fields.Id);
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