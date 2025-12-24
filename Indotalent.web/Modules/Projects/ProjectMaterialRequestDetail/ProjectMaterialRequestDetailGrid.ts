namespace Indotalent.Projects {
    @Serenity.Decorators.registerClass()
    export class ProjectMaterialRequestDetailGrid extends Serenity.EntityGrid<ProjectMaterialRequestDetailRow, any> {
        protected getColumnsKey() { return ProjectMaterialRequestDetailColumns.columnsKey; }
        protected getDialogType() { return ProjectMaterialRequestDetailDialog; }
        protected getIdProperty() { return ProjectMaterialRequestDetailRow.idProperty; }
        protected getInsertPermission() { return ProjectMaterialRequestDetailRow.insertPermission; }
        protected getLocalTextPrefix() { return ProjectMaterialRequestDetailRow.localTextPrefix; }
        protected getService() { return ProjectMaterialRequestDetailService.baseUrl; }

        private projectMaterialRequestId: number;
        private selectedItems: { [key: number]: boolean } = {};

        constructor(container: JQuery, options?: any) {
            super(container);

            // Check if ProjectMaterialRequestId is passed in options
            if (options && options.projectMaterialRequestId) {
                this.projectMaterialRequestId = options.projectMaterialRequestId;

                // Refresh the grid to apply the filter
                this.refresh();
            }
        }

        protected onViewSubmit() {
            // Call the base method
            if (!super.onViewSubmit()) {
                return false;
            }

            // Add a filter for ProjectMaterialRequestId
            if (this.projectMaterialRequestId) {
                this.view.params.Criteria = Serenity.Criteria.and(
                    this.view.params.Criteria,
                    [[ProjectMaterialRequestDetailRow.Fields.ProjectMaterialRequestId], '=', this.projectMaterialRequestId]
                );
            }

            return true;
        }

        protected getButtons(): Serenity.ToolButton[] {
            let buttons = super.getButtons();

            // Add a custom button for creating a material request
            buttons.push({
                title: "Create Material Request",
                cssClass: "create-material-request",
                icon: "fa fa-plus-circle",
                onClick: () => {
                    this.createMaterialRequest();
                }
            });

            return buttons;
        }

        private createMaterialRequest() {
            // Get selected rows from the grid
            let selectedItems: number[] = [];
            let updatedItems: number[] = [];

            // Iterate over all checked checkboxes
            $('.select-row:checked').each(function () {
                let productId = $(this).data('product-id');  // Get ProductId from data-product-id attribute
                let projectMaterialRequestId = $(this).data('project-material-request-id'); // Get ProjectMaterialRequestId from data-project-material-request-id attribute

                // Ensure both are valid before pushing them
                if (productId && projectMaterialRequestId) {
                    // Store productId and projectMaterialRequestId separately
                    selectedItems.push(productId);
                    selectedItems.push(projectMaterialRequestId);
                }
            });

            // Check if any items are selected
            if (selectedItems.length === 0) {
                Q.notifyWarning("No items selected!");
                return;
            }

            // ✅ Process selected items
            console.log("Selected Product IDs:", selectedItems);

            // Example: Send to the server
            ProjectMaterialRequestService.CreateMaterialRequest({
                ItemIds: selectedItems.length > 0 ? selectedItems : []
            }, response => {
               // Q.notifySuccess("Material Request Created Successfully!");
                Q.notifySuccess(`Material Request Created Successfully for this Number: ${response.MaterialRequestId}`);
                
                // Refresh the grid to apply changes
                this.refresh();

                // Close the dialog
                this.element.dialog("close");
            });
        }

        protected updateInterface(): void {
            super.updateInterface();

            // Disable the default add button
            var addButton = this.toolbar.findButton('add-button');
            addButton.toggleClass('disabled', true);
        }

     
        protected getColumns(): Slick.Column[] {
            var columns = super.getColumns();
          
            // Add a checkbox column for selecting rows
            columns.unshift({
                name: "<input type='checkbox' id='select-all' />",  // Select All checkbox in header
                field: "IsSelected",
                format: (ctx) => {
                    let isChecked = this.selectedItems[ctx.item.ProductId] ? 'checked' : '';
                    let isDisabled = ctx.item.IsCompleteMRCreated ? 'disabled' : '';
                    return `<input type='checkbox' class='select-row' 
                data-product-id='${ctx.item.ProductId}' 
                data-project-material-request-id='${ctx.item.ProjectMaterialRequestId}' 
                data-is-mr-complete='${ctx.item.IsCompleteMRCreated}' 
                ${isChecked} ${isDisabled} />`;
                },
                width: 50,
                sortable: false,
                cssClass: "align-center"
            } as Slick.Column);


            // Add a handler for the "Select All" checkbox
            $(document).on('change', '#select-all', (e) => {
                const isChecked = $(e.currentTarget).is(':checked');

                // Ensure the view is initialized before accessing the items
                if (this.view) {
                    // Loop through all items in the grid and update selected state
                    this.view.getItems().forEach(item => {
                        const productId = item.ProductId;
                        const isMRComplete = item.IsCompleteMRCreated; // Flag for material request completion

                        // Only select items that are not marked as "IsCompleteMRCreated"
                        if (!isMRComplete) {
                            this.selectedItems[productId] = isChecked; // Update the state of selected items
                        }
                    });

                    // Update checkboxes in the grid
                    $('.select-row').each((index, checkbox) => {
                        const productId = $(checkbox).data('product-id');
                        const isMRComplete = $(checkbox).data('is-mr-complete');

                        // Ensure that already created MR products are not selected
                        if (!isMRComplete) {
                            $(checkbox).prop('checked', isChecked);  // Update checkbox state only if not completed
                        }
                    });
                }
            });

            // Add a handler for individual checkboxes
            $(document).on('change', '.select-row', (e) => {
                const productId = $(e.currentTarget).data('product-id');
                this.selectedItems[productId] = $(e.currentTarget).is(':checked'); // Update the state of selected items
            });

            return columns;
        }

    }
}
