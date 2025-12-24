namespace Indotalent.Purchase {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.panel()
    export class PurchaseOrderDetailDialog extends Serenity.Extensions.GridEditorDialog<PurchaseOrderDetailRow> {

        protected getFormKey() { return PurchaseOrderDetailForm.formKey; }
        protected getLocalTextPrefix() { return PurchaseOrderDetailRow.localTextPrefix; }

        protected form = new PurchaseOrderDetailForm(this.idPrefix);     

       constructor() {
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
            this.form.TaxAmount.change(() => {
                this.recalculate();
            });
            this.form.QtyRequest.change(() => {
                this.recalculate();
            });

            this.form.ProductId.changeSelect2(args => {
                var productId = this.form.ProductId.value;
                if (Q.isEmptyOrNull(productId)) {
                    return;
                }
                this.GetPriceDetails(productId);

              
              
            });

        }

        private recalculate() {
          
            this.form.Price.value = this.form.Price.value;
            this.form.SubTotal.value = this.form.Price.value * this.form.Qty.value;
            this.form.BeforeTax.value = this.form.SubTotal.value - this.form.Discount.value;
            this.form.TaxAmount.value = (this.form.TaxPercentage.value * this.form.BeforeTax.value) / 100;
            this.form.Total.value = this.form.BeforeTax.value + this.form.TaxAmount.value;
            this.form.QtyRequest.value = this.form.QtyRequest.value;
            this.form.TaxPercentage.value = this.form.TaxPercentage.value;

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

            // validation for Quantity

            if (this.form.Qty.value > this.form.QtyRequest.value) {

                Q.notifyError('Quantity cannot be greater than Quantity Request.');


                this.form.Qty.value = this.form.QtyRequest.value;


            }
            

            // Adding validation for Quantity of PO Created
            if (this.form.Qty.value + this.form.QuanityofPOCreated.value > this.form.QtyRequest.value) {
                Q.notifyError('Total Quantity cannot be greater than Quantity Request.');
                this.form.Qty.value = this.form.QtyRequest.value - this.form.QuanityofPOCreated.value;
            }



        }

        private GetPriceDetails(productId: any) {
            Merchandise.ProductService.Retrieve({
                EntityId: productId
            }, response => {
                this.form.Price.value = response.Entity.PurchasePrice;
                this.form.TaxPercentage.value = response.Entity.PurchaseTaxId;

               
                Settings.PurchaseTaxService.Retrieve({
                    EntityId: response.Entity.PurchaseTaxId
                }, response => {
                    this.form.TaxPercentage.value = response.Entity.TaxRatePercentage;
                    this.recalculate();
                });

              
            });
        }

        private getmaterialRequestId() {

            let MaterialRequestId = Indotalent.Web.Modules.Purchase.PurchaseOrder.RequestContext.get("MaterialRequestId");
            this.form.MaterialRequestId.value = MaterialRequestId;

        }
      
        private GetQuantityOfPOCreated() {
         
            Indotalent.Purchase.PurchaseOrderDetailService.GetQuantityOfPOCreated({
                MaterialRequestId: Number(this.form.MaterialRequestId.value),
                ProductId: Number(this.form.ProductId.value)
            }, response => {
                if (response.RequestDetailRow.QuanityOfPOCreated != null)
                {
                    this.form.QuanityofPOCreated.value = response.RequestDetailRow.QuanityOfPOCreated;
                }
                else
                {
                    this.form.QuanityofPOCreated.value = 0;
                }
                
            });
        }


        protected afterLoadEntity() {
            super.afterLoadEntity();

           
            this.ShowHideGst();
            this.setDialogueReadonlyIfBillGenerated();
            this.getmaterialRequestId();
            this.GetQuantityOfPOCreated();
         
        }

        private setFieldsReadOnly() {
            Serenity.EditorUtils.setReadOnly(this.form.Price, true);
            Serenity.EditorUtils.setReadOnly(this.form.Qty, true);
            Serenity.EditorUtils.setReadOnly(this.form.Discount, true);
        }

        private setFieldsEditable() {
            Serenity.EditorUtils.setReadOnly(this.form.Price, false);
            Serenity.EditorUtils.setReadOnly(this.form.Qty, false);
            Serenity.EditorUtils.setReadOnly(this.form.Discount, false);
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

            this.form.ProductId.element.attr('readonly', 'readonly');
            this.form.ProductId.element.addClass('readonly');

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

            this.form.QuanityofPOCreated.element.attr('readonly', 'readonly');
            this.form.QuanityofPOCreated.element.addClass('readonly');
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
        protected setDialogueReadonlyIfBillGenerated() {
            if (this.entity && this.entity.PurchaseOrderId) {
                Indotalent.Purchase.PurchaseOrderDetailService.CheckBillGenerated({
                    PurchaseOrderId: this.entity.PurchaseOrderId
                }, response => {
                    if (response.IsBillGenerated) {
                        this.setFieldsReadOnly();
                    } else {
                        this.setFieldsEditable();
                    }
                });
            }
            else {
                this.setFieldsEditable();
            }
        }


    }
}