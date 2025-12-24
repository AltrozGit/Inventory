
namespace Indotalent.Projects {

    @Serenity.Decorators.registerClass()
    export class ProjectExpenseEditor extends Serenity.Extensions.GridEditorBase<ProjectExpenseRow> {
        protected getColumnsKey() { return ProjectExpenseColumns.columnsKey; }
        protected getDialogType() { return ProjectExpenseDialog; }
        protected getLocalTextPrefix() { return ProjectExpenseRow.localTextPrefix; }


        constructor(container: JQuery) {
            super(container);
        }

        protected validateEntity(row: ProjectExpenseRow, id: number) {
            if (!super.validateEntity(row, id))
                return false;

            return true;
        }

    }
}