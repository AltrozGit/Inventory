
namespace Indotalent.Inventory {

    @Serenity.Decorators.registerClass()
    export class WarehouseDialog extends Serenity.EntityDialog<WarehouseRow, any> {
        protected getFormKey() { return WarehouseForm.formKey; }
        protected getIdProperty() { return WarehouseRow.idProperty; }
        protected getLocalTextPrefix() { return WarehouseRow.localTextPrefix; }
        protected getNameProperty() { return WarehouseRow.nameProperty; }
        protected getService() { return WarehouseService.baseUrl; }
        protected getDeletePermission() { return WarehouseRow.deletePermission; }
        protected getInsertPermission() { return WarehouseRow.insertPermission; }
        protected getUpdatePermission() { return WarehouseRow.updatePermission; }

        protected form = new WarehouseForm(this.idPrefix);
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