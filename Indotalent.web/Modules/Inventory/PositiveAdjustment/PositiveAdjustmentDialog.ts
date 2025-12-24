
namespace Indotalent.Inventory {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.panel()
    export class PositiveAdjustmentDialog extends Serenity.EntityDialog<PositiveAdjustmentRow, any> {
        protected getFormKey() { return PositiveAdjustmentForm.formKey; }
        protected getIdProperty() { return PositiveAdjustmentRow.idProperty; }
        protected getLocalTextPrefix() { return PositiveAdjustmentRow.localTextPrefix; }
        protected getNameProperty() { return PositiveAdjustmentRow.nameProperty; }
        protected getService() { return PositiveAdjustmentService.baseUrl; }
        protected getDeletePermission() { return PositiveAdjustmentRow.deletePermission; }
        protected getInsertPermission() { return PositiveAdjustmentRow.insertPermission; }
        protected getUpdatePermission() { return PositiveAdjustmentRow.updatePermission; }

        protected form = new PositiveAdjustmentForm(this.idPrefix);
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

            this.toolbar.findButton('print-adjustment').toggle(this.isEditMode());

        }

        protected getToolbarButtons() {
            var buttons = super.getToolbarButtons();

            buttons.push(Serenity.Extensions.ReportHelper.createToolButton({
                title: 'Print Adjustment',
                cssClass: 'export-pdf-button print-adjustment',
                reportKey: 'PositiveAdjustmentPrint',
                getParams: () => ({
                    Id: this.get_entityId()
                })
            }));

            return buttons;
        }

    }
}