
namespace Indotalent.Purchase {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.panel()
    export class PurchaseReturnDialog extends Serenity.EntityDialog<PurchaseReturnRow, any> {
        protected getFormKey() { return PurchaseReturnForm.formKey; }
        protected getIdProperty() { return PurchaseReturnRow.idProperty; }
        protected getLocalTextPrefix() { return PurchaseReturnRow.localTextPrefix; }
        protected getNameProperty() { return PurchaseReturnRow.nameProperty; }
        protected getService() { return PurchaseReturnService.baseUrl; }
        protected getDeletePermission() { return PurchaseReturnRow.deletePermission; }
        protected getInsertPermission() { return PurchaseReturnRow.insertPermission; }
        protected getUpdatePermission() { return PurchaseReturnRow.updatePermission; }

        protected form = new PurchaseReturnForm(this.idPrefix);
        private loadedState: string;

        constructor() {
            super();
            this.form.ItemList.element.css('height', '300px');
            this.populatePurchaseReceiptId();
            (this.form.ItemList.view as any).onRowCountChanged.subscribe(() => {
                this.recalculate();
            });

            (this.form.ItemList.view as any).onDataChanged.subscribe(() => {
                this.recalculate();
            });

            Indotalent.DialogUtils.pendingChangesConfirmation(this.element, () => this.getSaveState() != this.loadedState);

            this.form.PurchaseReceiptId.changeSelect2((args) => {
                var purchaseReceiptId = this.form.PurchaseReceiptId.value;
                if (Q.isEmptyOrNull(purchaseReceiptId.toString())) {
                    return;
                }

                PurchaseReceiptService.Retrieve({
                    EntityId: purchaseReceiptId
                }, response => {
                    if (response.Entity.WarehouseId) {
                        this.form.WarehouseId.value = response.Entity.WarehouseId.toString();
                    }
                    if (response.Entity.ProjectId) {
                        this.form.ProjectId.value = response.Entity.ProjectId.toString();
                    }
                    if (response.Entity.LocationId) {
                        this.form.LocationId.value = response.Entity.LocationId.toString();
                    }

                });

                var request = [] as Serenity.ListRequest;
                PurchaseReceiptDetailService.List({
                    Criteria: Serenity.Criteria.and(request.Criteria, [['PurchaseReceiptId'], '=', purchaseReceiptId])
                }, response => {
                    var items = [];
                    for (var item of response.Entities) {
                        items.push({
                            ProductId: item.ProductId,
                            ProductName: item.ProductName,
                            QtyReturn: item.QtyReceive
                        });
                    }
                    this.form.ItemList.value = items;
                });
            });

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

        private recalculate() {

            this.form.TotalQtyReturn.value = 0;
            for (var item of this.form.ItemList.getItems()) {
                this.form.TotalQtyReturn.value += item.QtyReturn;
            }
        }

        protected updateInterface(): void {
            super.updateInterface();

            this.toolbar.findButton('print-return').toggle(this.isEditMode());
        }

        protected getToolbarButtons() {
            var buttons = super.getToolbarButtons();

            buttons.push(Serenity.Extensions.ReportHelper.createToolButton({
                title: 'Print Return',
                cssClass: 'export-pdf-button print-return',
                reportKey: 'PurchaseReturnPrint',
                getParams: () => ({
                    Id: this.get_entityId()
                })
            }));

            return buttons;
        }

        protected populatePurchaseReceiptId() {


            Purchase.PurchaseReceiptService.List({
                Criteria: [['IsPReturnCreated'], '=', false]
            }, response => {
                var items = [] as any[];


                response.Entities.forEach(item => {
                    items.push({
                        id: item.Id,
                        text: item.Number
                    });
                });


                this.form.PurchaseReceiptId.items = items;
            });


            this.form.PurchaseReceiptId.getGridField().toggle(true);

        }

        private SetPurchaseReceiptId() {


            let selectedPurchaseReceiptId = this.form.PurchaseReceiptId.value;
            Indotalent.Web.Modules.Purchase.PurchaseReturn.RequestContext.set("PurchaseReceiptId", selectedPurchaseReceiptId);


        }

        //New Implemetation for IsPRCreated based show product 02-04-2025
        //protected populatePurchaseReceiptDetailsOnPurchaseOrderSelect() {

        //    this.form.PurchaseReceiptId.changeSelect2((args) => {
        //        this.SetPurchaseReceiptId();
        //        var PurchaseReceiptId = this.form.PurchaseReceiptId.value;

        //        if (Q.isEmptyOrNull(PurchaseReceiptId)) {
        //            return;
        //        }

        //        Purchase.PurchaseReceiptService.Retrieve({
        //            EntityId: PurchaseReceiptId
        //        }, response => {

        //            if (response.Entity.ProjectId) {
        //                this.form.ProjectId.value = response.Entity.ProjectId.toString();
        //            }

        //            //if (response.Entity.VendorName) {
        //            //    this.form.VendorName.value = response.Entity.VendorName;
        //            //}

        //            var request = [] as Serenity.ListRequest;
        //            Purchase.PurchaseReceiptDetailService.List({
        //                Criteria: Serenity.Criteria.and(request.Criteria, [['PurchaseReceiptId'], '=', PurchaseReceiptId])
        //            }, response => {
        //                var items = [] as any[];

        //                for (var item of response.Entities) {
        //                    // Check if the PO for this item is complete
        //                    // Assuming there's an IsPOComplete field in the RequestDetail entity
        //                    if (!item.IsPReturnCreated) {
        //                        // Include the item in the PO if it's not fully purchased
        //                        items.push({
        //                            ProductId: item.ProductId,
        //                            ProductName: item.ProductName,
        //                            // QtyReceive: item.Qty,
        //                            Qty: item.Qty,
        //                            QtyRequest: item.QtyRequest,
        //                            InternalCode: item.InternalCode,

        //                        });
        //                    }
        //                }


        //                //if (this.form.VendorStateName.value == this.form.TenantState.value) {

        //                //    items.forEach(item => {
        //                //        item.IGST = 0;
        //                //    });
        //                //}
        //                //else {
        //                //    items.forEach(item => {
        //                //        item.SGST = 0;
        //                //        item.CGST = 0;
        //                //    });
        //                //}
        //                this.form.ItemList.value = items;
        //            });
        //        });
        //    });
        //}

    }
}

  