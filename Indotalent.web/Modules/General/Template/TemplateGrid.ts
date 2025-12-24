
namespace Indotalent.General {

    @Serenity.Decorators.registerClass()
    export class TemplateGrid extends Serenity.EntityGrid<TemplateRow, any> {
        protected getColumnsKey() { return TemplateColumns.columnsKey; }
        protected getDialogType() { return TemplateDialog; }
        protected getIdProperty() { return TemplateRow.idProperty; }
        protected getInsertPermission() { return TemplateRow.insertPermission; }
        protected getLocalTextPrefix() { return TemplateRow.localTextPrefix; }
        protected getService() { return TemplateService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}