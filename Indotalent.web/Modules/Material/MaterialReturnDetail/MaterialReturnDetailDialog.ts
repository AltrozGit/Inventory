
namespace Indotalent.Material {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.panel()
    export class MaterialReturnDetailDialog extends Serenity.Extensions.GridEditorDialog<MaterialReturnDetailRow> {
        protected getFormKey() { return MaterialReturnDetailForm.formKey; }
        protected getLocalTextPrefix() { return MaterialReturnDetailRow.localTextPrefix; }
       

        protected form = new MaterialReturnDetailForm(this.idPrefix);

    }
}