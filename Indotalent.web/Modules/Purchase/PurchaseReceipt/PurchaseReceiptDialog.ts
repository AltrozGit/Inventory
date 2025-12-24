
namespace Indotalent.Purchase {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.panel()
    export class PurchaseReceiptDialog extends Serenity.EntityDialog<PurchaseReceiptRow, any> {
        protected getFormKey() { return PurchaseReceiptForm.formKey; }
        protected getIdProperty() { return PurchaseReceiptRow.idProperty; }
        protected getLocalTextPrefix() { return PurchaseReceiptRow.localTextPrefix; }
        protected getNameProperty() { return PurchaseReceiptRow.nameProperty; }
        protected getService() { return PurchaseReceiptService.baseUrl; }
        protected getDeletePermission() { return PurchaseReceiptRow.deletePermission; }
        protected getInsertPermission() { return PurchaseReceiptRow.insertPermission; }
        protected getUpdatePermission() { return PurchaseReceiptRow.updatePermission; }

        protected form = new PurchaseReceiptForm(this.idPrefix);
        private loadedState: string;

        constructor() {
            super();
            this.form.ItemList.element.css('height', '300px');

            this.populatePurchaseOrder();

            (this.form.ItemList.view as any).onRowCountChanged.subscribe(() => {
                this.recalculate();
            });

            (this.form.ItemList.view as any).onDataChanged.subscribe(() => {
                this.recalculate();
            });

            Indotalent.DialogUtils.pendingChangesConfirmation(this.element, () => this.getSaveState() != this.loadedState);

            this.populatePurchaseReceiptDetailsOnPurchaseOrderSelect();

            //this.form.PurchaseOrderId.changeSelect2((args) => {
            //    var purchaseOrderId = this.form.PurchaseOrderId.value;
            //    if (Q.isEmptyOrNull(purchaseOrderId.toString())) {
            //        return;
            //    }

            //    this.form.VendorName.getGridField().toggle(true);

            //    Purchase.PurchaseOrderService.Retrieve({
            //        EntityId: purchaseOrderId
            //    }, response => {
                    
            //        if (response.Entity.ProjectId) {
            //            this.form.ProjectId.value = response.Entity.ProjectId.toString();
            //        }

            //        if (response.Entity.VendorName) {
            //            this.form.VendorName.value = response.Entity.VendorName; 
            //        }

            //        var request = [] as Serenity.ListRequest;
            //        Purchase.PurchaseOrderDetailService.List({
            //            Criteria: Serenity.Criteria.and(request.Criteria, [['PurchaseOrderId'], '=', purchaseOrderId])
            //        }, response => {
            //            var items = [];
            //            for (var item of response.Entities) {
            //                items.push({
            //                    ProductId: item.ProductId,
            //                    ProductName: item.ProductName,
            //                    QtyReceive: item.Qty,
            //                    Qty: item.Qty,
            //                    QtyRequest: item.QtyRequest
            //                });
            //            }
            //            this.form.ItemList.value = items;
            //        });
            //    });
            //});

            
        }
        private recalculate() {

            this.form.TotalQtyReceive.value = 0;
            for(var item of this.form.ItemList.getItems()) {
                this.form.TotalQtyReceive.value += item.QtyReceive;
            }
        }
        protected afterLoadEntity() {
            super.afterLoadEntity();

            this.SetPurchaseOrderId();

            if (this.isNew()) {
                this.form.VendorName.getGridField().toggle(false);
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
        }


        protected updateInterface(): void {
            super.updateInterface();

            this.toolbar.findButton('print-receipt').toggle(this.isEditMode());
        }

        protected getToolbarButtons() {
            var buttons = super.getToolbarButtons();

            buttons.push(Serenity.Extensions.ReportHelper.createToolButton({
                title: 'Print Receipt',
                cssClass: 'export-pdf-button print-receipt',
                reportKey: 'PurchaseReceiptPrint',
                getParams: () => ({
                    Id: this.get_entityId()
                })
            }));

            return buttons;
        }
        protected populatePurchaseOrder() {

                
                Purchase.PurchaseOrderService.List({
                    Criteria: [['IsPRCreate'], '=', false]  
                }, response => {
                    var items = [] as any[];


                    response.Entities.forEach(item => {
                        items.push({
                            id: item.Id,
                            text: item.Number
                        });
                    });

                   
                    this.form.PurchaseOrderId.items = items;
                });

                
            this.form.PurchaseOrderId.getGridField().toggle(true);
           
        }

        private SetPurchaseOrderId() {


            let selectedPurchaseOrderId = this.form.PurchaseOrderId.value;
            Indotalent.Web.Modules.Purchase.PurchaseReceipt.RequestContext.set("PurchaseOrderId", selectedPurchaseOrderId);

        }

        //New Implemetation for IsPRCreated based show product 02-04-2025
        protected populatePurchaseReceiptDetailsOnPurchaseOrderSelect() {

            this.form.PurchaseOrderId.changeSelect2((args) => {
                this.SetPurchaseOrderId();
                var PurchaseOrderId = this.form.PurchaseOrderId.value;

                if (Q.isEmptyOrNull(PurchaseOrderId)) {
                    return;
                }

                Purchase.PurchaseOrderService.Retrieve({
                    EntityId: PurchaseOrderId
                }, response => {

                    if (response.Entity.ProjectId) {
                                this.form.ProjectId.value = response.Entity.ProjectId.toString();
                            }

                            if (response.Entity.VendorName) {
                                this.form.VendorName.value = response.Entity.VendorName;
                            }

                    var request = [] as Serenity.ListRequest;
                    Purchase.PurchaseOrderDetailService.List({
                        Criteria: Serenity.Criteria.and(request.Criteria, [['PurchaseOrderId'], '=', PurchaseOrderId])
                    }, response => {
                        var items = [] as any[];

                        for (var item of response.Entities) {
                            // Check if the PO for this item is complete
                            // Assuming there's an IsPOComplete field in the RequestDetail entity
                            if (!item.IsPRCreate) {
                                // Include the item in the PO if it's not fully purchased
                                items.push({
                                    ProductId: item.ProductId,
                                  ProductName: item.ProductName,
                                 // QtyReceive: item.Qty,
                                  Qty: item.Qty,
                                    QtyRequest: item.QtyRequest,
                                    InternalCode: item.InternalCode,

                                });
                            }
                        }


                        //if (this.form.VendorStateName.value == this.form.TenantState.value) {

                        //    items.forEach(item => {
                        //        item.IGST = 0;
                        //    });
                        //}
                        //else {
                        //    items.forEach(item => {
                        //        item.SGST = 0;
                        //        item.CGST = 0;
                        //    });
                        //}
                        this.form.ItemList.value = items;
                    });
                });
            });
        }

    }
}

   