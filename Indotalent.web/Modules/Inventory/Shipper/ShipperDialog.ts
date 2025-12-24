
namespace Indotalent.Inventory {

    @Serenity.Decorators.registerClass()
    export class ShipperDialog extends Serenity.EntityDialog<ShipperRow, any> {
        protected getFormKey() { return ShipperForm.formKey; }
        protected getIdProperty() { return ShipperRow.idProperty; }
        protected getLocalTextPrefix() { return ShipperRow.localTextPrefix; }
        protected getNameProperty() { return ShipperRow.nameProperty; }
        protected getService() { return ShipperService.baseUrl; }
        protected getDeletePermission() { return ShipperRow.deletePermission; }
        protected getInsertPermission() { return ShipperRow.insertPermission; }
        protected getUpdatePermission() { return ShipperRow.updatePermission; }

        protected form = new ShipperForm(this.idPrefix);
        private loadedState: string;

        constructor() {
            super();

            Indotalent.DialogUtils.pendingChangesConfirmation(this.element, () => this.getSaveState() != this.loadedState);
        }


        getSaveState() {
            try {
                return $.toJSON(this.getSaveEntity());
            }
            catch (e) {
                return null;
            }
        }

        loadResponse(data) {
            super.loadResponse(data);
            this.loadedState = this.getSaveState();
        }

    }
}