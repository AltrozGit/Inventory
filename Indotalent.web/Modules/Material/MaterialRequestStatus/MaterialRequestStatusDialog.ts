
namespace Indotalent.Material {

    @Serenity.Decorators.registerClass()
    export class MaterialRequestStatusDialog extends Serenity.Extensions.GridEditorDialog<MaterialRequestStatusRow> {
        protected getFormKey() { return MaterialRequestStatusForm.formKey; }
        //protected getIdProperty() { return MaterialRequestStatusRow.idProperty; }
        protected getLocalTextPrefix() { return MaterialRequestStatusRow.localTextPrefix; }
        //protected getNameProperty() { return MaterialRequestStatusRow.nameProperty; }
        //protected getService() { return MaterialRequestStatusService.baseUrl; }
        //protected getDeletePermission() { return MaterialRequestStatusRow.deletePermission; }
        //protected getInsertPermission() { return MaterialRequestStatusRow.insertPermission; }
        //protected getUpdatePermission() { return MaterialRequestStatusRow.updatePermission; }

        protected form = new MaterialRequestStatusForm(this.idPrefix);

    }
}