
namespace Indotalent.Inventory {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.panel()
    export class PositiveAdjustmentDetailDialog extends Serenity.Extensions.GridEditorDialog<PositiveAdjustmentDetailRow> {
        protected getFormKey() { return PositiveAdjustmentDetailForm.formKey; }
        protected getLocalTextPrefix() { return PositiveAdjustmentDetailRow.localTextPrefix; }

        protected form = new PositiveAdjustmentDetailForm(this.idPrefix);

    }
}