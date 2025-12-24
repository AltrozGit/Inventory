
namespace Indotalent.Inventory {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.panel()
    export class NegativeAdjustmentDetailDialog extends Serenity.Extensions.GridEditorDialog<NegativeAdjustmentDetailRow> {
        protected getFormKey() { return NegativeAdjustmentDetailForm.formKey; }
        protected getLocalTextPrefix() { return NegativeAdjustmentDetailRow.localTextPrefix; }

        protected form = new NegativeAdjustmentDetailForm(this.idPrefix);

    }
}