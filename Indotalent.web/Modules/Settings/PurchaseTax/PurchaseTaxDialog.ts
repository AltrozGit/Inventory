
namespace Indotalent.Settings {

    @Serenity.Decorators.registerClass()
    export class PurchaseTaxDialog extends Serenity.EntityDialog<PurchaseTaxRow, any> {
        protected getFormKey() { return PurchaseTaxForm.formKey; }
        protected getIdProperty() { return PurchaseTaxRow.idProperty; }
        protected getLocalTextPrefix() { return PurchaseTaxRow.localTextPrefix; }
        protected getNameProperty() { return PurchaseTaxRow.nameProperty; }
        protected getService() { return PurchaseTaxService.baseUrl; }
        protected getDeletePermission() { return PurchaseTaxRow.deletePermission; }
        protected getInsertPermission() { return PurchaseTaxRow.insertPermission; }
        protected getUpdatePermission() { return PurchaseTaxRow.updatePermission; }

        protected form = new PurchaseTaxForm(this.idPrefix);
        private loadedState: string;

        constructor() {
            super();

            Indotalent.DialogUtils.pendingChangesConfirmation(this.element, () => this.getSaveState() != this.loadedState);

           
            this.form.TaxType.changeSelect2((args) => {

                this.TaxTypeHideShow();

               
            });
            this.form.TaxRatePercentage.changeSelect2((args) => {

                this.CalculateTax();


            });

            

        }



        private TaxTypeHideShow() {

            if (this.form.TaxType.value === '1') {

                this.form.TaxRatePercentage.getGridField().toggle(true);
                this.form.CGST.getGridField().toggle(true);
                this.form.SGST.getGridField().toggle(true);
                this.form.IGST.getGridField().toggle(true);


            } else if (this.form.TaxType.value === '2' || this.form.TaxType.value === '3') {

                
                this.form.CGST.getGridField().toggle(false);
                this.form.SGST.getGridField().toggle(false);
                this.form.IGST.getGridField().toggle(false);

                this.form.TaxRatePercentage.getGridField().toggle(true);
                // this.form.TaxRatePercentage.element.show();

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
            
            this.TaxTypeHideShow();
        }

        private CalculateTax() {

            this.form.SGST.value = this.form.TaxRatePercentage.value / 2;
            this.form.CGST.value = this.form.TaxRatePercentage.value / 2;
            this.form.IGST.value = this.form.TaxRatePercentage.value;


        }


        protected afterLoadEntity() {
            super.afterLoadEntity();

            if (this.isNew()) {
               


                
            }

        }

    }
}