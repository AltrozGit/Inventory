
namespace Indotalent.Reminder {

    @Serenity.Decorators.registerClass()
    export class SmtpConfigurationGrid extends Serenity.EntityGrid<SmtpConfigurationRow, any> {
        protected getColumnsKey() { return SmtpConfigurationColumns.columnsKey; }
        protected getDialogType() { return SmtpConfigurationDialog; }
        protected getIdProperty() { return SmtpConfigurationRow.idProperty; }
        protected getInsertPermission() { return SmtpConfigurationRow.insertPermission; }
        protected getLocalTextPrefix() { return SmtpConfigurationRow.localTextPrefix; }
        protected getService() { return SmtpConfigurationService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
        protected getColumns() {
            let columns = super.getColumns();

            if (!Q.Authorization.hasPermission("Administration:Tenant")) {
                columns = columns.filter(x => x.field != BulkEmailFileUploadRow.Fields.TenantName && x.field != BulkEmailFileUploadRow.Fields.Id);
            }

            columns.push({
                field: 'IsDefault',
                name: Q.text('Is Default'),
                format: ctx => Q.htmlEncode(ctx.value ? "✔" : ""),
                sortable: true,
                width: 100,
                cssClass: "text-center"
            });

            return columns;
        }

    }
}