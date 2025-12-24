
namespace Indotalent.Reminder {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.panel()
    export class PlanSettingDialog extends Serenity.EntityDialog<PlanSettingRow, any> {
        protected getFormKey() { return PlanSettingForm.formKey; }
        protected getIdProperty() { return PlanSettingRow.idProperty; }
        protected getLocalTextPrefix() { return PlanSettingRow.localTextPrefix; }
        protected getNameProperty() { return PlanSettingRow.nameProperty; }
        protected getService() { return PlanSettingService.baseUrl; }
        protected getDeletePermission() { return PlanSettingRow.deletePermission; }
        protected getInsertPermission() { return PlanSettingRow.insertPermission; }
        protected getUpdatePermission() { return PlanSettingRow.updatePermission; }

        protected form = new PlanSettingForm(this.idPrefix);


        protected afterLoadEntity() {
            super.afterLoadEntity();
            if (!Q.Authorization.hasPermission("Reminder:PlanSetting")) {
                this.setFieldsReadOnly();
                
            }
        }
        private setFieldsReadOnly() {
            Serenity.EditorUtils.setReadOnly(this.form.PlanName, true);
            Serenity.EditorUtils.setReadOnly(this.form.ProductId, true);
            Serenity.EditorUtils.setReadOnly(this.form.Type, true);
            Serenity.EditorUtils.setReadOnly(this.form.Frequency, true);
            Serenity.EditorUtils.setReadOnly(this.form.IsActive, true);
            Serenity.EditorUtils.setReadOnly(this.form.Cost, true);
            Serenity.EditorUtils.setReadOnly(this.form.Units, true);
           





        }

        protected updateInterface() {
            super.updateInterface();
            if (!Q.Authorization.hasPermission("Reminder:PlanSetting")) {
            
                if (!this.isNew()) {
                    this.toolbar.findButton('save-and-close-button').hide();
                    this.toolbar.findButton('delete-button').hide();
                    this.toolbar.findButton('apply-changes-button').hide();


                }
                
                if (Q.Authorization.hasPermission("Administration: Tenant")) {

                   
                        this.toolbar.findButton('save-and-close-button').hide();
                        this.toolbar.findButton('delete-button').hide();
                        this.toolbar.findButton('apply-changes-button').hide();


                    }

                }
            }
        }
    }
}