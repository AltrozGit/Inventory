namespace Indotalent.Sales {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.panel()
    export class SalesOrderDetailDialog extends Serenity.Extensions.GridEditorDialog<SalesOrderDetailRow> {
        protected getFormKey() { return SalesOrderDetailForm.formKey; }
        protected getLocalTextPrefix() { return SalesOrderDetailRow.localTextPrefix; }

        protected form = new SalesOrderDetailForm(this.idPrefix);

        private CustomerId: string;
        private CustomerState: string;

        public set CustomerIdFromEditor(value: string) {
            this.CustomerId = value;
        }

        constructor() {
            super();

            this.form.Price.change(() => this.recalculate());
            this.form.Qty.change(() => this.recalculate());
            this.form.Discount.change(() => this.recalculate());
            this.form.TaxPercentage.change(() => this.recalculate());

            this.form.ProductId.changeSelect2(args => {
                var productId = this.form.ProductId.value;
                if (Q.isEmptyOrNull(productId)) {
                    return;
                }
                Merchandise.ProductService.Retrieve({
                    EntityId: productId
                }, response => {
                    this.form.Price.value = response.Entity.SalesPrice;
                    this.form.InternalCode.value = response.Entity.InternalCode;

                    Settings.SalesTaxService.Retrieve({
                        EntityId: response.Entity.SalesTaxId
                    }, response => {
                        this.form.TaxPercentage.value = response.Entity.TaxRatePercentage;
                        this.form.IGST.value = response.Entity.IGST;
                        this.form.SGST.value = response.Entity.SGST;
                        this.form.CGST.value = response.Entity.CGST;
                       // this.form.InternalCode.value = response.Entity.InternalCode;
                        this.setGstValuesBasedOnCustomerAndTenantState();
                        this.recalculate();
                    });
                });
            });
         
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

        protected afterLoadEntity() {
            super.afterLoadEntity();
            if (Q.isEmptyOrNull(this.CustomerId)) {
                Q.notifyError("Please select a customer before proceeding.");
            } else {
                this.GetCustomerStateIdBasedOnCustomerId();
            }
            if (this.entity && this.entity.SalesOrderId)
            {
                Indotalent.Sales.SalesOrderDetailService.CheckInvoiceGenerated({
                    SalesOrderId: this.entity.SalesOrderId
                }, response => {
                    if (response.IsInvoiceGenerated) {
                        this.setFieldsReadOnly();
                    } else {
                        this.setFieldsEditable();
                    }
                });
            } else {
                this.setFieldsEditable();
            }
        }
            
          /*  this.showHideTaxComponents();*/

        private setFieldsReadOnly() {
            Serenity.EditorUtils.setReadOnly(this.form.ProductId, true);
            Serenity.EditorUtils.setReadOnly(this.form.Price, true);
            Serenity.EditorUtils.setReadOnly(this.form.Qty, true);
            Serenity.EditorUtils.setReadOnly(this.form.Discount, true);
            Serenity.EditorUtils.setReadOnly(this.form.TaxPercentage, true);
        }

        private setFieldsEditable() {
            Serenity.EditorUtils.setReadOnly(this.form.ProductId, false);
            Serenity.EditorUtils.setReadOnly(this.form.Price, false);
            Serenity.EditorUtils.setReadOnly(this.form.Qty, false);
            Serenity.EditorUtils.setReadOnly(this.form.Discount, false);
            Serenity.EditorUtils.setReadOnly(this.form.TaxPercentage, false);
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
            Indotalent.Sales.SalesOrderDetailService.CheckTenantStateId({}, response => {

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
        protected GetCustomerStateId() {
            if (this.entity && this.entity.SalesOrderId) {
                Indotalent.Sales.SalesOrderService.Retrieve({
                    EntityId: this.entity.SalesOrderId
                }, response => {

                    this.CustomerIdFromEditor = response.Entity.CustomerStateName;
                    this.GetTenantStateId();                    
                });
            }
        }

        protected GetCustomerStateIdBasedOnCustomerId() {

            CustomerService.Retrieve({
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

        }
    }
}
