
namespace Indotalent.Sales {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.panel()
    export class SalesDeliveryDialog extends Serenity.EntityDialog<SalesDeliveryRow, any> {
        protected getFormKey() { return SalesDeliveryForm.formKey; }
        protected getIdProperty() { return SalesDeliveryRow.idProperty; }
        protected getLocalTextPrefix() { return SalesDeliveryRow.localTextPrefix; }
        protected getNameProperty() { return SalesDeliveryRow.nameProperty; }
        protected getService() { return SalesDeliveryService.baseUrl; }
        protected getDeletePermission() { return SalesDeliveryRow.deletePermission; }
        protected getInsertPermission() { return SalesDeliveryRow.insertPermission; }
        protected getUpdatePermission() { return SalesDeliveryRow.updatePermission; }

        protected form = new SalesDeliveryForm(this.idPrefix);
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

            this.form.SalesOrderId.changeSelect2((args) => {
                var salesOrderId = this.form.SalesOrderId.value;
                if (Q.isEmptyOrNull(salesOrderId.toString())) {
                    return;
                }

                var request = [] as Serenity.ListRequest;
                Sales.SalesOrderDetailService.List({
                    Criteria: Serenity.Criteria.and(request.Criteria, [['SalesOrderId'], '=', salesOrderId])
                }, response => {
                    var items = [];
                    for (var item of response.Entities) {
                        items.push({
                            ProductId: item.ProductId,
                            ProductName: item.ProductName,
                            QtyDelivered: item.Qty
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

            this.form.TotalQtyDelivered.value = 0;
            for (var item of this.form.ItemList.getItems()) {
                this.form.TotalQtyDelivered.value += item.QtyDelivered;
            }
        }

        protected updateInterface(): void {
            super.updateInterface();

            this.toolbar.findButton('print-delivery').toggle(this.isEditMode());
        }

        protected getToolbarButtons() {
            var buttons = super.getToolbarButtons();

            buttons.push(Serenity.Extensions.ReportHelper.createToolButton({
                title: 'Print Delivery',
                cssClass: 'export-pdf-button print-delivery',
                reportKey: 'SalesDeliveryPrint',
                getParams: () => ({
                    Id: this.get_entityId()
                })
            }));

            return buttons;
        }

    }
}


   