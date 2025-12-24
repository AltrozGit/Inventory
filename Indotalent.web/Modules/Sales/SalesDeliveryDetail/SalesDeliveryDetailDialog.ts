
namespace Indotalent.Sales {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.panel()
    export class SalesDeliveryDetailDialog extends Serenity.Extensions.GridEditorDialog<SalesDeliveryDetailRow> {
        protected getFormKey() { return SalesDeliveryDetailForm.formKey; }
        protected getLocalTextPrefix() { return SalesDeliveryDetailRow.localTextPrefix; }

        protected form = new SalesDeliveryDetailForm(this.idPrefix);

    }
}