namespace Indotalent.Sales {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.panel()
    export class SalesOrderDialog extends Serenity.EntityDialog<SalesOrderRow, any> {
        protected getFormKey() { return SalesOrderForm.formKey; }
        protected getIdProperty() { return SalesOrderRow.idProperty; }
        protected getLocalTextPrefix() { return SalesOrderRow.localTextPrefix; }
        protected getNameProperty() { return SalesOrderRow.nameProperty; }
        protected getService() { return SalesOrderService.baseUrl; }
        protected getDeletePermission() { return SalesOrderRow.deletePermission; }
        protected getInsertPermission() { return SalesOrderRow.insertPermission; }
        protected getUpdatePermission() { return SalesOrderRow.updatePermission; }

        protected form = new SalesOrderForm(this.idPrefix);
        private loadedState: string;

        constructor() {
            super();
            this.form.ItemList.element.css('height', '300px');

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

            this.form.CustomerId.changeSelect2((args) => {
                var customerId = this.form.CustomerId.value;
                if (Q.isEmptyOrNull(customerId)) {
                    this.setCustomer({});
                    return;
                }
                CustomerService.Retrieve({
                    EntityId: customerId
                }, response => {
                    this.setCustomer(response.Entity);


                    var customerDetails = (response.Entity.Name + "\n" + response.Entity.Street + ",\t" +
                        response.Entity.City + ",\t" + response.Entity.ZipCode + ",\t" + response.Entity.StateName +
                        "\nPhone:" + response.Entity.Phone + "\nEmail:" +
                        response.Entity.Email).toString();
                    this.form.DispatchedTo.value = customerDetails;

                   


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
            this.form.TenantState.getGridField().toggle(false);
            this.onAfterLoadEntitySubscriber();
            this.setDialogueReadOnlyWhenBillInvoiceGenerated();
        }


        protected setDialogueReadOnlyWhenBillInvoiceGenerated() {

            const isInvoiceGenerated = this.get_entity().IsInvoiceGenerated;

            if (this.isNew()) {
                Indotalent.Sales.SalesOrderService.Currency({
                }, response => {
                    this.form.CurrencyName.value = response.Currency;
                });
                Indotalent.Purchase.PurchaseOrderService.GetTenant({
                }, response => {

                  
                    this.form.PlaceOfSupply.value = response.StateId;

                });
            }


            Serenity.EditorUtils.setReadOnly(this.form.Number, isInvoiceGenerated);
            Serenity.EditorUtils.setReadOnly(this.form.OrderDate, isInvoiceGenerated);
            Serenity.EditorUtils.setReadOnly(this.form.Description, isInvoiceGenerated);
            Serenity.EditorUtils.setReadOnly(this.form.CustomerId, isInvoiceGenerated);
            Serenity.EditorUtils.setReadOnly(this.form.SalesChannelId, isInvoiceGenerated);
            Serenity.EditorUtils.setReadOnly(this.form.DispatchedBy, isInvoiceGenerated);
            Serenity.EditorUtils.setReadOnly(this.form.DispatchedTo, isInvoiceGenerated);
            Serenity.EditorUtils.setReadOnly(this.form.PlaceOfSupply, isInvoiceGenerated);
            Serenity.EditorUtils.setReadOnly(this.form.OtherCharge, isInvoiceGenerated);

            if (this.isNew()) {

                Serenity.EditorUtils.setReadOnly(this.form.Number, false);
                Serenity.EditorUtils.setReadOnly(this.form.OrderDate, false);
                Serenity.EditorUtils.setReadOnly(this.form.Description, false);
                Serenity.EditorUtils.setReadOnly(this.form.CustomerId, false);
                Serenity.EditorUtils.setReadOnly(this.form.SalesChannelId, false);
                Serenity.EditorUtils.setReadOnly(this.form.DispatchedBy, false);
                Serenity.EditorUtils.setReadOnly(this.form.DispatchedTo, false);
                Serenity.EditorUtils.setReadOnly(this.form.PlaceOfSupply, false);
                Serenity.EditorUtils.setReadOnly(this.form.OtherCharge, false);
            }
        }
        
        protected updateInterface(): void {
            super.updateInterface();
            this.toolbar.findButton('print-so').toggle(this.isEditMode());
            //var addButton = this.toolbar.findButton('add-button');
            //addButton.toggleClass('disabled', true);
            //addButton.text('New Button Text'); // Change the text here
           
        }

        private setCustomer(customer: CustomerRow): void {
            this.form.CustomerName.value = customer.Name;
            this.form.CustomerStreet.value = customer.Street;
            this.form.CustomerCity.value = customer.City;
            this.form.CustomerCountryName.value = customer.CountryName;
            this.form.CustomerStateName.value = customer.StateName;
            this.form.CustomerZipCode.value = customer.ZipCode;
            this.form.CustomerPhone.value = customer.Phone;
            this.form.CustomerEmail.value = customer.Email;
        }

        protected getToolbarButtons() {
            var buttons = super.getToolbarButtons();

            buttons.push(Serenity.Extensions.ReportHelper.createToolButton({
                title: 'Print Customer Order',
                cssClass: 'export-pdf-button print-so',
                reportKey: 'SalesOrderPrint',
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
            this.PassCustomerIdToSalesOrderDetailEditor();
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

            var salesTaxId = this.form.TDS.value;
            Indotalent.Settings.SalesTaxService.Retrieve({
                EntityId: salesTaxId
            }, response => {

                this.calculateTDS(response.Entity.TaxRatePercentage);

            });
        }

        protected getTcsPercent() {

            var salesTaxId = this.form.TCS.value;
            Indotalent.Settings.SalesTaxService.Retrieve({
                EntityId: salesTaxId
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

        protected PassCustomerIdToSalesOrderDetailEditor() {

            this.form.CustomerId.changeSelect2((args) => {
                var customerId = this.form.CustomerId.value;

                if (Q.isEmptyOrNull(customerId)) {
                    return;
                }

                this.form.ItemList.CustomerId = customerId;
                
            });

            if (!this.isNew())
                this.form.ItemList.CustomerId = this.form.CustomerId.value;

          
        }
       

        //protected setGstValuesBasedOnCustomerAndTenantState()
        //{
        //    this.form.CustomerId.changeSelect2((args) =>
        //    {
        //        var customerId = this.form.CustomerId.value;

        //        if (Q.isEmptyOrNull(customerId)) {
        //            return;
        //        }

        //        var customerState = this.form.CustomerStateName.value;
        //        var tenantState = this.form.TenantState.value;
        //        if (customerState === tenantState)
        //        {
                   
        //           (this.form.ItemList as any).IGST.value = 0;
        //        }
        //        else
        //        {
        //          (this.form.ItemList as any).CGST.value = 0;
        //          (this.form.ItemList as any).SGST.value = 0;
      
        //    }
        //       });
        //}
    }
}
