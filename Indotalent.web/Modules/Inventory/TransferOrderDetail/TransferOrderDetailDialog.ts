
namespace Indotalent.Inventory {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.panel()
    export class TransferOrderDetailDialog extends Serenity.Extensions.GridEditorDialog<TransferOrderDetailRow> {
        protected getFormKey() { return TransferOrderDetailForm.formKey; }
        protected getLocalTextPrefix() { return TransferOrderDetailRow.localTextPrefix; }

        protected form = new TransferOrderDetailForm(this.idPrefix);

    }
}