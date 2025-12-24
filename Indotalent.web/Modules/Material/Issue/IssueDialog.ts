namespace Indotalent.Material {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.panel()
    export class IssueDialog extends Serenity.EntityDialog<IssueRow, any> {
        protected getFormKey() { return IssueForm.formKey; }
        protected getIdProperty() { return IssueRow.idProperty; }
        protected getLocalTextPrefix() { return IssueRow.localTextPrefix; }
        protected getNameProperty() { return IssueRow.nameProperty; }
        protected getService() { return IssueService.baseUrl; }
        protected getDeletePermission() { return IssueRow.deletePermission; }
        protected getInsertPermission() { return IssueRow.insertPermission; }
        protected getUpdatePermission() { return IssueRow.updatePermission; }

        protected form = new IssueForm(this.idPrefix);
        private loadedState: string;

        constructor() {
            super();
            this.form.ItemList.element.css('height', '300px');
            this.populateMaterialRequest();
            // Recalculate totals when rows are changed
            (this.form.ItemList.view as any).onRowCountChanged.subscribe(() => {
                this.recalculate();
            });

            (this.form.ItemList.view as any).onDataChanged.subscribe(() => {
                this.recalculate();
            });

            Indotalent.DialogUtils.pendingChangesConfirmation(this.element, () => this.getSaveState() != this.loadedState);

            this.form.MaterialRequestId.changeSelect2((args) => {
                var MaterialRequestId = this.form.MaterialRequestId.value;
                if (Q.isEmptyOrNull(MaterialRequestId.toString())) {

                    this.form.PurchaseReceiptId.value = null;
                    this.form.PurchaseReceiptId.getGridField().toggle(false);
                    return;
                }

                // Show the PurchaseReceiptId field when a valid MaterialRequestId is selected
                this.form.PurchaseReceiptId.getGridField().toggle(true);

                // Get PurchaseReceiptIds based on the selected MaterialRequestId
                Indotalent.Material.IssueService.GetPurchaseReceiptIdsByMaterialRequestId({
                    MaterialRequestId: Number(this.form.MaterialRequestId.value),
                }, response => {
                    if (response && response.PurchaseReceiptLists) {
                        this.form.PurchaseReceiptId.items = [];
                        //response.PurchaseReceiptLists.forEach((PurchaseReceipt) => {
                        //    this.form.PurchaseReceiptId.addOption(PurchaseReceipt.Id.toString(), PurchaseReceipt.Number);
                        //});

                        // Filter out only PurchaseReceiptIds where IsIssueCreated is false
                        response.PurchaseReceiptLists
                            .filter((PurchaseReceipt) => PurchaseReceipt.IsIssueCreated === false) // Only show those with IsIssueCreated == false
                            .forEach((PurchaseReceipt) => {
                                this.form.PurchaseReceiptId.addOption(PurchaseReceipt.Id.toString(), PurchaseReceipt.Number);
                            });
                    }
                });
            });

            this.form.PurchaseReceiptId.change(() => {
                this.populateIssueDetailsOnPurchaseReceiptSelect();
            });

        }
        protected populateMaterialRequest() {


            MaterialRequestService.List({
                Criteria: [['IsIssueCreated'], '=', false]
            }, response => {
                var items = [] as any[];


                response.Entities.forEach(item => {
                    items.push({
                        id: item.Id,
                        text: item.Number
                    });
                });


                this.form.MaterialRequestId.items = items;
            });


            this.form.MaterialRequestId.getGridField().toggle(true);

        }

        private SetPurchaseReceiptId() {

            let selectedPurchaseReceiptId = this.form.PurchaseReceiptId.value;
            Indotalent.Web.Modules.Material.Issue.RequestContext.set("PurchaseReceiptId", selectedPurchaseReceiptId);

        }

        //New Implemetation for 
        protected populateIssueDetailsOnPurchaseReceiptSelect() {
            this.form.PurchaseReceiptId.changeSelect2((args) => {
                var materialRequestIdId = this.form.MaterialRequestId.value;

                this.SetPurchaseReceiptId();
                var PurchaseReceiptId = this.form.PurchaseReceiptId.value;


                    if (Q.isEmptyOrNull(PurchaseReceiptId)) {
                        return;
                    }

                    Purchase.PurchaseReceiptService.Retrieve({
                        EntityId: PurchaseReceiptId
                    }, response => {
                        var request = [] as Serenity.ListRequest;
                        Purchase.PurchaseReceiptDetailService.List({
                            Criteria: Serenity.Criteria.and(request.Criteria, [['PurchaseReceiptId'], '=', PurchaseReceiptId])
                        }, prresponse => {


                            var request = [] as Serenity.ListRequest;

                            Purchase.PurchaseOrderDetailService.List({
                                Criteria: Serenity.Criteria.and(request.Criteria, [['PurchaseOrderId'], '=', prresponse.Entities[0].PurchaseOrderId])
                            }, poresponse => {
                                var items = [];

                           

                            if (response.Entity.ProjectId) {
                                this.form.ProjectId.value = response.Entity.ProjectId.toString();
                            }
                            if (response.Entity.WarehouseId) {
                                this.form.WarehouseId.value = response.Entity.WarehouseId.toString();
                            }
                            var pritems = [] as any[];

                            for (var poitem of poresponse.Entities) {

                                for (var pritem of prresponse.Entities)
                                {

                                    if (poitem.ProductId == pritem.ProductId) {
                                        if (!pritem.IsIssueCreated) {
                                            items.push({
                                                ProductId: pritem.ProductId,
                                                ProductName: pritem.ProductName,
                                                PurchasePrice: poitem.Price,
                                                QtyRequest: poitem.QtyRequest,
                                                AvailableStock: poitem.AvailableStock,
                                                //  PurchaseQty: pritem.Qty,
                                                PurchasedQty: pritem.QtyReceive,
                                                SubTotal: poitem.Price * pritem.QtyReceive,
                                                InternalCode: poitem.InternalCode,

                                            });
                                        }

                                    }
                                   

                                }
                            }
                            this.form.ItemList.value = items;
                        
                            });
                    });


                });

            });


        }


        private recalculate() {
            this.form.TotalQtyIssue.value = 0;
            this.form.Total.value = 0;
            for (var item of this.form.ItemList.getItems()) {
                this.form.TotalQtyIssue.value += item.QtyIssue;
                this.form.Total.value += item.SubTotal;
            }
        }

        protected afterLoadEntity() {
            super.afterLoadEntity();
            // Store the loaded state to track changes
            //this.loadedState = this.getSaveState();

            if (this.isNew()) {
                if (this.form.MaterialRequestId.value == null) {
                    this.form.PurchaseReceiptId.clearItems();
                }
                this.form.PurchaseReceiptId.getGridField().toggle(false);

            }



            this.SetPurchaseReceiptId();
            //this.populateIssueDetailsOnPurchaseReceiptSelect();

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
            this.toolbar.findButton('print-issue').toggle(this.isEditMode());
        }

        protected getToolbarButtons() {
            var buttons = super.getToolbarButtons();
            buttons.push(Serenity.Extensions.ReportHelper.createToolButton({
                title: 'Print Request',
                cssClass: 'export-pdf-button print-request',
                reportKey: 'IssuePrint',
                getParams: () => ({
                    Id: this.get_entityId()
                })
            }));
            return buttons;
        }
    }
}