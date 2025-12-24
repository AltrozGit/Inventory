
namespace Indotalent.Bills {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.panel()
    export class BillDialog extends Serenity.EntityDialog<BillRow, any> {
        protected getFormKey() { return BillForm.formKey; }
        protected getIdProperty() { return BillRow.idProperty; }
        protected getLocalTextPrefix() { return BillRow.localTextPrefix; }
        protected getNameProperty() { return BillRow.nameProperty; }
        protected getService() { return BillService.baseUrl; }
        protected getDeletePermission() { return BillRow.deletePermission; }
        protected getInsertPermission() { return BillRow.insertPermission; }
        protected getUpdatePermission() { return BillRow.updatePermission; }

        protected form = new BillForm(this.idPrefix);
        private loadedState: string;

        constructor() {
            super();
            this.form.ItemList.element.css('height', '300px');

            this.populatePurchaseOrderId();

            (this.form.ItemList.view as any).onRowCountChanged.subscribe(() => {
                this.recalculate();
            });

            (this.form.ItemList.view as any).onDataChanged.subscribe(() => {
                this.recalculate();
            });

            this.form.OtherCharge.change(() => {
                this.recalculate();
            });

            Indotalent.DialogUtils.pendingChangesConfirmation(this.element, () => this.getSaveState() != this.loadedState);

            this.form.PurchaseOrderId.changeSelect2((args) => {
                var purchaseOrderId = this.form.PurchaseOrderId.value;

                if (Q.isEmptyOrNull(purchaseOrderId.toString())) {
                    // If no purchase order is selected, reset related fields
                    this.setVendor({});
                   // this.form.PurchaseReceiptId.value = null;
                   // this.form.PurchaseReceiptId.getGridField().toggle(false);
                    return;
                }

                // Show the PurchaseReceiptId field when a valid PurchaseOrderId is selected
               // this.form.PurchaseReceiptId.getGridField().toggle(true);

                // Retrieve PurchaseOrder details
                Purchase.PurchaseOrderService.Retrieve({
                    EntityId: purchaseOrderId
                }, response => {
                    // Set other form fields based on PurchaseOrder
                    this.form.OtherCharge.value = response.Entity.OtherCharge;
                    this.form.DispatchedTo.value = response.Entity.DispatchedTo;

                    //// Fetch the related PurchaseReceipts
                    //Purchase.PurchaseReceiptService.List({
                    //    Criteria: [['PurchaseOrderId'], '=', purchaseOrderId]
                    //}, receiptResponse => {
                    //    // Clear existing options by setting an empty list
                    //    this.form.PurchaseReceiptId.items = [];

                    //    // Add a default option (optional)
                    //    this.form.PurchaseReceiptId.addOption('', '-- Select Receipt --');

                    //    // Populate PurchaseReceiptId dropdown with available receipts
                    //    if (receiptResponse.Entities.length > 0) {
                    //        for (var receipt of receiptResponse.Entities) {
                    //            this.form.PurchaseReceiptId.addOption(receipt.Id.toString(), receipt.Number);
                    //        }
                    //    } else {
                    //        // If no receipts are found, reset PurchaseReceiptId
                    //        this.form.PurchaseReceiptId.value = null;
                    //    }
                    //});

                    var request = [] as Serenity.ListRequest;
                    Purchase.PurchaseOrderDetailService.List({
                        Criteria: Serenity.Criteria.and(request.Criteria, [['PurchaseOrderId'], '=', purchaseOrderId])
                    }, response => {
                        var items = [];
                        for (var item of response.Entities) {
                            if (item.IsBillCreated==false) {
                                items.push({

                                    ProductId: item.ProductId,
                                    ProductName: item.ProductName,
                                    Price: item.Price,
                                    Qty: item.Qty,
                                    SubTotal: item.SubTotal,
                                    Discount: item.Discount,
                                    BeforeTax: item.BeforeTax,
                                    TaxPercentage: item.TaxPercentage,
                                    TaxAmount: item.TaxAmount,
                                    Total: item.Total,
                                    IGST: item.IGST,
                                    CGST: item.CGST,
                                    SGST: item.SGST,
                                    IGSTAmount: item.IGSTAmount,
                                    CGSTAmount: item.CGSTAmount,
                                    SGSTAmount: item.SGSTAmount,
                                    InternalCode:item.InternalCode,
                                });
                            }
                        }
                        this.form.ItemList.value = items;
                    });

                    Purchase.VendorService.Retrieve({
                        EntityId: response.Entity.VendorId
                    }, response => {
                        this.setVendor(response.Entity)
                    });
                });
            });



        }

        //Products Based On Purchase Receipt
        //private SetPurchaseReceiptId() {


        //    let selectedPurchaseReceiptId = this.form.PurchaseReceiptId.value;
        //    Indotalent.Web.Modules.Bills.Bill.RequestContext.set("PurchaseReceiptId", selectedPurchaseReceiptId);

        //}


        //protected populateBilllDetailsOnPurchaseReceiptIdSelect() {
        //    var purchaseOrderId = this.form.PurchaseOrderId.value;

        //    var request = [] as Serenity.ListRequest;
        //    Purchase.PurchaseOrderDetailService.List({
        //        Criteria: Serenity.Criteria.and(request.Criteria, [['PurchaseOrderId'], '=', purchaseOrderId])
        //         }, poresponse => {
        //        var items = [];
        //        this.SetPurchaseReceiptId();
        //        var PurchaseReceiptId = this.form.PurchaseReceiptId.value;

        //        if (Q.isEmptyOrNull(PurchaseReceiptId)) {
        //              return;
        //        }

        //        Purchase.PurchaseReceiptService.Retrieve({
        //            EntityId: PurchaseReceiptId
        //           }, response => {
        //          var request = [] as Serenity.ListRequest;
        //            Purchase.PurchaseReceiptDetailService.List({
        //              Criteria: Serenity.Criteria.and(request.Criteria, [['PurchaseReceiptId'], '=', PurchaseReceiptId])
        //              }, prresponse => {
        //               var pritems = [] as any[];

        //                for (var poitem of poresponse.Entities) {

        //                    for (var pritem of prresponse.Entities) {

        //                        if ( poitem.ProductId==pritem.ProductId) {
        //                            if (!pritem.IsBillCreate  ) {
        //                                items.push({
        //                                    ProductId: pritem.ProductId,
        //                                    ProductName: pritem.ProductName,
        //                                    Price: poitem.Price,
        //                                    // Qty: pritem.Qty,
        //                                    Qty: pritem.QtyReceive,
        //                                    SubTotal: poitem.Price * pritem.QtyReceive,
        //                                    Discount: poitem.Discount,
        //                                    BeforeTax: (poitem.Price * pritem.QtyReceive) - poitem.Discount,
        //                                    TaxPercentage: poitem.TaxPercentage,
        //                                    TaxAmount: (poitem.TaxPercentage * ((poitem.Price * pritem.QtyReceive) - poitem.Discount)) / 100,
        //                                    Total: (((poitem.Price * pritem.QtyReceive) - poitem.Discount) + ((poitem.TaxPercentage * ((poitem.Price * pritem.QtyReceive) - poitem.Discount)) / 100)),
        //                                    IGST: poitem.IGST,
        //                                    CGST: poitem.CGST,
        //                                    SGST: poitem.SGST,


        //                                    //IGSTAmount: item.IGSTAmount,
        //                                    //CGSTAmount: item.CGSTAmount,
        //                                    //SGSTAmount: item.SGSTAmount
        //                                });
        //                            }

        //                        }


        //                    }
        //                }
        //                this.form.ItemList.value = items;
        //            });

        //        });


        //    });

        //}


        protected populatePurchaseOrderId() {

            // Fetch MaterialRequests for the selected Vendor where IsPOComplete is false
            Purchase.PurchaseOrderService.List({
                Criteria: [['IsBillCreated'], '=', false]  // Filter MaterialRequests where IsBillCreated = false
            }, response => {
                var items = [] as any[];


                response.Entities.forEach(item => {
                    items.push({
                        id: item.Id,
                        text: item.Number
                    });
                });

                // Set the filtered MaterialRequest items to the dropdown
                this.form.PurchaseOrderId.items = items;
            });

            // Toggle the visibility of MaterialRequestId grid field
            this.form.PurchaseOrderId.getGridField().toggle(true);

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
            this.form.SubTotal.value = 0;
            this.form.BeforeTax.value = 0;
            this.form.Discount.value = 0;
            this.form.TaxAmount.value = 0;
            this.form.Total.value = 0;

            for (var item of this.form.ItemList.getItems()) {
                this.form.SubTotal.value += item.SubTotal;
                this.form.Discount.value += item.Discount;
                this.form.BeforeTax.value += item.BeforeTax;
                this.form.TaxAmount.value += item.TaxAmount;
                this.form.Total.value += item.Total;
            }
            this.form.Total.value += this.form.OtherCharge.value;

            this.TDSTCSHideShow();

            this.TDSTCSTaxAmountCalculated();

        }

        protected afterLoadEntity() {
            super.afterLoadEntity();
            this.setDialogueReadOnlyWhenBillPaymentGenerated();


            //if (this.isNew()) {
            //    this.form.PurchaseOrderId.getGridField().toggle(false);
            //}

            //this.form.PurchaseReceiptId.changeSelect2((args) => {
            //    this.populateBilllDetailsOnPurchaseReceiptIdSelect();

            //});

            //this.SetPurchaseReceiptId();
        }


        protected setDialogueReadOnlyWhenBillPaymentGenerated() {
            const isBillPaymentGenerated = this.get_entity().IsBillPaymentGenerated;


            this.onAfterLoadEntitySubscriber();

            if (this.isNew()) {
                Indotalent.Bills.BillService.Currency({
                }, response => {
                    this.form.CurrencyName.value = response.Currency;

                });
            }

            Serenity.EditorUtils.setReadOnly(this.form.Number, isBillPaymentGenerated);
            Serenity.EditorUtils.setReadOnly(this.form.BillDate, isBillPaymentGenerated);
            Serenity.EditorUtils.setReadOnly(this.form.Description, isBillPaymentGenerated);
            Serenity.EditorUtils.setReadOnly(this.form.ExternalReferenceNumber, isBillPaymentGenerated);
            Serenity.EditorUtils.setReadOnly(this.form.DispatchedTo, isBillPaymentGenerated);
            Serenity.EditorUtils.setReadOnly(this.form.OtherCharge, isBillPaymentGenerated);

            if (this.isNew()) {

                Serenity.EditorUtils.setReadOnly(this.form.Number, false);
                Serenity.EditorUtils.setReadOnly(this.form.BillDate, false);
                Serenity.EditorUtils.setReadOnly(this.form.Description, false);
                Serenity.EditorUtils.setReadOnly(this.form.ExternalReferenceNumber, false);
                Serenity.EditorUtils.setReadOnly(this.form.DispatchedTo, false);
                Serenity.EditorUtils.setReadOnly(this.form.OtherCharge, false);
               

            }
        }


        protected updateInterface(): void {
            super.updateInterface();

            this.toolbar.findButton('print-bill').toggle(this.isEditMode());
        }

        private setVendor(vendor: Purchase.VendorRow): void {
            this.form.VendorName.value = vendor.Name;
            this.form.VendorStreet.value = vendor.Street;
            this.form.VendorCity.value = vendor.City;
            this.form.VendorStateName.value = vendor.StateName;
            this.form.VendorZipCode.value = vendor.ZipCode;
            this.form.VendorPhone.value = vendor.Phone;
            this.form.VendorEmail.value = vendor.Email;
            this.form.VendorGSTNumber.value = vendor.GSTNumber;
            this.form.VendorAccountNumber.value = vendor.AccountNumber;
            this.form.VendorIFSCCode.value = vendor.IFSCCode;
        }

        protected getToolbarButtons() {
            var buttons = super.getToolbarButtons();

            buttons.push(Serenity.Extensions.ReportHelper.createToolButton({
                title: 'Print Bill',
                cssClass: 'export-pdf-button print-bill',
                reportKey: 'BillPrint',
                getParams: () => ({
                    Id: this.get_entityId()
                })
            }));

            return buttons;
        }

        protected TDSTCSHideShow() {
            this.form.TaxType.change(() => {

                if (this.form.TaxType.value === '2') {

                    this.form.TCS.getGridField().toggle(true);
                    this.form.TDS.getGridField().toggle(false);

                }
                else if (this.form.TaxType.value === '1') {
                    this.form.TCS.getGridField().toggle(false);
                    this.form.TDS.getGridField().toggle(true);
                }

            });
        }

        protected TDSTCSTaxAmountCalculated() {
            this.form.TcsTdsTaxAmount.change(() => {

                if (this.form.TaxType.value === '2') {

                    this.form.FinalTotalPostTDS_TCS.value = (this.form.Total.value * this.form.TcsTdsTaxAmount.value / 100) + this.form.Total.value;
                }
                else if (this.form.TaxType.value === '1') {
                    this.form.FinalTotalPostTDS_TCS.value = this.form.Total.value - (this.form.Total.value * this.form.TcsTdsTaxAmount.value / 100);
                }
                else {

                    this.form.FinalTotalPostTDS_TCS.value = this.form.Total.value;
                }
            });
            this.form.FinalTotalPostTDS_TCS.value = this.form.Total.value;
        }

        protected onAfterLoadEntitySubscriber() {

            this.form.TDS.changeSelect2((args) => {
                this.getTdsPercent();
            });

            this.form.TCS.changeSelect2((args) => {
                this.getTcsPercent();
            });

            this.showHideInternalCodeBasedOnProductType();
        }

        protected showHideInternalCodeBasedOnProductType() {

            if (this.form.TaxType.value === '2') {
                this.form.TCS.getGridField().toggle(true);
                this.form.TDS.getGridField().toggle(false);
            } else if (this.form.TaxType.value === '1') {
                this.form.TCS.getGridField().toggle(false);
                this.form.TDS.getGridField().toggle(true);
            } else {
                this.form.TCS.getGridField().toggle(false);
                this.form.TDS.getGridField().toggle(false);
            }
        }

        protected getTdsPercent() {

            var purchaseTaxId = this.form.TDS.value;
            Indotalent.Settings.PurchaseTaxService.Retrieve({
                EntityId: purchaseTaxId
            }, response => {

                this.calculateTDS(response.Entity.TaxRatePercentage);

            });
        }

        protected getTcsPercent() {

            var purchaseTaxId = this.form.TCS.value;
            Indotalent.Settings.PurchaseTaxService.Retrieve({
                EntityId: purchaseTaxId
            }, response => {

                this.calculateTCS(response.Entity.TaxRatePercentage);

            });
        }

        protected calculateTDS(TaxRatePercentage: number) {

            this.form.TcsTdsTaxAmount.value = (this.form.Total.value * TaxRatePercentage) / 100;
            this.form.FinalTotalPostTDS_TCS.value = this.form.Total.value - this.form.TcsTdsTaxAmount.value;
        }

        protected calculateTCS(TaxRatePercentage: number) {

            this.form.TcsTdsTaxAmount.value = (this.form.Total.value * TaxRatePercentage) / 100;
            this.form.FinalTotalPostTDS_TCS.value = this.form.Total.value + this.form.TcsTdsTaxAmount.value;
        }

    }
}

    
