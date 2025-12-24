
namespace Indotalent.Projects {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.panel()

    export class QuotationDialog extends Serenity.EntityDialog<QuotationRow, any> {
        protected getFormKey() { return QuotationForm.formKey; }
        protected getIdProperty() { return QuotationRow.idProperty; }
        protected getLocalTextPrefix() { return QuotationRow.localTextPrefix; }
        protected getNameProperty() { return QuotationRow.nameProperty; }
        protected getService() { return QuotationService.baseUrl; }
        protected getDeletePermission() { return QuotationRow.deletePermission; }
        protected getInsertPermission() { return QuotationRow.insertPermission; }
        protected getUpdatePermission() { return QuotationRow.updatePermission; }

        protected form = new QuotationForm(this.idPrefix);
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
                Indotalent.Sales.CustomerService.Retrieve({
                    EntityId: customerId
                }, response => {
                    this.setCustomer(response.Entity);


                    var customerDetails = (response.Entity.Name + "\n" + response.Entity.Street + ",\t" +
                        response.Entity.City + ",\t" + response.Entity.ZipCode + ",\t" + response.Entity.StateName +
                        "\nPhone:" + response.Entity.Phone + "\nEmail:" +
                        response.Entity.Email).toString();
                    //this.form.DispatchedTo.value = customerDetails;




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

           

        }

        protected afterLoadEntity() {
            super.afterLoadEntity();

            if (this.isNew()) {
                Indotalent.Projects.QuotationService.Currency({
                }, response => {
                    this.form.CurrencyName.value = response.Currency;
                });
            }
            this.form.TenantState.getGridField().toggle(false);
           // this.onAfterLoadEntitySubscriber();
            // this.setDialogueReadOnlyWhenBillInvoiceGenerated();
            this.PassCustomerIdToQuotationDetailEditor();
        }

        protected updateInterface(): void {
            super.updateInterface();

            this.toolbar.findButton('print-Quotation').toggle(this.isEditMode());
        }


        protected getToolbarButtons() {
            var buttons = super.getToolbarButtons();

            buttons.push(Serenity.Extensions.ReportHelper.createToolButton({
                title: 'Print Quotation',
                cssClass: 'export-pdf-button print-Quotation',
                reportKey: 'QuotationPrint',
                getParams: () => ({
                    Id: this.get_entityId()
                })
            }));

            return buttons;
        }

        private setCustomer(customer: Indotalent.Sales.CustomerRow): void {
            this.form.CustomerName.value = customer.Name;
            this.form.CustomerStreet.value = customer.Street;
            this.form.CustomerCity.value = customer.City;
            this.form.CustomerCountryName.value = customer.CountryName;
            this.form.CustomerStateName.value = customer.StateName;
            this.form.CustomerZipCode.value = customer.ZipCode;
            this.form.CustomerPhone.value = customer.Phone;
            this.form.CustomerEmail.value = customer.Email;
        }

        protected PassCustomerIdToQuotationDetailEditor() {

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
    }
}