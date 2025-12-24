namespace Indotalent.Bills {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.panel()
    export class BillDetailDialog extends Serenity.Extensions.GridEditorDialog<BillDetailRow> {
        protected getFormKey() { return BillDetailForm.formKey; }
        protected getLocalTextPrefix() { return BillDetailRow.localTextPrefix; }

        protected form = new BillDetailForm(this.idPrefix);

        constructor() {
            super();

            // Recalculate whenever values change
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

            // Fetch product details on change of ProductId
            this.form.ProductId.changeSelect2(args => {
                const productId = this.form.ProductId.value;
                if (Q.isEmptyOrNull(productId.toString())) {
                    return;
                }
                Merchandise.ProductService.Retrieve({
                    EntityId: productId
                }, response => {
                    this.form.Price.value = response.Entity.PurchasePrice;

                    // Retrieve tax details
                    Settings.PurchaseTaxService.Retrieve({
                        EntityId: response.Entity.PurchaseTaxId
                    }, response => {
                        this.form.TaxPercentage.value = response.Entity.TaxRatePercentage;
                        this.recalculate();
                    });
                });
            });

            
        }

        //// Retrieve PurchaseReceiptId from RequestContext and set it in the form
        //private GetPurchaseReceiptId() {
        //    let purchaseReceiptId = Indotalent.Web.Modules.Purchase.PurchaseOrder.RequestContext.get("PurchaseReceiptId");

        //    if (purchaseReceiptId != null) {
        //        this.form.PurchaseReceiptId.value = purchaseReceiptId;
        //    }

        //    // Log for debugging
        //    console.log("Retrieved PurchaseReceiptId:", purchaseReceiptId);

        //    // Now get the quantity of Bill created
        //    this.GetQuantityOfBillCreated();
        //}

       

        // Retrieve the Quantity of Bill Created for the current ProductId and PurchaseReceiptId
        //private GetQuantityOfBillCreated() {
        //    const purchaseOrderId = Number(this.form.PurchaseOrderId.value);
        //    const productId = Number(this.form.ProductId.value);

        //    if (purchaseOrderId && productId) {
        //        Indotalent.Bills.BillDetailService.GetQuantityOfBillCreated({
        //            PurchaseOrderId: purchaseOrderId,
        //            ProductId: productId
        //        }, response => {
        //            // Check if response contains the expected data
        //            if (response.PurchaseOrderDetailRow && response.PurchaseOrderDetailRow.QuanityofBillCreated != null) {
        //                this.form.QuanityofBillCreated.value = response.PurchaseOrderDetailRow.QuanityofBillCreated;
        //            } else {
        //                this.form.QuanityofBillCreated.value = 0;
        //            }
        //        });
        //    }
        //}
        private GetPurchaseOrderId() {

            let PurchaseOrderId = Indotalent.Web.Modules.Bills.Bill.RequestContext.get("PurchaseOrderId");
            this.form.PurchaseOrderId.value = PurchaseOrderId;

        }
       

        private GetQuantityOfBillCreated() {
            Indotalent.Bills.BillDetailService.GetQuantityOfBillCreated({
                PurchaseOrderId: Number(this.form.PurchaseOrderId.value),
                ProductId: Number(this.form.ProductId.value)
            }, response => {
                const detail = response.PurchaseOrderDetailRow;

                if (detail && detail.QuanityOfBillCreated != null) {
                    this.form.QuanityofBillCreated.value = detail.QuanityOfBillCreated;
                } else {
                    this.form.QuanityofBillCreated.value = 0;
                }
            });
        }

       


        // Recalculate totals whenever product price, quantity, discount, or tax percentage changes
        private recalculate() {
            this.form.SubTotal.value = this.form.Price.value * this.form.Qty.value;
            this.form.BeforeTax.value = this.form.SubTotal.value - this.form.Discount.value;
            this.form.TaxAmount.value = (this.form.TaxPercentage.value * this.form.BeforeTax.value) / 100;
            this.form.Total.value = this.form.BeforeTax.value + this.form.TaxAmount.value;

            // Handle IGST or CGST/SGST calculation
            if (this.form.IGST.value > 0) {
                this.form.IGSTAmount.value = (this.form.IGST.value * this.form.BeforeTax.value) / 100;
                this.form.Total.value = this.form.BeforeTax.value + this.form.IGSTAmount.value;
            } else {
                const halfTaxPercentage = this.form.TaxPercentage.value / 2;
                this.form.CGSTAmount.value = (halfTaxPercentage * this.form.BeforeTax.value) / 100;
                this.form.SGSTAmount.value = (halfTaxPercentage * this.form.BeforeTax.value) / 100;

                this.form.Total.value = this.form.BeforeTax.value + this.form.CGSTAmount.value + this.form.SGSTAmount.value;
            }
        }

        // After loading the entity, adjust the UI for read-only or editable fields
        protected afterLoadEntity() {
            super.afterLoadEntity();

            this.setDialogueReadonly();
            this.showHideTaxComponents();

            if (this.entity && this.entity.BillId) {
                Indotalent.Bills.BillDetailService.CheckBillPaymentGenerated({
                    BillId: this.entity.BillId
                }, response => {
                    if (response.IsBillPaymentGenerated) {
                        this.setFieldsReadOnly();
                    } else {
                        this.setFieldsEditable();
                    }
                });
            } else {
                this.setFieldsEditable();
            }

            this.GetPurchaseOrderId();
            this.GetQuantityOfBillCreated();

        }

        // Set fields as read-only if payment is already generated
        private setFieldsReadOnly() {
            Serenity.EditorUtils.setReadOnly(this.form.ProductId, true);
            Serenity.EditorUtils.setReadOnly(this.form.Price, true);
            Serenity.EditorUtils.setReadOnly(this.form.Qty, true);
            Serenity.EditorUtils.setReadOnly(this.form.Discount, true);
            Serenity.EditorUtils.setReadOnly(this.form.TaxPercentage, true);
        }

        // Set fields as editable
        private setFieldsEditable() {
            Serenity.EditorUtils.setReadOnly(this.form.ProductId, false);
            Serenity.EditorUtils.setReadOnly(this.form.Price, false);
            Serenity.EditorUtils.setReadOnly(this.form.Qty, false);
            Serenity.EditorUtils.setReadOnly(this.form.Discount, false);
            Serenity.EditorUtils.setReadOnly(this.form.TaxPercentage, false);
        }

        // Update the interface for readonly fields
        protected updateInterface(): void {
            super.updateInterface();

            // Make calculated fields read-only
            this.form.SubTotal.element.attr('readonly', 'readonly').addClass('readonly');
            this.form.BeforeTax.element.attr('readonly', 'readonly').addClass('readonly');
            this.form.TaxAmount.element.attr('readonly', 'readonly').addClass('readonly');
            this.form.Total.element.attr('readonly', 'readonly').addClass('readonly');
            this.form.IGST.element.attr('readonly', 'readonly').addClass('readonly');
            this.form.SGST.element.attr('readonly', 'readonly').addClass('readonly');
            this.form.CGST.element.attr('readonly', 'readonly').addClass('readonly');
            this.form.IGSTAmount.element.attr('readonly', 'readonly').addClass('readonly');
            this.form.SGSTAmount.element.attr('readonly', 'readonly').addClass('readonly');
            this.form.CGSTAmount.element.attr('readonly', 'readonly').addClass('readonly');
            this.form.QuanityofBillCreated.element.attr('readonly', 'readonly').addClass('readonly');
        }

        // Set read-only properties depending on conditions
        protected setDialogueReadonly() {
            if (this.form.Price.value == 0 || this.form.Qty.value == 0) {
                // Allow editing if price or quantity is 0
                Serenity.EditorUtils.setReadOnly(this.form.ProductId, false);
                Serenity.EditorUtils.setReadOnly(this.form.Price, false);
                Serenity.EditorUtils.setReadOnly(this.form.Qty, false);
                Serenity.EditorUtils.setReadOnly(this.form.Discount, false);
                Serenity.EditorUtils.setReadOnly(this.form.TaxPercentage, false);
            } else {
                // Set fields to readonly when they are not empty
                Serenity.EditorUtils.setReadOnly(this.form.ProductId, true);
                Serenity.EditorUtils.setReadOnly(this.form.Price, true);
                Serenity.EditorUtils.setReadOnly(this.form.Qty, true);
                Serenity.EditorUtils.setReadOnly(this.form.Discount, true);
                Serenity.EditorUtils.setReadOnly(this.form.TaxPercentage, true);
            }
        }

        // Show or hide tax components based on IGST or CGST/SGST selection
        protected showHideTaxComponents() {
            if (this.form.IGST.value == 0) {
                this.form.CGST.getGridField().toggle(true);
                this.form.SGST.getGridField().toggle(true);
                this.form.IGST.getGridField().toggle(false);
                this.form.CGSTAmount.getGridField().toggle(true);
                this.form.SGSTAmount.getGridField().toggle(true);
                this.form.IGSTAmount.getGridField().toggle(false);
                this.form.TaxPercentage.getGridField().toggle(false);
            } else if (this.form.CGST.value == 0 && this.form.SGST.value == 0) {
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
