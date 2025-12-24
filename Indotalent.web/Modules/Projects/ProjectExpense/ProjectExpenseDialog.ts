namespace Indotalent.Projects {

    @Serenity.Decorators.registerClass()
    export class ProjectExpenseDialog extends Serenity.EntityDialog<ProjectExpenseRow, any> {
        protected getFormKey() { return ProjectExpenseForm.formKey; }
        protected getIdProperty() { return ProjectExpenseRow.idProperty; }
        protected getLocalTextPrefix() { return ProjectExpenseRow.localTextPrefix; }
        protected getService() { return ProjectExpenseService.baseUrl; }
        protected getDeletePermission() { return ProjectExpenseRow.deletePermission; }
        protected getInsertPermission() { return ProjectExpenseRow.insertPermission; }
        protected getUpdatePermission() { return ProjectExpenseRow.updatePermission; }

        protected form = new ProjectExpenseForm(this.idPrefix);

        constructor() {
            super();

            // Optional date check
            this.form.ExpenseDate.changeSelect2((args) => {
                let ExpenseDate = this.form.ExpenseDate.value;
                let TodaysDate = Q.formatDate(new Date(), 'yyyy-MM-dd');
                if (ExpenseDate > TodaysDate) {
                    Q.alert("Expense date cannot be in the future.");
                    this.form.ExpenseDate.value = TodaysDate;
                }
            });

            // Project ID change handler
            this.form.ProjectId.changeSelect2((args) => {
                let projectId = this.form.ProjectId.value;
                if (Q.isEmptyOrNull(projectId)) {
                    Q.alert("Please select a valid project.");
                }
            });
        }

        // Overriding the save method to include fund validation
        protected save(callback: (response: Serenity.SaveResponse) => void): void {
            const projectId = this.form.ProjectId.value;
            const newExpense = this.form.Cost.value;

            if (!projectId || isNaN(newExpense)) {
                Q.alert("Please select a project and enter a valid expense amount.");
                return;
            }

            Q.serviceCall({
                url: Q.resolveUrl("~/Services/Projects/ProjectExpense/GetProjectExpenseFundAvailability"),
                request: {
                    ProjectId: Number(projectId),
                    NewExpense: newExpense
                },
                onSuccess: (response: ProjectExpenseFundAvailabilityResponse) => {
                    console.log("Server response:", response);

                    if (!response.IsFundAvailable) {
                        Q.alert("Entered expense exceeds available funds.");
                        return;
                    }

                    super.save(callback); // save if funds are available
                },
                onError: (error) => {
                    console.error("Validation check failed:", error);
                    Q.alert("Error while checking fund availability.");
                }
            });
        }

    }
}
