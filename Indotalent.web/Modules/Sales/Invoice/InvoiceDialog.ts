
namespace Indotalent.Sales {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.panel()
    export class InvoiceDialog extends Serenity.EntityDialog<InvoiceRow, any> {
        protected getFormKey() { return InvoiceForm.formKey; }
        protected getIdProperty() { return InvoiceRow.idProperty; }
        protected getLocalTextPrefix() { return InvoiceRow.localTextPrefix; }
        protected getNameProperty() { return InvoiceRow.nameProperty; }
        protected getService() { return InvoiceService.baseUrl; }
        protected getDeletePermission() { return InvoiceRow.deletePermission; }
        protected getInsertPermission() { return InvoiceRow.insertPermission; }
        protected getUpdatePermission() { return InvoiceRow.updatePermission; }

        protected form = new InvoiceForm(this.idPrefix);
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

            this.form.SalesOrderId.changeSelect2((args) => {
                var salesOrderId = this.form.SalesOrderId.value;
                if (Q.isEmptyOrNull(salesOrderId)) {
                    this.setCustomer({});
                    return;
                }
                SalesOrderService.Retrieve({
                    EntityId: salesOrderId
                }, response => {
                    this.form.OtherCharge.value = response.Entity.OtherCharge;
                    this.form.DispatchedBy.value = response.Entity.DispatchedBy;
                    this.form.DispatchedTo.value = response.Entity.DispatchedTo;
                    this.form.PlaceOfSupply.value = response.Entity.PlaceOfSupply;
                    var customerId = response.Entity.CustomerId;


                    var request = [] as Serenity.ListRequest;
                    SalesOrderDetailService.List({
                        Criteria: Serenity.Criteria.and(request.Criteria, [['SalesOrderId'], '=', salesOrderId])
                    }, response => {
                        var items = [];
                        for (var item of response.Entities) {
                            items.push({
                                ProductId: item.ProductId,
                                ProductName: item.ProductName,
                                Price: item.Price,
                                InternalCode: item.InternalCode,
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
                                SGSTAmount: item.SGSTAmount
                            });
                        }
                   
                        /*  this.form.ItemList.value = items;*/

                        CustomerService.Retrieve({
                            EntityId: customerId
                        }, response => {
                            this.setCustomer(response.Entity);
                          

                            if (this.form.CustomerStateName.value === this.form.TenantState.value) {
                               
                                items.forEach(item => {
                                    item.IGST = 0;
                                });
                            } else {
                               
                                items.forEach(item => {
                                    item.SGST = 0;
                                    item.CGST = 0;
                                });
                            }

                            this.form.ItemList.value = items;
                        });

                       
                    });
                   
                    //CustomerService.Retrieve({
                    //    EntityId: response.Entity.CustomerId
                    //}, response => {
                    //    this.setCustomer(response.Entity)
                       
                       
                    //  });
                   
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
            if (this.isNew()) {
                Serenity.EditorUtils.setReadOnly(this.form.SalesOrderId, false);
            } else {
                this.form.SalesOrderId.clearItems();
                Serenity.EditorUtils.setReadOnly(this.form.SalesOrderId, true);
            }

            this.setDialogueReadOnlyWhenInvoicePaymentGenerated();


        }

        protected setDialogueReadOnlyWhenInvoicePaymentGenerated() {

            const isInvoicePaymentGenerated = this.get_entity().IsInvoicePaymentGenerated;

            this.form.TenantState.getGridField().toggle(false);
            this.onAfterLoadEntitySubscriber();

            if (this.isNew()) {
                Indotalent.Sales.InvoiceService.Currency({
                }, response => {
                    this.form.CurrencyName.value = response.Currency;
                    this.form.TenantState.value = response.StateId;
                });

            }

            Serenity.EditorUtils.setReadOnly(this.form.Number, isInvoicePaymentGenerated);
            Serenity.EditorUtils.setReadonly(this.form.InvoiceDate.element, isInvoicePaymentGenerated);
            Serenity.EditorUtils.setReadonly(this.form.Description.element, isInvoicePaymentGenerated);
            Serenity.EditorUtils.setReadonly(this.form.SalesOrderId.element, isInvoicePaymentGenerated);
            Serenity.EditorUtils.setReadonly(this.form.DispatchedBy.element, isInvoicePaymentGenerated);
            Serenity.EditorUtils.setReadonly(this.form.DispatchedTo.element, isInvoicePaymentGenerated);
            Serenity.EditorUtils.setReadonly(this.form.PlaceOfSupply.element, isInvoicePaymentGenerated);
            Serenity.EditorUtils.setReadonly(this.form.OtherCharge.element, isInvoicePaymentGenerated);

            if (this.isNew()) {

                Serenity.EditorUtils.setReadOnly(this.form.Number, false);
                Serenity.EditorUtils.setReadonly(this.form.InvoiceDate.element, false);
                Serenity.EditorUtils.setReadonly(this.form.Description.element, false);
                Serenity.EditorUtils.setReadonly(this.form.SalesOrderId.element, false);
                Serenity.EditorUtils.setReadonly(this.form.DispatchedBy.element, false);
                Serenity.EditorUtils.setReadonly(this.form.DispatchedTo.element, false);
                Serenity.EditorUtils.setReadonly(this.form.PlaceOfSupply.element, false);
                Serenity.EditorUtils.setReadonly(this.form.OtherCharge.element, false);

            }
        }


        protected updateInterface(): void {
            super.updateInterface();

            this.toolbar.findButton('print-invoice').toggle(this.isEditMode());
        }

        private setCustomer(vendor: CustomerRow): void {
            this.form.CustomerName.value = vendor.Name;
            this.form.CustomerStreet.value = vendor.Street;
            this.form.CustomerCity.value = vendor.City;
            this.form.CustomerCountryName.value = vendor.CountryName;
            this.form.CustomerStateName.value = vendor.StateName;
            this.form.CustomerZipCode.value = vendor.ZipCode;
            this.form.CustomerPhone.value = vendor.Phone;
            this.form.CustomerEmail.value = vendor.Email;
        }

        protected getToolbarButtons() {
            var buttons = super.getToolbarButtons();

            buttons.push(Serenity.Extensions.ReportHelper.createToolButton({
                title: 'Print Invoice',
                cssClass: 'export-pdf-button print-invoice',
                reportKey: 'InvoicePrint',
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
    }
}