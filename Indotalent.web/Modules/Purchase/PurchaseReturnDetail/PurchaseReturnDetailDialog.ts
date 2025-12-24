
namespace Indotalent.Purchase {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.panel()
    export class PurchaseReturnDetailDialog extends Serenity.Extensions.GridEditorDialog<PurchaseReturnDetailRow> {
        protected getFormKey() { return PurchaseReturnDetailForm.formKey; }
        protected getLocalTextPrefix() { return PurchaseReturnDetailRow.localTextPrefix; }

        protected form = new PurchaseReturnDetailForm(this.idPrefix);



    }
}