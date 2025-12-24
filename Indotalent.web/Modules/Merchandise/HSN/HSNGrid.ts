
namespace Indotalent.Merchandise {

    @Serenity.Decorators.registerClass()
    export class HSNGrid extends Serenity.EntityGrid<HSNRow, any> {
        protected getColumnsKey() { return HSNColumns.columnsKey; }
        protected getDialogType() { return HSNDialog; }
        protected getIdProperty() { return HSNRow.idProperty; }
        protected getInsertPermission() { return HSNRow.insertPermission; }
        protected getLocalTextPrefix() { return HSNRow.localTextPrefix; }
        protected getService() { return HSNService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }

        protected updateInterface(): void {
            super.updateInterface();
            //var addButton = this.toolbar.findButton('add-button');
            //addButton.toggleClass('disabled', false);
          /*  addButton.text('New Button Text'); // Change the text here*/
        }

    }
}