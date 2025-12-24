
namespace Indotalent.Purchase {

    @Serenity.Decorators.registerClass()
    export class PaymentTermDialog extends Serenity.EntityDialog<PaymentTermRow, any> {
        protected getFormKey() { return PaymentTermForm.formKey; }
        protected getIdProperty() { return PaymentTermRow.idProperty; }
        protected getLocalTextPrefix() { return PaymentTermRow.localTextPrefix; }
        protected getNameProperty() { return PaymentTermRow.nameProperty; }
        protected getService() { return PaymentTermService.baseUrl; }
        protected getDeletePermission() { return PaymentTermRow.deletePermission; }
        protected getInsertPermission() { return PaymentTermRow.insertPermission; }
        protected getUpdatePermission() { return PaymentTermRow.updatePermission; }

        protected form = new PaymentTermForm(this.idPrefix);

    }
}