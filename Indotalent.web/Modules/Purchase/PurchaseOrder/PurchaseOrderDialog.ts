namespace Indotalent.Purchase {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.panel()
    export class PurchaseOrderDialog extends Serenity.EntityDialog<PurchaseOrderRow, any> {
        protected getFormKey() { return PurchaseOrderForm.formKey; }
        protected getIdProperty() { return PurchaseOrderRow.idProperty; }
        protected getLocalTextPrefix() { return PurchaseOrderRow.localTextPrefix; }
        protected getNameProperty() { return PurchaseOrderRow.nameProperty; }
        protected getService() { return PurchaseOrderService.baseUrl; }
        protected getDeletePermission() { return PurchaseOrderRow.deletePermission; }
        protected getInsertPermission() { return PurchaseOrderRow.insertPermission; }
        protected getUpdatePermission() { return PurchaseOrderRow.updatePermission; }

        protected form = new PurchaseOrderForm(this.idPrefix);
        private loadedState: string;

        constructor() {
            super();
          
            Indotalent.DialogUtils.pendingChangesConfirmation(this.element, () => this.getSaveState() != this.loadedState);

            this.form.ItemList.element.css('height', '300px');

          


            this.onConstructorCallSubscriber();   

        }

        getSaveState() {
            try {
                return $.toJSON(this.getSaveEntity());
            }
            catch (e) {
                return null;
            }
        }

        protected getSaveEntity(): any {
            let entity = super.getSaveEntity();

            if (entity.ItemList && entity.ItemList.length > 0) {
                entity.ItemList = entity.ItemList.filter(x => x.IsSelected);
            }

            return entity;
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
                if (item.IsSelected) {
                    this.form.SubTotal.value += item.SubTotal;
                    this.form.Discount.value += item.Discount;
                    this.form.BeforeTax.value += item.BeforeTax;
                    this.form.TaxAmount.value += item.TaxAmount;
                    this.form.Total.value += item.Total;
                }
            }

            this.form.Total.value += this.form.OtherCharge.value;

            this.TDSTCSHideShow();

            this.TDSTCSTaxAmountCalculated();

           
        }

        protected afterLoadEntity() {

            super.afterLoadEntity();

            // chebox selection code
            this.form.ItemList.getItems().forEach(item => {
                if (item.IsSelected == null) {
                    item.IsSelected = true;
                }
            });

            this.form.ItemList.view.setItems(this.form.ItemList.getItems(), true);

            // 🔁 Automatically recalculate when individual checkboxes are clicked
            this.element.find('.grid-container').on('click', 'input[type=checkbox]', e => {
                // Delay needed to ensure IsSelected is updated
                setTimeout(() => this.recalculate(), 50);
            });

            this.form.TenantState.getGridField().toggle(false);
            this.onAfterLoadEntitySubscriber();
            this.setDialogueReadOnlyWhenBillGenerated();
            this.SetMaterialRequestId();
           
            // Automatically set Status to Completed (2) if both IsPRCreate and IsBillGenerated are true
            const entity = this.get_entity();

            if (entity.IsPRCreate && entity.IsBillGenerated && entity.Status === 1) {
                this.form.Status.value = "2"; // 2 = Completed
            }

            if (this.isNew()) {
                this.populateNewEntityDetails();
                this.form.MaterialRequestId.getGridField().toggle(false);
            }

        }

        protected updateInterface(): void {
            super.updateInterface();

            this.toolbar.findButton('print-po').toggle(this.isEditMode());

        }

        private setVendor(vendor: VendorRow): void {

            this.form.VendorName.value = vendor.Name;
            this.form.VendorStreet.value = vendor.Street;
            this.form.VendorCity.value = vendor.City;
            this.form.VendorCountryName.value = vendor.CountryName;
            this.form.VendorStateName.value = vendor.StateName;
            this.form.VendorZipCode.value = vendor.ZipCode;
            this.form.VendorPhone.value = vendor.Phone;
            this.form.VendorEmail.value = vendor.Email;
        }

        protected getToolbarButtons() {
            var buttons = super.getToolbarButtons();

            buttons.push(Serenity.Extensions.ReportHelper.createToolButton({
                title: 'Print PO',
                cssClass: 'export-pdf-button print-po',
                reportKey: 'PurchaseOrderPrint',
                getParams: () => ({
                    Id: this.get_entityId()
                })
            }));
          
            return buttons;
        }

       



        protected onConstructorCallSubscriber() {

            (this.form.ItemList.view as any).onRowCountChanged.subscribe(() => {
                this.recalculate();
            });

            (this.form.ItemList.view as any).onDataChanged.subscribe(() => {
                this.recalculate();
            });

            this.form.OtherCharge.change(() => {
                this.recalculate();
            });

            this.populatePurchaseOrderDetailsOnMaterialRequestSelect();
            this.populateVendorDataOnSelection();
        }
        //Old Method
        //protected populatePurchaseOrderDetailsOnMaterialRequestSelect() {

        //    this.form.MaterialRequestId.changeSelect2((args) => {

        //        var MaterialRequestId = this.form.MaterialRequestId.value;

        //        if (Q.isEmptyOrNull(MaterialRequestId)) {
        //            return;
        //        }

        //        Material.MaterialRequestService.Retrieve({
        //            EntityId: MaterialRequestId
        //        }, response => {
        //            var request = [] as Serenity.ListRequest;
        //            Material.RequestDetailService.List({
        //                Criteria: Serenity.Criteria.and(request.Criteria, [['MaterialRequestId'], '=', MaterialRequestId])
        //            }, response => {
        //                var items = [];

        //                for (var item of response.Entities) {
        //                    items.push({
        //                        ProductId: item.ProductId,
        //                        ProductName: item.ProductName,
        //                        QtyRequest: item.QtyRequest,
        //                        Price: item.PurchasePrice,
        //                        TaxPercentage: item.TaxRatePercentage,
        //                        AvailableStock: item.AvailableStock,
        //                        Discount: 0.00,
        //                        IGST: item.IGST,
        //                        CGST: item.CGST,
        //                        SGST: item.SGST
        //                    });
        //                }

        //                if (this.form.VendorStateName.value == this.form.TenantState.value) {

        //                    items.forEach(item => {
        //                        item.IGST = 0;
        //                    });
        //                }
        //                else {
        //                    items.forEach(item => {
        //                        item.SGST = 0;
        //                        item.CGST = 0;
        //                    });
        //                }

        //                this.form.ItemList.value = items;
        //            });
        //        });
        //    });
        //}

        
        private SetMaterialRequestId() {

            
                let selectedMaterialRequestId = this.form.MaterialRequestId.value;
                Indotalent.Web.Modules.Purchase.PurchaseOrder.RequestContext.set("MaterialRequestId", selectedMaterialRequestId);

        }

        //New Implemetation for IsPoCreated based show product 28-02-2025
        protected populatePurchaseOrderDetailsOnMaterialRequestSelect() {

            this.form.MaterialRequestId.changeSelect2((args) => {
                this.SetMaterialRequestId();
                var MaterialRequestId = this.form.MaterialRequestId.value;

                if (Q.isEmptyOrNull(MaterialRequestId)) {
                    return;
                }

                Material.MaterialRequestService.Retrieve({
                    EntityId: MaterialRequestId
                }, response => {
                    var request = [] as Serenity.ListRequest;
                    Material.RequestDetailService.List({
                        Criteria: Serenity.Criteria.and(request.Criteria, [['MaterialRequestId'], '=', MaterialRequestId])
                    }, response => {
                        var items = [] as any[];

                        for (var item of response.Entities) {
                            // Check if the PO for this item is complete
                            // Assuming there's an IsPOComplete field in the RequestDetail entity
                            if (!item.IsPOComplete) {
                                // Include the item in the PO if it's not fully purchased
                                items.push({
                                    ProductId: item.ProductId,
                                    ProductName: item.ProductName,
                                    QtyRequest: item.QtyRequest,
                                    Price: item.PurchasePrice,
                                    TaxPercentage: item.TaxRatePercentage,
                                    AvailableStock: item.AvailableStock,
                                    Discount: 0.00,
                                    IGST: item.IGST,
                                    CGST: item.CGST,
                                    SGST: item.SGST,
                                    InternalCode: item.InternalCode,
                                    
                                });
                            }
                        }

                      
                        if (this.form.VendorStateName.value == this.form.TenantState.value) {

                           items.forEach(item => {
                                   item.IGST = 0;
                                 });
                           }
                            else {
                              items.forEach(item => {
                               item.SGST = 0;
                               item.CGST = 0;
                             });
                        }
                        this.form.ItemList.value = items;
                    });
                });
            });
        }

       

        protected populateVendorDataOnSelection() {

            this.form.VendorId.changeSelect2((args) => {
                var vendorId = this.form.VendorId.value;

                if (Q.isEmptyOrNull(vendorId)) {
                    this.setVendor({});
                    return;
                }

                VendorService.Retrieve({
                    EntityId: vendorId
                }, response => {
                    this.setVendor(response.Entity);
                });

                // Fetch MaterialRequests for the selected Vendor where IsPOComplete is false
                Material.MaterialRequestService.List({
                    Criteria: [['IsPOComplete'], '=', false]  // Filter MaterialRequests where IsPOComplete = false
                }, response => {
                    var items = [] as any[];

                 
                    response.Entities.forEach(item => {
                        items.push({
                            id: item.Id,  
                            text: item.Number 
                        });
                    });

                    // Set the filtered MaterialRequest items to the dropdown
                    this.form.MaterialRequestId.items = items;
                });

                // Toggle the visibility of MaterialRequestId grid field
                this.form.MaterialRequestId.getGridField().toggle(true);
            });
        }

        protected onAfterLoadEntitySubscriber() {

            this.form.TDS.changeSelect2((args) => {
                this.getTdsPercent();
            });

            this.form.TCS.changeSelect2((args) => {
                this.getTcsPercent();                
            });

            //Auto recalculate on checkbox or item change
            (this.form.ItemList.view as any).onDataChanged.subscribe(() => {
                this.recalculate();
            });

            (this.form.ItemList.view as any).onRowCountChanged.subscribe(() => {
                this.recalculate();
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
      

    

        protected setDialogueReadOnlyWhenBillGenerated() {

         const isBillGenerated = this.get_entity().IsBillGenerated; 

            if (this.isNew()) {
                Indotalent.Purchase.PurchaseOrderService.Currency({
                }, response => {
                    this.form.CurrencyName.value = response.Currency;
                    this.form.DispatchedTo.value = response.StateId;
                });

                Indotalent.Purchase.PurchaseOrderService.GetTenant({
                }, response => {
                    var companyDetails = (response.Name + "\n" + response.Street + ",\t" +
                        response.City + ",\t" + response.ZipCode + ",\t" + response.StateId +
                        "\nPhone:" + response.Phone + "\nEmail:" +
                        response.Email).toString();
                    this.form.DispatchedTo.value = companyDetails;

                });
            }
            
            Serenity.EditorUtils.setReadOnly(this.form.Number, isBillGenerated);
            Serenity.EditorUtils.setReadonly(this.form.OrderDate.element, isBillGenerated);
            Serenity.EditorUtils.setReadonly(this.form.VendorId.element, isBillGenerated);
            Serenity.EditorUtils.setReadonly(this.form.QuotationReferenceNumber.element, isBillGenerated);
            Serenity.EditorUtils.setReadonly(this.form.Description.element, isBillGenerated);
            Serenity.EditorUtils.setReadonly(this.form.MaterialRequestId.element, isBillGenerated);
            Serenity.EditorUtils.setReadonly(this.form.UploadQuotation.element, isBillGenerated);
            Serenity.EditorUtils.setReadonly(this.form.DispatchedTo.element, isBillGenerated);
            Serenity.EditorUtils.setReadonly(this.form.OtherCharge.element, isBillGenerated);
        }

        protected populateNewEntityDetails() {

            Indotalent.Purchase.PurchaseOrderService.Currency({
            }, response => {
                this.form.CurrencyName.value = response.Currency;
                this.form.TenantState.value = response.StateId;
                this.form.DispatchedTo.value = response.StateId;
            });

            Indotalent.Purchase.PurchaseOrderService.GetTenant({

            }, response => {

                var companyDetails = (response.Name + "\n" + response.Street + ",\t" +

                    response.City + ",\t" + response.ZipCode + ",\t" + response.StateId +

                    "\nPhone:" + response.Phone + "\nEmail:" +

                    response.Email).toString();

                this.form.DispatchedTo.value = companyDetails;
            });
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
        
       
    }
}
