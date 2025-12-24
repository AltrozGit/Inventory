namespace Indotalent.Material {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.panel()
    export class IssueDetailDialog extends Serenity.Extensions.GridEditorDialog<IssueDetailRow> {
        

        protected getFormKey() { return IssueDetailForm.formKey; }
        protected getLocalTextPrefix() { return IssueDetailRow.localTextPrefix; }

        protected form = new IssueDetailForm(this.idPrefix);

        constructor() {
            super();
             
            this.form.QtyIssue.change(() => {
                //if (this.form.QtyIssue.value > this.form.Qty.value || this.form.QtyIssue.value == 0) {

                //    if (this.form.QtyIssue.value == 0) {
                //        alert("Quantity Issue can not be Zero");
                //    }
                //    else {
                //        alert("Quantity Issue can not be greater than Quantity Purchase");
                //        this.form.QtyIssue.value = this.form.Qty.value;
                //        /*this.form.PurchasedQty.value = 0;*/
                //    }

                //}


                /* this.form.PurchasedQty.value = this.form.Qty.value - this.form.QtyIssue.value;*/
                this.recalculate();

                if (this.form.QtyIssue.value > this.form.AvailableStock.value) {

                    Q.notifyError('Quantity Issue cannot be greater than Available Stock.');


                    this.form.QtyIssue.value = this.form.AvailableStock.value;


                }

                this.validateQtyReceiveAndQtyOfIssueCreated();
            });
            
            this.form.ProductId.changeSelect2((args) => {
                var ProductId = this.form.ProductId.value;
                if (Q.isEmptyOrNull(ProductId)) {

                    return;
                }
                Merchandise.ProductService.Retrieve({
                    EntityId: ProductId
                }, response => {

                    if (response.Entity.UomId) {
                        this.form.UomId.value = response.Entity.UomId.toString();
                        this.form.PurchasePrice.value = response.Entity.PurchasePrice;

                    }

                });
            });

        }

        // Validation function for QtyReceive and QtyOfPRCreated
        private validateQtyReceiveAndQtyOfIssueCreated() {
            const qtyIssue = this.form.QtyIssue.value;
            const qtyOfIssueCreated = this.form.QuanityOfIssueCreated.value;
            const qurchasedQty = this.form.PurchasedQty.value;


            if (this.form.QtyIssue.value > this.form.PurchasedQty.value) {
                Q.notifyError('Quantity Issue cannot be greater than Quantity Purchased .');


                this.form.QtyIssue.value = this.form.PurchasedQty.value;
            }
           
            if (qtyIssue + qtyOfIssueCreated > qurchasedQty) {
                Q.notifyError("The Total Quantity Issue and Quantity of Issue Created cannot be greater than the Purchase Quantity.");

               
                this.form.QtyIssue.value = qurchasedQty - qtyOfIssueCreated;

               
            } 

        }

        private getPurchaseReceiptId() {

            let PurchaseReceiptId = Indotalent.Web.Modules.Material.Issue.RequestContext.get("PurchaseReceiptId");
            this.form.PurchaseReceiptId.value = PurchaseReceiptId;

        }

        private GetQuantityOfIssueCreated() {

            Indotalent.Material.IssueDetailService.GetQuantityOfIssueCreated({
                PurchaseReceiptId: Number(this.form.PurchaseReceiptId.value),
                ProductId: Number(this.form.ProductId.value)
            }, response => {
                if (response.PurchaseReceiptDetailRow.QuanityOfIssueCreated != null) {
                    this.form.QuanityOfIssueCreated.value = response.PurchaseReceiptDetailRow.QuanityOfIssueCreated;
                }
                else {
                    this.form.QuanityOfIssueCreated.value = 0;
                }

            });
        }
    

        protected updateInterface(): void {
            super.updateInterface();

            this.form.ProductId.element.attr('readonly', 'readonly');
            this.form.ProductId.element.addClass('readonly');
        }

        //protected afterLoadEntity() {

        //    super.afterLoadEntity();

        //    this.form.ProductId.value;
           


        //}
        protected afterLoadEntity() {
            super.afterLoadEntity();
            Serenity.EditorUtils.setReadOnly(this.form.QtyRequest, true);
            Serenity.EditorUtils.setReadonly(this.form.ProductId.element, true)
            Serenity.EditorUtils.setReadOnly(this.form.PurchasePrice, true);
            Serenity.EditorUtils.setReadOnly(this.form.SubTotal, true);
            this.recalculate();

            if (this.isNew()) {

                Serenity.EditorUtils.setReadOnly(this.form.QtyRequest, false);
                Serenity.EditorUtils.setReadOnly(this.form.PurchasePrice, false);
                Serenity.EditorUtils.setReadonly(this.form.ProductId.element, false)
            }
            this.getPurchaseReceiptId();
            this.GetQuantityOfIssueCreated();
           
        }

        private recalculate() {
            this.form.UomId.value = this.form.UomId.value;
            this.form.SubTotal.value = this.form.QtyIssue.value * this.form.PurchasePrice.value;


        }
    }
}
