
namespace Indotalent.Material {

    @Serenity.Decorators.registerClass()
    export class MaterialRequestTrackingDialog extends Serenity.Extensions.GridEditorDialog<MaterialRequestTrackingRow> {
        protected getFormKey() { return MaterialRequestTrackingForm.formKey; }
        //protected getIdProperty() { return MaterialRequestTrackingRow.idProperty; }
        protected getLocalTextPrefix() { return MaterialRequestTrackingRow.localTextPrefix; }
        ////protected getNameProperty() { return MaterialRequestTrackingRow.nameProperty; }
        //protected getService() { return MaterialRequestTrackingService.baseUrl; }
        //protected getDeletePermission() { return MaterialRequestTrackingRow.deletePermission; }
        //protected getInsertPermission() { return MaterialRequestTrackingRow.insertPermission; }
        //protected getUpdatePermission() { return MaterialRequestTrackingRow.updatePermission; }

        protected form = new MaterialRequestTrackingForm(this.idPrefix);
       // private loadedState: string;

        //    constructor() {
        //        super();

        //        Indotalent.DialogUtils.pendingChangesConfirmation(this.element, () => this.getSaveState() != this.loadedState);
        //    }


        //    getSaveState() {
        //        try {
        //            return $.toJSON(this.getSaveEntity());
        //        }
        //        catch (e) {
        //            return null;
        //        }
        //    }

        //    loadResponse(data) {
        //        super.loadResponse(data);
        //        this.loadedState = this.getSaveState();
        //    }

        //}
    }
}