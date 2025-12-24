
namespace Indotalent.Settings {

    @Serenity.Decorators.registerClass()
    export class SalesTaxDialog extends Serenity.EntityDialog<SalesTaxRow, any> {
        protected getFormKey() { return SalesTaxForm.formKey; }
        protected getIdProperty() { return SalesTaxRow.idProperty; }
        protected getLocalTextPrefix() { return SalesTaxRow.localTextPrefix; }
        protected getNameProperty() { return SalesTaxRow.nameProperty; }
        protected getService() { return SalesTaxService.baseUrl; }
        protected getDeletePermission() { return SalesTaxRow.deletePermission; }
        protected getInsertPermission() { return SalesTaxRow.insertPermission; }
        protected getUpdatePermission() { return SalesTaxRow.updatePermission; }

        protected form = new SalesTaxForm(this.idPrefix);
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
            //this.form.TaxType.element.attr('readonly', 'readonly');
        }

        private CalculateTax() {

            this.form.SGST.value = this.form.TaxRatePercentage.value / 2;
            this.form.CGST.value = this.form.TaxRatePercentage.value / 2;
            this.form.IGST.value = this.form.TaxRatePercentage.value;


        }


    }
}