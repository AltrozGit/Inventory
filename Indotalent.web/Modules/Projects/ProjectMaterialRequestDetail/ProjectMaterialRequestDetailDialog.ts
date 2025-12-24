
namespace Indotalent.Projects {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.panel()
    export class ProjectMaterialRequestDetailDialog extends Serenity.Extensions.GridEditorDialog<ProjectMaterialRequestDetailRow> {
        protected getFormKey() { return ProjectMaterialRequestDetailForm.formKey; }
        // protected getIdProperty() { return ProjectMaterialRequestDetailRow.idProperty; }
        protected getLocalTextPrefix() { return ProjectMaterialRequestDetailRow.localTextPrefix; }
       // protected getService() { return ProjectMaterialRequestDetailService.baseUrl; }
       // protected getDeletePermission() { return ProjectMaterialRequestDetailRow.deletePermission; }
        // protected getInsertPermission() { return ProjectMaterialRequestDetailRow.insertPermission; }
       // protected getUpdatePermission() { return ProjectMaterialRequestDetailRow.updatePermission; }

        protected form = new ProjectMaterialRequestDetailForm(this.idPrefix);
        constructor() {
            super();

            this.form.QtyRequest.change(() => {
                this.recalculate();
            });

            this.form.PurchasePrice.change(() => {
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

                });
            });

        }
        protected updateInterface(): void {
            super.updateInterface();

        }
        protected afterLoadEntity() {
            super.afterLoadEntity();
            const isCompleteMRCreated = this.entity.IsCompleteMRCreated;
            if (isCompleteMRCreated) {
                Serenity.EditorUtils.setReadOnly(this.form.QtyRequest, true);
                Serenity.EditorUtils.setReadonly(this.form.ProductId.element, true)
                Serenity.EditorUtils.setReadOnly(this.form.PurchasePrice, true);
                Serenity.EditorUtils.setReadOnly(this.form.SubTotal, true);
                Serenity.EditorUtils.setReadOnly(this.form.PendingMaterialRequestQty, true);
            }
            else {
                Serenity.EditorUtils.setReadOnly(this.form.QtyRequest, false);
                Serenity.EditorUtils.setReadonly(this.form.ProductId.element, false)
                Serenity.EditorUtils.setReadOnly(this.form.PurchasePrice, false);
                Serenity.EditorUtils.setReadOnly(this.form.SubTotal, false);
                Serenity.EditorUtils.setReadOnly(this.form.PendingMaterialRequestQty, false);
            }
            this.recalculate();

            if (this.isNew()) {
                const isCompleteMRCreated = this.entity.IsCompleteMRCreated;
                if (isCompleteMRCreated) {
                    Serenity.EditorUtils.setReadOnly(this.form.QtyRequest, true);
                    Serenity.EditorUtils.setReadonly(this.form.ProductId.element, true)
                    Serenity.EditorUtils.setReadOnly(this.form.PurchasePrice, true);
                    Serenity.EditorUtils.setReadOnly(this.form.SubTotal, true);
                    Serenity.EditorUtils.setReadOnly(this.form.PendingMaterialRequestQty, true);
                }
                else
                {
                    Serenity.EditorUtils.setReadOnly(this.form.QtyRequest, false);
                    Serenity.EditorUtils.setReadOnly(this.form.PurchasePrice, false);
                    Serenity.EditorUtils.setReadonly(this.form.ProductId.element, false)
                    Serenity.EditorUtils.setReadOnly(this.form.PendingMaterialRequestQty, false);
                }
               
            }
        }


        private recalculate() {
            this.form.UomId.value = this.form.UomId.value;
            this.form.SubTotal.value = this.form.QtyRequest.value * this.form.PurchasePrice.value;
            this.form.PendingMaterialRequestQty.value = this.form.QtyRequest.value;  
        }
    }

}

    
