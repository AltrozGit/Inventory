
namespace Indotalent.Reminder {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.panel()
    export class BulkEmailSenderStatusGrid extends Serenity.EntityGrid<BulkEmailSenderStatusRow, any> {
        protected getColumnsKey() { return BulkEmailSenderStatusColumns.columnsKey; }
        // protected getDialogType() { return BulkEmailSenderStatusDialog; }
        protected getIdProperty() { return BulkEmailSenderStatusRow.idProperty; }
        protected getInsertPermission() { return BulkEmailSenderStatusRow.insertPermission; }
        protected getLocalTextPrefix() { return BulkEmailSenderStatusRow.localTextPrefix; }
        protected getService() { return BulkEmailSenderStatusService.baseUrl; }
        private tenantId: number;

        constructor(container: JQuery) {
            super(container);
           
           
        }
        protected getColumns() {
            let columns = super.getColumns();

            if (!Q.Authorization.hasPermission("Administration:Tenant")) {
                columns = columns.filter(x => x.field != BulkEmailSenderStatusRow.Fields.TenantName && x.field != BulkEmailSenderStatusRow.Fields.Id);
            }

            return columns;
        }
        protected updateInterface(): void {
            super.updateInterface();
            var addButton = this.toolbar.findButton('add-button');
            addButton.hide();

        }
       
    
        protected getButtons() {
            var buttons = super.getButtons();
            buttons = buttons.filter(x => x.cssClass !== "column-picker-button");
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
    
    