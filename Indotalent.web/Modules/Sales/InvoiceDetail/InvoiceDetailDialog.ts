namespace Indotalent.Sales {
    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.panel()
    export class InvoiceDetailDialog extends Serenity.Extensions.GridEditorDialog<InvoiceDetailRow> {
        protected getFormKey() { return InvoiceDetailForm.formKey; }
        protected getLocalTextPrefix() { return InvoiceDetailRow.localTextPrefix; }

        protected form = new InvoiceDetailForm(this.idPrefix);

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
                    this.form.Price.value = response.Entity.PurchasePrice;
                    this.form.InternalCode.value= response.Entity.InternalCode;

                   

                    Settings.SalesTaxService.Retrieve({
                        EntityId: response.Entity.PurchaseTaxId
                    }, response => {
                        this.form.TaxPercentage.value = response.Entity.TaxRatePercentage;
                       
                        this.recalculate();
                    });
                });
            });

            this.afterLoadEntity();
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
            this.ShowHideGst();

            if (this.entity && this.entity.InvoiceId) {
                Indotalent.Sales.InvoiceDetailService.CheckInvoicePaymentGenerated({
                    InvoiceId: this.entity.InvoiceId
                }, response => {
                    if (response.IsInvoicePaymentGenerated) {
                        this.setFieldsReadOnly();
                    } else {
                        this.setFieldsEditable();
                    }
                });
            } else {
                this.setFieldsEditable();
            }
        }

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


        protected ShowHideGst() {

            if (this.form.IGST.value == 0) {
                this.form.CGST.getGridField().toggle(true);
                this.form.SGST.getGridField().toggle(true);
                this.form.IGST.getGridField().toggle(false);
                this.form.CGSTAmount.getGridField().toggle(true);
                this.form.SGSTAmount.getGridField().toggle(true);
                this.form.IGSTAmount.getGridField().toggle(false);
                this.form.TaxPercentage.getGridField().toggle(false);
            }
            else if (this.form.CGST.value == 0 && this.form.SGST.value == 0) {

                this.form.CGST.getGridField().toggle(false);
                this.form.SGST.getGridField().toggle(false);
                this.form.CGSTAmount.getGridField().toggle(false);
                this.form.SGSTAmount.getGridField().toggle(false);
                this.form.TaxPercentage.getGridField().toggle(false);
                this.form.IGST.getGridField().toggle(true);
                this.form.IGSTAmount.getGridField().toggle(true);
            }
        }
    }
}
