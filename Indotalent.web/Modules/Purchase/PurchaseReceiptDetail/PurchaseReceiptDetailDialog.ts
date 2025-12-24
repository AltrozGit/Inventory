
namespace Indotalent.Purchase {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.panel()
    export class PurchaseReceiptDetailDialog extends Serenity.Extensions.GridEditorDialog<PurchaseReceiptDetailRow> {
        protected getFormKey() { return PurchaseReceiptDetailForm.formKey; }
        protected getLocalTextPrefix() { return PurchaseReceiptDetailRow.localTextPrefix; }

        protected form = new PurchaseReceiptDetailForm(this.idPrefix);

        constructor() {
            super();
            this.form.PendingReceivableQty.value = 0;
           /* this.GetQuantityOfPRCreated();*/
            this.form.QtyReceive.change(() => {
                this.validateQtyReceiveAndQtyOfPRCreated();
            });
        }

        // Validation function for QtyReceive and QtyOfPRCreated
        private validateQtyReceiveAndQtyOfPRCreated() {
            const qtyReceive = this.form.QtyReceive.value;
            const qtyOfPRCreated = this.form.QuanityofPRCreated.value;
            const qty = this.form.Qty.value;

            // Check if the sum of QtyReceive and QtyOfPRCreated is greater than Qty (Purchase Quantity)
            if (qtyReceive + qtyOfPRCreated > qty) {
                Q.notifyError("The Total Quantity Received and Quantity of PR Created cannot be greater than the Purchase Quantity.");

                // Optionally reset the QtyReceive value to the maximum allowed value
                this.form.QtyReceive.value = qty - qtyOfPRCreated;

                // Optionally reset PendingReceivableQty
                this.form.PendingReceivableQty.value = this.form.Qty.value - this.form.QtyReceive.value;
            } else {
                // If validation passes, update PendingReceivableQty
                this.form.PendingReceivableQty.value = this.form.Qty.value - qtyReceive;
            }
        
        }
        private PurchaseOrderId() {
            // Assuming PurchaseReceipt is correctly defined
            let PurchaseOrderId = Indotalent.Web.Modules.Purchase.PurchaseReceipt.RequestContext.get("PurchaseOrderId");
            this.form.PurchaseOrderId.value = PurchaseOrderId;
        }


        private GetQuantityOfPRCreated() {
            Indotalent.Purchase.PurchaseReceiptDetailService.GetQuantityOfPRCreated({
                PurchaseOrderId: Number(this.form.PurchaseOrderId.value),
                ProductId: Number(this.form.ProductId.value)
            }, response => {
                // Add a check to ensure response.PurchaseOrderDetailRow is not null or undefined
                if (response.PurchaseOrderDetailRow && response.PurchaseOrderDetailRow.QuanityOfPRCreated != null) {

                    this.form.QuanityofPRCreated.value = response.PurchaseOrderDetailRow.QuanityOfPRCreated;
                } else {
                    this.form.QuanityofPRCreated.value = 0;
                }
            });
        }


        protected afterLoadEntity() {
            super.afterLoadEntity();

            // Set PendingReceivableQty to 0 when the entity is loaded
            if (this.form.PendingReceivableQty.value === null || this.form.PendingReceivableQty.value === undefined) {
                this.form.PendingReceivableQty.value = 0;
            }
            this.PurchaseOrderId();
            this.GetQuantityOfPRCreated();
        }

        protected updateInterface(): void {
            super.updateInterface();

            this.form.ProductId.element.attr('readonly', 'readonly');
            this.form.ProductId.element.addClass('readonly');

            this.form.QuanityofPRCreated.element.attr('readonly', 'readonly');
            this.form.QuanityofPRCreated.element.addClass('readonly');

            this.form.QuanityofPRCreated.element.attr('readonly', 'readonly');
            this.form.QuanityofPRCreated.element.addClass('readonly');

          // this.form.PendingReceivableQty.element.attr('readonly', 'readonly');
        }

           

    }
}
