
namespace Indotalent.Reminder {

    @Serenity.Decorators.registerClass()
   
    export class PlanDialog extends Serenity.EntityDialog<PlanRow, any> {
        protected getFormKey() { return PlanForm.formKey; }
        protected getIdProperty() { return PlanRow.idProperty; }
        protected getLocalTextPrefix() { return PlanRow.localTextPrefix; }
        protected getNameProperty() { return PlanRow.nameProperty; }
        protected getService() { return PlanService.baseUrl; }
        protected getDeletePermission() { return PlanRow.deletePermission; }
        protected getInsertPermission() { return PlanRow.insertPermission; }
        protected getUpdatePermission() { return PlanRow.updatePermission; }

        protected form = new PlanForm(this.idPrefix);

    }
}