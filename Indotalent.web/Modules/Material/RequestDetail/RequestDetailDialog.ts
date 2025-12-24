
namespace Indotalent.Material {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.panel()
    export class RequestDetailDialog extends Serenity.Extensions.GridEditorDialog<RequestDetailRow> {
        protected getFormKey() { return RequestDetailForm.formKey; }
       // protected getIdProperty() { return RequestDetailRow.idProperty; }
        protected getLocalTextPrefix() { return RequestDetailRow.localTextPrefix; }
       // protected getService() { return RequestDetailService.baseUrl; }
       // protected getDeletePermission() { return RequestDetailRow.deletePermission; }
        //protected getInsertPermission() { return RequestDetailRow.insertPermission; }
        //protected getUpdatePermission() { return RequestDetailRow.updatePermission; }

        protected form = new RequestDetailForm(this.idPrefix);
        private originalQtyRequest: number;
        constructor() {
            super();
            this.form.QtyRequest.change(() => {
                this.recalculate();
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
                    // Always populate HSN code if available
                    if (response.Entity.HsnId) {
                        this.form.HsnId.value = response.Entity.HsnId.toString();
                        // If HSN is available, set it to internalcode
                        this.form.InternalCode.value = response.Entity.HsnId.toString();

                        // Fetch HSN Name (You can create a service or lookup to fetch the name)
                        Merchandise.HSNService.Retrieve({
                            EntityId: response.Entity.HsnId
                        }, hsnResponse => {
                            if (hsnResponse && hsnResponse.Entity) {
                                this.form.InternalCode.value = hsnResponse.Entity.HsnName || ''; // Set HSN Name to InternalCode
                            }

                        });
                    }

                    // If the product has SAC code and no HSN, populate SAC code and fetch SAC Name
                    else if (response.Entity.SacId) {
                        this.form.SacId.value = response.Entity.SacId.toString();

                        // Fetch SAC Name (You can create a service or lookup to fetch the name)
                        Merchandise.SACService.Retrieve({
                            EntityId: response.Entity.SacId
                        }, sacResponse => {
                            if (sacResponse && sacResponse.Entity) {
                                this.form.InternalCode.value = sacResponse.Entity.SacName || ''; // Set SAC Name to InternalCode
                            }
                        });
                    }

                    // If neither HSN nor SAC is available, clear internalcode (optional)
                    else {
                        this.form.InternalCode.value = '';
                    }

                });
            });
        }

        protected updateInterface(): void {
            super.updateInterface();


        }
        protected afterLoadEntity() {
            super.afterLoadEntity();
            this.originalQtyRequest = this.entity.QtyRequest; 

            const isPOComplete = this.entity.IsPOComplete;
            if (isPOComplete) {
                Serenity.EditorUtils.setReadOnly(this.form.QtyRequest, true);
                Serenity.EditorUtils.setReadonly(this.form.ProductId.element, true)
                Serenity.EditorUtils.setReadOnly(this.form.PurchasePrice, true);
                Serenity.EditorUtils.setReadOnly(this.form.SubTotal, true);
            }
            else {
                Serenity.EditorUtils.setReadOnly(this.form.QtyRequest, false);
                Serenity.EditorUtils.setReadOnly(this.form.PurchasePrice, false);
                Serenity.EditorUtils.setReadonly(this.form.ProductId.element, false)
            }
           
            this.recalculate();

            if (this.isNew()) {
                this.recalculate();
                Serenity.EditorUtils.setReadOnly(this.form.QtyRequest, false);
                Serenity.EditorUtils.setReadOnly(this.form.PurchasePrice, false);
                Serenity.EditorUtils.setReadonly(this.form.ProductId.element, false)
            }
        }

        private recalculate()
        {
            const currentQtyRequest = this.form.QtyRequest.value;
            this.originalQtyRequest = this.entity.QtyRequest; 

            if (currentQtyRequest==0 || this.originalQtyRequest === 0) {
                this.form.UomId.value = this.form.UomId.value;
                this.form.SubTotal.value = this.form.QtyRequest.value * this.form.PurchasePrice.value;
            }
            else if (currentQtyRequest > this.originalQtyRequest) {
                Q.notifyError("Qty Request cannot be increased beyond the original value.");
                this.form.QtyRequest.value = this.originalQtyRequest; 
            } 
            else {
                this.form.UomId.value = this.form.UomId.value;
                this.form.SubTotal.value = this.form.QtyRequest.value * this.form.PurchasePrice.value;
            }
           
        }
        //private recalculate() {
        //    this.form.UomId.value = this.form.UomId.value;
        //    this.form.SubTotal.value = this.form.QtyRequest.value * this.form.PurchasePrice.value;


        //}
     }
          
    }



           
    
        
    