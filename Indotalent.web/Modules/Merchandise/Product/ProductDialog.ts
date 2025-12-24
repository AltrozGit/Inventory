
namespace Indotalent.Merchandise {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.panel()
    export class ProductDialog extends Serenity.EntityDialog<ProductRow, any> {

        protected getFormKey() { return ProductForm.formKey; }
        protected getIdProperty() { return ProductRow.idProperty; }
        protected getLocalTextPrefix() { return ProductRow.localTextPrefix; }
        protected getNameProperty() { return ProductRow.nameProperty; }
        protected getService() { return ProductService.baseUrl; }
        protected getDeletePermission() { return ProductRow.deletePermission; }
        protected getInsertPermission() { return ProductRow.insertPermission; }
        protected getUpdatePermission() { return ProductRow.updatePermission; }

        protected form = new ProductForm(this.idPrefix);
        private loadedState: string;

        constructor() {

            super();
            Indotalent.DialogUtils.pendingChangesConfirmation(this.element, () => this.getSaveState() != this.loadedState);   
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

        //protected getToolbarButtons() {
        //    var buttons = super.getToolbarButtons();

        //    buttons.push(Serenity.Extensions.ReportHelper.createToolButton({
        //        title: 'Print Brochure',
        //        cssClass: 'export-pdf-button print-brochure',
        //        reportKey: 'ProductPrint',
        //        getParams: () => ({
        //            Id: this.get_entityId()
        //        })
        //    }));

        //    return buttons;
        //}

        protected afterLoadEntity() {

            super.afterLoadEntity();

            if (this.isNew()) {
                Indotalent.Merchandise.ProductService.Currency({
                }, response => {
                    this.form.CurrencyName.value = response.Currency;
                });
            }

            this.onChangeSubscriber();
            this.onLoadConfiguration();
        }

        private onChangeSubscriber() {

            this.form.ProductType.changeSelect2((args) => {
                this.setInternalCodeWhenProductTypeChange();
            });

            this.form.HsnId.changeSelect2((args) => {
                this.populateInternalCodeWhenHsnSelected();
            });

            this.form.SacId.changeSelect2((args) => {
                this.populateInternalCodeWhenSacSelected();
            });
        }

        private onLoadConfiguration() {

            if (this.form.ProductType.value == "1")
                this.form.SacId.getGridField().toggle(false);
            else if (this.form.ProductType.value == "2")
                this.form.HsnId.getGridField().toggle(false);

            this.form.InternalCode.getGridField().toggle(false);
        }

        private populateInternalCodeWhenHsnSelected() {

            this.form.InternalCode.value = this.form.HsnId.selectedItem.HsnName;
        }

        private populateInternalCodeWhenSacSelected() {

            this.form.InternalCode.value = this.form.SacId.selectedItem.SacName;
        }

        private setInternalCodeWhenProductTypeChange() {

            if (this.form.ProductType.value == '1') {
                this.form.HsnId.getGridField().toggle(true);
                this.form.SacId.getGridField().toggle(false);
            }
            else if (this.form.ProductType.value == '2') {
                this.form.HsnId.getGridField().toggle(false);
                this.form.SacId.getGridField().toggle(true);
            }

            this.form.InternalCode.value = "";
        }
    }
}