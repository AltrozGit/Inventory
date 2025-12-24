
namespace Indotalent.Projects {

    @Serenity.Decorators.registerClass()
    export class VwProjectFundGrid extends Serenity.EntityGrid<VwProjectFundRow, any> {
        protected getColumnsKey() { return VwProjectFundColumns.columnsKey; }
        protected getDialogType() { return VwProjectFundDialog; }
        protected getIdProperty() { return VwProjectFundRow.idProperty; }
        protected getInsertPermission() { return VwProjectFundRow.insertPermission; }
        protected getLocalTextPrefix() { return VwProjectFundRow.localTextPrefix; }
        protected getService() { return VwProjectFundService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}