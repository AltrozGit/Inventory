
namespace Indotalent.Projects {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.panel()
    export class ProjectMaterialRequestDialog extends Serenity.EntityDialog<ProjectMaterialRequestRow, any> {
        protected getFormKey() { return ProjectMaterialRequestForm.formKey; }
        protected getIdProperty() { return ProjectMaterialRequestRow.idProperty; }
        protected getLocalTextPrefix() { return ProjectMaterialRequestRow.localTextPrefix; }
        protected getNameProperty() { return ProjectMaterialRequestRow.nameProperty; }
        protected getService() { return ProjectMaterialRequestService.baseUrl; }
        protected getDeletePermission() { return ProjectMaterialRequestRow.deletePermission; }
        protected getInsertPermission() { return ProjectMaterialRequestRow.insertPermission; }
        protected getUpdatePermission() { return ProjectMaterialRequestRow.updatePermission; }

        protected form = new ProjectMaterialRequestForm(this.idPrefix);
        private loadedState: string;

        constructor() {
            super();
            this.form.ItemList.element.css('height', '300px');
           
           (this.form.ItemList.view as any).onRowCountChanged.subscribe(() => {
                this.recalculate();
            });

            (this.form.ItemList.view as any).onDataChanged.subscribe(() => {
                this.recalculate();
            });

            Indotalent.DialogUtils.pendingChangesConfirmation(this.element, () => this.getSaveState() != this.loadedState);



        }
        private recalculate() {
            this.form.TotalQtyRequest.value = 0;
            this.form.Total.value = 0;

            for (var item of this.form.ItemList.getItems()) {
                this.form.TotalQtyRequest.value += item.QtyRequest;
                this.form.Total.value += item.SubTotal;
                item.UomName = item.UomName;

            }
        }
        getSaveState() {
            try {
                return $.toJSON(this.getSaveEntity());
            }
            catch (e) {
                return null;
            }
        }

        loadResponse(data) {
            super.loadResponse(data);
            this.loadedState = this.getSaveState();
        }
        protected updateInterface(): void {
            super.updateInterface();

            this.toolbar.findButton('print-request').toggle(this.isEditMode());


        }

        protected afterLoadEntity() {
            super.afterLoadEntity();
            Serenity.EditorUtils.setReadOnly(this.form.Number, true);
            this.recalculate();

            if (this.isNew()) {

                Serenity.EditorUtils.setReadOnly(this.form.Number, false);
                const consentDueDateValue = this.form.RequestDate.value;

                if (consentDueDateValue) {
                    const consentDueDate1 = new Date(consentDueDateValue);
                    consentDueDate1.setMonth(consentDueDate1.getMonth() + 1); // Corrected: Use setMonth to add one month
                    this.form.DeliveryDate.value = consentDueDate1.toISOString().split('T')[0]; // Format to YYYY-MM-DD
                }
            }
        }


        protected getToolbarButtons() {
            var buttons = super.getToolbarButtons();

            buttons.push(Serenity.Extensions.ReportHelper.createToolButton({
                title: 'Print Request',
                cssClass: 'export-pdf-button print-request',
                reportKey: 'ProjectMaterialRequestPrint',
                getParams: () => ({
                    Id: this.get_entityId()
                })
            }));

            buttons.push({
                title: 'Create Material Request',
                cssClass: 'create-material-request',
                onClick: () => this.openProjectMaterialRequestDetailGrid()
            });

            return buttons;

            
        }

        private openProjectMaterialRequestDetailGrid() {
           
            const projectMaterialRequestId = this.entityId;
            this.dialogClose();

            // Create the grid and pass the ProjectMaterialRequestId as a parameter
            let grid = new Indotalent.Projects.ProjectMaterialRequestDetailGrid($('#TemporaryGridContainer'), {
                projectMaterialRequestId: projectMaterialRequestId 
            });

            // Open the grid in a dialog
            grid.element.dialog({
                width: 800,
                height: 600,
                modal: true,
                close: function () {
                    grid.destroy();
                }
            });
        }
    }

}
    
