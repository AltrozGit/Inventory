
namespace Indotalent.Material {

    @Serenity.Decorators.registerClass()
    export class IssueDetailGrid extends Serenity.EntityGrid<IssueDetailRow, any> {
        protected getColumnsKey() { return IssueDetailColumns.columnsKey; }
        protected getDialogType() { return IssueDetailDialog; }
        protected getIdProperty() { return IssueDetailRow.idProperty; }
        protected getInsertPermission() { return IssueDetailRow.insertPermission; }
        protected getLocalTextPrefix() { return IssueDetailRow.localTextPrefix; }
        protected getService() { return IssueDetailService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}