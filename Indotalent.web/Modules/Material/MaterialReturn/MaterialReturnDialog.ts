namespace Indotalent.Material {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.panel()
    export class MaterialReturnDialog extends Serenity.EntityDialog<MaterialReturnRow, any> {
        protected getFormKey() { return MaterialReturnForm.formKey; }
        protected getIdProperty() { return MaterialReturnRow.idProperty; }
        protected getLocalTextPrefix() { return MaterialReturnRow.localTextPrefix; }
        protected getNameProperty() { return MaterialReturnRow.nameProperty; }
        protected getService() { return MaterialReturnService.baseUrl; }
        protected getDeletePermission() { return MaterialReturnRow.deletePermission; }
        protected getInsertPermission() { return MaterialReturnRow.insertPermission; }
        protected getUpdatePermission() { return MaterialReturnRow.updatePermission; }

        protected form = new MaterialReturnForm(this.idPrefix);
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

            this.form.MaterialIssueId.changeSelect2((args) => {
                var materialIssueId = this.form.MaterialIssueId.value;
                if (Q.isEmptyOrNull(materialIssueId.toString())) {
                    return;
                }

                IssueService.Retrieve({
                    EntityId: materialIssueId
                }, response => {
                    if (response.Entity.WarehouseId) {
                        this.form.WarehouseId.value = response.Entity.WarehouseId.toString();
                    }
                    if (response.Entity.ProjectId) {
                        this.form.ProjectId.value = response.Entity.ProjectId.toString();
                    }
                    

                });

                var request = [] as Serenity.ListRequest;
                IssueDetailService.List({
                    Criteria: Serenity.Criteria.and(request.Criteria, [['MaterialIssueId'], '=', materialIssueId])
                }, response => {
                    var items = [];
                    for (var item of response.Entities) {
                        items.push({
                            ProductId: item.ProductId,
                            ProductName: item.ProductName,
                            QtyReturn: item.QtyIssue
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
                reportKey: 'PurchaseReturnPrint',
                getParams: () => ({
                    Id: this.get_entityId()
                })
            }));

            return buttons;
        }


    }
}