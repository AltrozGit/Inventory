
namespace Indotalent.Material {

    @Serenity.Decorators.registerClass()
    export class StatusMasterDialog extends Serenity.EntityDialog<StatusMasterRow, any> {
        protected getFormKey() { return StatusMasterForm.formKey; }
        protected getIdProperty() { return StatusMasterRow.idProperty; }
        protected getLocalTextPrefix() { return StatusMasterRow.localTextPrefix; }
        protected getNameProperty() { return StatusMasterRow.nameProperty; }
        protected getService() { return StatusMasterService.baseUrl; }
        protected getDeletePermission() { return StatusMasterRow.deletePermission; }
        protected getInsertPermission() { return StatusMasterRow.insertPermission; }
        protected getUpdatePermission() { return StatusMasterRow.updatePermission; }

        protected form = new StatusMasterForm(this.idPrefix);

    }
}