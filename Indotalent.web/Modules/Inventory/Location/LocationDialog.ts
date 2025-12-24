
namespace Indotalent.Inventory {

    @Serenity.Decorators.registerClass()
    export class LocationDialog extends Serenity.EntityDialog<LocationRow, any> {
        protected getFormKey() { return LocationForm.formKey; }
        protected getIdProperty() { return LocationRow.idProperty; }
        protected getLocalTextPrefix() { return LocationRow.localTextPrefix; }
        protected getNameProperty() { return LocationRow.nameProperty; }
        protected getService() { return LocationService.baseUrl; }
        protected getDeletePermission() { return LocationRow.deletePermission; }
        protected getInsertPermission() { return LocationRow.insertPermission; }
        protected getUpdatePermission() { return LocationRow.updatePermission; }

        protected form = new LocationForm(this.idPrefix);
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