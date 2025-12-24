
namespace Indotalent.Projects {

    @Serenity.Decorators.registerClass()
    export class VwProjectFundDialog extends Serenity.EntityDialog<VwProjectFundRow, any> {
        protected getFormKey() { return VwProjectFundForm.formKey; }
        protected getIdProperty() { return VwProjectFundRow.idProperty; }
        protected getLocalTextPrefix() { return VwProjectFundRow.localTextPrefix; }
        protected getNameProperty() { return VwProjectFundRow.nameProperty; }
        protected getService() { return VwProjectFundService.baseUrl; }
        protected getDeletePermission() { return VwProjectFundRow.deletePermission; }
        protected getInsertPermission() { return VwProjectFundRow.insertPermission; }
        protected getUpdatePermission() { return VwProjectFundRow.updatePermission; }

        protected form = new VwProjectFundForm(this.idPrefix);

    }
}