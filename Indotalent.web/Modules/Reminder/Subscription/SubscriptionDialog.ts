
namespace Indotalent.Reminder {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.panel()
    export class SubscriptionDialog extends Serenity.EntityDialog<SubscriptionRow, any> {
        protected getFormKey() { return SubscriptionForm.formKey; }
        protected getIdProperty() { return SubscriptionRow.idProperty; }
        protected getLocalTextPrefix() { return SubscriptionRow.localTextPrefix; }
        protected getService() { return SubscriptionService.baseUrl; }
        protected getDeletePermission() { return SubscriptionRow.deletePermission; }
        protected getInsertPermission() { return SubscriptionRow.insertPermission; }
        protected getUpdatePermission() { return SubscriptionRow.updatePermission; }

        protected form = new SubscriptionForm(this.idPrefix);
        constructor() {
            super();
        }
        protected afterLoadEntity() {
            super.afterLoadEntity();




           // this.setFieldsReadOnly();
        }

        private setFieldsReadOnly() {
            Serenity.EditorUtils.setReadOnly(this.form.EndDate, true);
            Serenity.EditorUtils.setReadOnly(this.form.ActiveEndDate, true);
            Serenity.EditorUtils.setReadOnly(this.form.TotalUnits, true);
            Serenity.EditorUtils.setReadOnly(this.form.StartDate, true);
            Serenity.EditorUtils.setReadOnly(this.form.PlanName, true);
       

            Serenity.EditorUtils.setReadOnly(this.form.CurrentBalanceUnits, true);

        }
    }
}