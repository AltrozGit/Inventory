
namespace Indotalent.Material {

    @Serenity.Decorators.registerClass()
    export class MaterialReturnDetailGrid extends Serenity.EntityGrid<MaterialReturnDetailRow, any> {
        protected getColumnsKey() { return MaterialReturnDetailColumns.columnsKey; }
        protected getDialogType() { return MaterialReturnDetailDialog; }
        protected getIdProperty() { return MaterialReturnDetailRow.idProperty; }
        protected getInsertPermission() { return MaterialReturnDetailRow.insertPermission; }
        protected getLocalTextPrefix() { return MaterialReturnDetailRow.localTextPrefix; }
        protected getService() { return MaterialReturnDetailService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}