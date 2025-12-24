
namespace Indotalent.Material {

    @Serenity.Decorators.registerClass()
    export class StatusMasterGrid extends Serenity.EntityGrid<StatusMasterRow, any> {
        protected getColumnsKey() { return StatusMasterColumns.columnsKey; }
        protected getDialogType() { return StatusMasterDialog; }
        protected getIdProperty() { return StatusMasterRow.idProperty; }
        protected getInsertPermission() { return StatusMasterRow.insertPermission; }
        protected getLocalTextPrefix() { return StatusMasterRow.localTextPrefix; }
        protected getService() { return StatusMasterService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
        protected getColumns(){
            let columns = super.getColumns();

            if (!Q.Authorization.hasPermission("Administration:Tenant")) {
                columns = columns.filter(x => x.field != StatusMasterRow.Fields.TenantName && x.field != StatusMasterRow.Fields.Id);
            }
         

            return columns;
        }

      
        protected getButtons() {
            var buttons = super.getButtons();

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