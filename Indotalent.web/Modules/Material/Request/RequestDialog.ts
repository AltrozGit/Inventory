
namespace Indotalent.Material {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.panel()
    export class RequestDialog extends Serenity.EntityDialog<RequestRow, any> {
        protected getFormKey() { return RequestForm.formKey; }
        protected getIdProperty() { return RequestRow.idProperty; }
        protected getLocalTextPrefix() { return RequestRow.localTextPrefix; }
        protected getNameProperty() { return RequestRow.nameProperty; }
        protected getService() { return MaterialRequestService.baseUrl; }
        protected getDeletePermission() { return RequestRow.deletePermission; }
        protected getInsertPermission() { return RequestRow.insertPermission; }
        protected getUpdatePermission() { return RequestRow.updatePermission; }

        protected form = new RequestForm(this.idPrefix);
       
        private loadedState: string;
      //  public entityId: RequestDetailRow;

        constructor(/*entityId: RequestDetailRow*/) {
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
            Serenity.EditorUtils.setReadOnly(this.form.Total, true);
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
                reportKey: 'RequestPrint',
                getParams: () => ({
                    Id: this.get_entityId()
                })
            }));

            return buttons;
        }
        //protected getSelect2Options() {

        //  /*  var opt = super.getSelect2Options();*/
        //    opt.sortResults = (results, container, options) => { if (results) return results.sort(); };
        //    return opt;
        //}

    }

}