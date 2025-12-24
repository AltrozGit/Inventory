
namespace Indotalent.Sales {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.panel()
    export class SalesReturnDetailDialog extends Serenity.Extensions.GridEditorDialog<SalesReturnDetailRow> {
        protected getFormKey() { return SalesReturnDetailForm.formKey; }
        protected getLocalTextPrefix() { return SalesReturnDetailRow.localTextPrefix; }

        protected form = new SalesReturnDetailForm(this.idPrefix);



    }
}