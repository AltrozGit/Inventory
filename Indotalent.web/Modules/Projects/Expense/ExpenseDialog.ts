
namespace Indotalent.Projects {

    @Serenity.Decorators.registerClass()
    export class ExpenseDialog extends Serenity.EntityDialog<ExpenseRow, any> {
        protected getFormKey() { return ExpenseForm.formKey; }
        protected getIdProperty() { return ExpenseRow.idProperty; }
        protected getLocalTextPrefix() { return ExpenseRow.localTextPrefix; }
        protected getNameProperty() { return ExpenseRow.nameProperty; }
        protected getService() { return ExpenseService.baseUrl; }
        protected getDeletePermission() { return ExpenseRow.deletePermission; }
        protected getInsertPermission() { return ExpenseRow.insertPermission; }
        protected getUpdatePermission() { return ExpenseRow.updatePermission; }

        protected form = new ExpenseForm(this.idPrefix);

    }
}