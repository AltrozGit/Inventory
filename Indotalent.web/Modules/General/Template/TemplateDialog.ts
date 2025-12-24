
namespace Indotalent.General {

    @Serenity.Decorators.registerClass()
    export class TemplateDialog extends Serenity.EntityDialog<TemplateRow, any> {
        protected getFormKey() { return TemplateForm.formKey; }
        protected getIdProperty() { return TemplateRow.idProperty; }
        protected getLocalTextPrefix() { return TemplateRow.localTextPrefix; }
        protected getNameProperty() { return TemplateRow.nameProperty; }
        protected getService() { return TemplateService.baseUrl; }
        protected getDeletePermission() { return TemplateRow.deletePermission; }
        protected getInsertPermission() { return TemplateRow.insertPermission; }
        protected getUpdatePermission() { return TemplateRow.updatePermission; }

        protected form = new TemplateForm(this.idPrefix);

    }
}