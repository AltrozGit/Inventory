
namespace Indotalent.Projects {

    @Serenity.Decorators.registerClass()
    export class ProjectFundGrid extends Serenity.EntityGrid<ProjectFundRow, any> {
        protected getColumnsKey() { return ProjectFundColumns.columnsKey; }
        protected getDialogType() { return ProjectFundDialog; }
        protected getIdProperty() { return ProjectFundRow.idProperty; }
        protected getInsertPermission() { return ProjectFundRow.insertPermission; }
        protected getLocalTextPrefix() { return ProjectFundRow.localTextPrefix; }
        protected getService() { return ProjectFundService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}