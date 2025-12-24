
namespace Indotalent.Projects {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.panel()
    export class QuotationDetailDialog extends Serenity.Extensions.GridEditorDialog<QuotationDetailRow> {
        protected getFormKey() { return QuotationDetailForm.formKey; }
     //  protected getIdProperty() { return QuotationDetailRow.idProperty; }
        protected getLocalTextPrefix() { return QuotationDetailRow.localTextPrefix; }
        //protected getService() { return QuotationDetailService.baseUrl; }
        //protected getDeletePermission() { return QuotationDetailRow.deletePermission; }
        //protected getInsertPermission() { return QuotationDetailRow.insertPermission; }
        //protected getUpdatePermission() { return QuotationDetailRow.updatePermission; }
        private CustomerId: string;
        private CustomerState: string;

        public set CustomerIdFromEditor(value: string) {
            this.CustomerId = value;

        }

        protected form = new QuotationDetailForm(this.idPrefix); constructor() {
            super();


            this.form.Price.change(() => {
                this.recalculate();
            });

            this.form.Qty.change(() => {
                this.recalculate();
            });

            this.form.Discount.change(() => {
                this.recalculate();
            });

            this.form.TaxPercentage.change(() => {
                this.recalculate();
            });

            //this.form.ProductId.changeSelect2(args => {
            //    var productId = this.form.ProductId.value;
            //    if (Q.isEmptyOrNull(productId)) {
            //        return;
            //    }
            //    Merchandise.ProductService.Retrieve({
            //        EntityId: productId
            //    }, response => {
            //        this.form.Price.value = response.Entity.PurchasePrice;
            //        Settings.PurchaseTaxService.Retrieve({
            //            EntityId: response.Entity.PurchaseTaxId
            //        }, response => {
            //            this.form.TaxPercentage.value = response.Entity.TaxRatePercentage;
            //            this.form.IGST.value = response.Entity.IGST;
            //            this.form.SGST.value = response.Entity.SGST;
            //            this.form.CGST.value = response.Entity.CGST;
            //            this.setGstValuesBasedOnCustomerAndTenantState();
            //            this.recalculate();
            //        });
            //    });
            //});

            this.form.ProductId.changeSelect2(args => {
                
                var productId = this.form.ProductId.value;
                if (Q.isEmptyOrNull(productId)) {
                    return;
                }
                //if (Q.isEmptyOrNull(this.CustomerId)) {
                //    Q.alert("Please select a customer before proceeding.");
                //    return;
                //}
                Merchandise.ProductService.Retrieve({
                    EntityId: productId
                }, response => {

                    //if (Q.isEmptyOrNull(this.CustomerId)) {
                    //    Q.alert("Please select a customer before proceeding.");
                    //    return;
                    //}
                    this.form.Price.value = response.Entity.SalesPrice;
                    this.form.InternalCode.value = response.Entity.InternalCode;

                    Settings.SalesTaxService.Retrieve({
                        EntityId: response.Entity.SalesTaxId
                    }, response => {
                        this.form.TaxPercentage.value = response.Entity.TaxRatePercentage;
                        this.form.IGST.value = response.Entity.IGST;
                        this.form.SGST.value = response.Entity.SGST;
                        this.form.CGST.value = response.Entity.CGST;
                        this.setGstValuesBasedOnCustomerAndTenantState();
                        this.recalculate();
                    });
                });
            });

        }
        protected afterLoadEntity() {
            super.afterLoadEntity();
            if (this.isNew()) {


                // Check if the customer is selected when loading an entity
                if (Q.isEmptyOrNull(this.CustomerId)) {
                    Q.notifyError("Please select a customer before proceeding.");
                } else {
                    this.GetCustomerStateIdBasedOnCustomerId();
                }
            }
           // this.GetCustomerStateIdBasedOnCustomerId();
        }
        private recalculate() {
            this.form.SubTotal.value = this.form.Price.value * this.form.Qty.value;
            this.form.BeforeTax.value = this.form.SubTotal.value - this.form.Discount.value;
            this.form.TaxAmount.value = (this.form.TaxPercentage.value * this.form.BeforeTax.value) / 100;
            this.form.Total.value = this.form.BeforeTax.value + this.form.TaxAmount.value;

            this.form.IGSTAmount.value = 0;
            this.form.SGSTAmount.value = 0;
            this.form.CGSTAmount.value = 0;


            if (this.form.IGST.value > 0) {

                this.form.IGSTAmount.value = (this.form.TaxPercentage.value * this.form.BeforeTax.value) / 100;
                this.form.Total.value = this.form.BeforeTax.value + this.form.IGSTAmount.value;
            } else {

                const halfTaxPercentage = this.form.TaxPercentage.value / 2;
                this.form.CGSTAmount.value = (halfTaxPercentage * this.form.BeforeTax.value) / 100;
                this.form.SGSTAmount.value = (halfTaxPercentage * this.form.BeforeTax.value) / 100;

                this.form.Total.value = this.form.BeforeTax.value + this.form.CGSTAmount.value + this.form.SGSTAmount.value;
            }
        }

        

       

        protected updateInterface(): void {
            super.updateInterface();

            this.form.SubTotal.element.attr('readonly', 'readonly');
            this.form.SubTotal.element.addClass('readonly');

            this.form.BeforeTax.element.attr('readonly', 'readonly');
            this.form.BeforeTax.element.addClass('readonly');

            this.form.TaxAmount.element.attr('readonly', 'readonly');
            this.form.TaxAmount.element.addClass('readonly');

            this.form.Total.element.attr('readonly', 'readonly');
            this.form.Total.element.addClass('readonly');

            this.form.TaxPercentage.element.attr('readonly', 'readonly');
            this.form.TaxPercentage.element.addClass('readonly');

            this.form.IGST.element.attr('readonly', 'readonly');
            this.form.IGST.element.addClass('readonly');

            this.form.SGST.element.attr('readonly', 'readonly');
            this.form.SGST.element.addClass('readonly');

            this.form.CGST.element.attr('readonly', 'readonly');
            this.form.CGST.element.addClass('readonly');

            this.form.IGSTAmount.element.attr('readonly', 'readonly');
            this.form.IGSTAmount.element.addClass('readonly');

            this.form.SGSTAmount.element.attr('readonly', 'readonly');
            this.form.SGSTAmount.element.addClass('readonly');

            this.form.CGSTAmount.element.attr('readonly', 'readonly');
            this.form.CGSTAmount.element.addClass('readonly');

        }

        protected GetTenantStateId() {
            Indotalent.Projects.QuotationDetailService.CheckTenantStateId({}, response => {

                this.form.TenantState.value = response.StateId;
                this.compareStates();
            });
        }
        private compareStates() {
            if (this.CustomerState === this.form.TenantState.value) {

                this.form.CGST.getGridField().toggle(true);
                this.form.SGST.getGridField().toggle(true);
                this.form.IGST.getGridField().toggle(false);
                this.form.CGSTAmount.getGridField().toggle(true);
                this.form.SGSTAmount.getGridField().toggle(true);
                this.form.IGSTAmount.getGridField().toggle(false);
                this.form.TaxPercentage.getGridField().toggle(false);
            } else if (this.CustomerState !== this.form.TenantState.value) {
                this.form.CGST.getGridField().toggle(false);
                this.form.SGST.getGridField().toggle(false);
                this.form.CGSTAmount.getGridField().toggle(false);
                this.form.SGSTAmount.getGridField().toggle(false);
                this.form.IGST.getGridField().toggle(true);
                this.form.IGSTAmount.getGridField().toggle(true);
                this.form.TaxPercentage.getGridField().toggle(false);

            }
        }
        //protected GetCustomerStateId() {
        //    if (this.entity && this.entity.QuotationId) {
        //        Indotalent.Projects.QuotationService.Retrieve({
        //            EntityId: this.entity.QuotationId
        //        }, response => {
        //            this.CustomerIdFromEditor = response.Entity.CustomerId.toString();  // ✅ FIX HERE
        //            this.GetCustomerStateIdBasedOnCustomerId();
        //        });
        //    }
        //}

        protected GetCustomerStateId() {
            if (this.entity && this.entity.QuotationId) {
                Indotalent.Projects.QuotationService.Retrieve({
                    EntityId: this.entity.QuotationId
                }, response => {

                    this.CustomerIdFromEditor = response.Entity.CustomerStateName;
                    this.GetTenantStateId();
                });
            }
        }

        protected GetCustomerStateIdBasedOnCustomerId() {
            //if (Q.isEmptyOrNull(this.CustomerId)) {
            //    Q.alert("Please select a customer before proceeding.");
            //    return;
            //}
            Indotalent.Sales.CustomerService.Retrieve({
                EntityId: this.CustomerId
            }, response => {
                this.CustomerState = response.Entity.StateName.toString();
                this.GetTenantStateId();
            });
        }

        protected setGstValuesBasedOnCustomerAndTenantState() {

            if (this.CustomerState === this.form.TenantState.value) {

                this.form.IGST.value = 0;
                this.form.IGSTAmount.value = 0;
            } else if (this.CustomerState !== this.form.TenantState.value) {
                this.form.CGST.value = 0;
                this.form.SGST.value = 0;
                this.form.CGSTAmount.value = 0;
                this.form.SGSTAmount.value = 0;
            }
            this.compareStates();
        }

    }
}