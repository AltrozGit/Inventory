
namespace Indotalent.WhatsApp {

    @Serenity.Decorators.registerClass()
    export class WhatsAppTemplateGrid extends Serenity.EntityGrid<WhatsAppTemplateRow, any> {
        protected getColumnsKey() { return WhatsAppTemplateColumns.columnsKey; }
        protected getDialogType() { return WhatsAppTemplateDialog; }
        protected getIdProperty() { return WhatsAppTemplateRow.idProperty; }
        protected getInsertPermission() { return WhatsAppTemplateRow.insertPermission; }
        protected getLocalTextPrefix() { return WhatsAppTemplateRow.localTextPrefix; }
        protected getService() { return WhatsAppTemplateService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}