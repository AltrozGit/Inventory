
namespace Indotalent.Reminder {

    @Serenity.Decorators.registerClass()
    export class TenantUnitTransactionDialog extends Serenity.EntityDialog<TenantUnitTransactionRow, any> {
        protected getFormKey() { return TenantUnitTransactionForm.formKey; }
        protected getIdProperty() { return TenantUnitTransactionRow.idProperty; }
        protected getLocalTextPrefix() { return TenantUnitTransactionRow.localTextPrefix; }
        protected getNameProperty() { return TenantUnitTransactionRow.nameProperty; }
        protected getService() { return TenantUnitTransactionService.baseUrl; }
        protected getDeletePermission() { return TenantUnitTransactionRow.deletePermission; }
        protected getInsertPermission() { return TenantUnitTransactionRow.insertPermission; }
        protected getUpdatePermission() { return TenantUnitTransactionRow.updatePermission; }

        protected form = new TenantUnitTransactionForm(this.idPrefix);
        constructor() {
            super();
        }
        protected afterLoadEntity() {
            super.afterLoadEntity();



        
            this.setFieldsReadOnly();
        }

        private setFieldsReadOnly() {
            Serenity.EditorUtils.setReadOnly(this.form.ReferenceId, true);
            Serenity.EditorUtils.setReadOnly(this.form.Units, true);
            Serenity.EditorUtils.setReadOnly(this.form.Remark, true);
            Serenity.EditorUtils.setReadOnly(this.form.SubscriptionId, true);

        }

        protected updateInterface() {
            super.updateInterface();

            // Hide the Update button when editing an existing record
            if (!this.isNew()) {
                this.toolbar.findButton('save-and-close-button').hide();
                this.toolbar.findButton('apply-changes-button').hide();
            }
        }
    }
}