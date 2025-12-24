
namespace Indotalent.Projects {

    @Serenity.Decorators.registerClass()
    export class ProjectFundEditor extends Serenity.Extensions.GridEditorBase<ProjectFundRow> {
        protected getColumnsKey() { return ProjectFundColumns.columnsKey; }
        protected getDialogType() { return ProjectFundDialog; }
        protected getLocalTextPrefix() { return ProjectFundRow.localTextPrefix; }


        constructor(container: JQuery) {
            super(container);
        }

        protected validateEntity(row: ProjectFundRow, id: number) {
            if (!super.validateEntity(row, id))
                return false;

            return true;
        }

    }
}