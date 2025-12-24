
namespace Indotalent.Sales {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.panel()
    export class SalesReturnDialog extends Serenity.EntityDialog<SalesReturnRow, any> {
        protected getFormKey() { return SalesReturnForm.formKey; }
        protected getIdProperty() { return SalesReturnRow.idProperty; }
        protected getLocalTextPrefix() { return SalesReturnRow.localTextPrefix; }
        protected getNameProperty() { return SalesReturnRow.nameProperty; }
        protected getService() { return SalesReturnService.baseUrl; }
        protected getDeletePermission() { return SalesReturnRow.deletePermission; }
        protected getInsertPermission() { return SalesReturnRow.insertPermission; }
        protected getUpdatePermission() { return SalesReturnRow.updatePermission; }

        protected form = new SalesReturnForm(this.idPrefix);
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

            this.form.SalesDeliveryId.changeSelect2((args) => {
                var salesDeliveryId = this.form.SalesDeliveryId.value;
                if (Q.isEmptyOrNull(salesDeliveryId.toString())) {
                    return;
                }

                SalesDeliveryService.Retrieve({
                    EntityId: salesDeliveryId
                }, response => {
                    if (response.Entity.ProjectId) {
                        this.form.ProjectId.value = response.Entity.ProjectId.toString();
                    }
                    if (response.Entity.WarehouseId) {
                        this.form.WarehouseId.value = response.Entity.WarehouseId.toString();
                    }
                    if (response.Entity.LocationId) {
                        this.form.LocationId.value = response.Entity.LocationId.toString();
                    }

                });

                var request = [] as Serenity.ListRequest;
                SalesDeliveryDetailService.List({
                    Criteria: Serenity.Criteria.and(request.Criteria, [['SalesDeliveryId'], '=', salesDeliveryId])
                }, response => {
                    var items = [];
                    for (var item of response.Entities) {
                        items.push({
                            ProductId: item.ProductId,
                            ProductName: item.ProductName,
                            QtyReturn: item.QtyDelivered
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
                reportKey: 'SalesReturnPrint',
                getParams: () => ({
                    Id: this.get_entityId()
                })
            }));

            return buttons;
        }

    }
}

   