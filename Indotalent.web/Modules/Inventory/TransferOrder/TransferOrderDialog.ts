
namespace Indotalent.Inventory {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.panel()
    export class TransferOrderDialog extends Serenity.EntityDialog<TransferOrderRow, any> {
        protected getFormKey() { return TransferOrderForm.formKey; }
        protected getIdProperty() { return TransferOrderRow.idProperty; }
        protected getLocalTextPrefix() { return TransferOrderRow.localTextPrefix; }
        protected getNameProperty() { return TransferOrderRow.nameProperty; }
        protected getService() { return TransferOrderService.baseUrl; }
        protected getDeletePermission() { return TransferOrderRow.deletePermission; }
        protected getInsertPermission() { return TransferOrderRow.insertPermission; }
        protected getUpdatePermission() { return TransferOrderRow.updatePermission; }

        protected form = new TransferOrderForm(this.idPrefix);
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

            Indotalent.DialogUtils.pendingChangesConfirmation(this.element, () => this.getSaveState() != this.loadedState);
        }

        private recalculate() {
            this.form.TotalQty.value = 0;

            for (var item of this.form.ItemList.getItems()) {
                this.form.TotalQty.value += item.Qty;
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

            this.toolbar.findButton('print-transfer').toggle(this.isEditMode());

        }

        protected getToolbarButtons() {
            var buttons = super.getToolbarButtons();

            buttons.push(Serenity.Extensions.ReportHelper.createToolButton({
                title: 'Print Transfer Order',
                cssClass: 'export-pdf-button print-transfer',
                reportKey: 'TransferOrderPrint',
                getParams: () => ({
                    Id: this.get_entityId()
                })
            }));

            return buttons;
        }

    }
}