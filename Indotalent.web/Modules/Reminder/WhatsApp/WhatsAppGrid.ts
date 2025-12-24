
namespace Indotalent.Reminder {

    @Serenity.Decorators.registerClass()
    export class WhatsAppGrid extends Serenity.EntityGrid<WhatsAppRow, any> {
        protected getColumnsKey() { return WhatsAppColumns.columnsKey; }
        protected getDialogType() { return WhatsAppDialog; }
        protected getIdProperty() { return WhatsAppRow.idProperty; }
        protected getInsertPermission() { return WhatsAppRow.insertPermission; }
        protected getLocalTextPrefix() { return WhatsAppRow.localTextPrefix; }
        protected getService() { return WhatsAppService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}