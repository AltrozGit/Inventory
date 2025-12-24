
namespace Indotalent.Material {

    @Serenity.Decorators.registerClass()
    export class MaterialRequestTrackingGrid extends Serenity.EntityGrid<MaterialRequestTrackingRow, any> {
        protected getColumnsKey() { return MaterialRequestTrackingColumns.columnsKey; }
        protected getDialogType() { return MaterialRequestTrackingDialog; }
        protected getIdProperty() { return MaterialRequestTrackingRow.idProperty; }
        protected getInsertPermission() { return MaterialRequestTrackingRow.insertPermission; }
        protected getLocalTextPrefix() { return MaterialRequestTrackingRow.localTextPrefix; }
        protected getService() { return MaterialRequestTrackingService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
        //protected getColumns() {
        //    let columns = super.getColumns();

        //    if (!Q.Authorization.hasPermission("Administration:Tenant")) {
        //        columns = columns.filter(x => x.field != MaterialRequestTrackingRow.Fields.TenantName && x.field != MaterialRequestTrackingRow.Fields.Id);
        //    }

        //    return columns;
        //}

    }
}