
namespace Indotalent.Merchandise {

    @Serenity.Decorators.registerClass()
    export class SACGrid extends Serenity.EntityGrid<SACRow, any> {
        protected getColumnsKey() { return SACColumns.columnsKey; }
        protected getDialogType() { return SACDialog; }
        protected getIdProperty() { return SACRow.idProperty; }
        protected getInsertPermission() { return SACRow.insertPermission; }
        protected getLocalTextPrefix() { return SACRow.localTextPrefix; }
        protected getService() { return SACService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
        protected updateInterface(): void {
            super.updateInterface();
           //var addButton = this.toolbar.findButton('add-button');
           // addButton.toggleClass('disabled', true);
             /* addButton.text('New Button Text'); // Change the text here*/
        }
    }
}