
namespace Indotalent.Projects {

    @Serenity.Decorators.registerClass()
    export class ProjectMaterialRequestDetailEditor extends Serenity.Extensions.GridEditorBase<ProjectMaterialRequestDetailRow> {
        protected getColumnsKey() { return ProjectMaterialRequestDetailColumns.columnsKey; }
        protected getDialogType() { return ProjectMaterialRequestDetailDialog; }
        protected getLocalTextPrefix() { return ProjectMaterialRequestDetailRow.localTextPrefix; }


        constructor(container: JQuery) {
            super(container);
        }

        protected validateEntity(row: ProjectMaterialRequestDetailRow, id: number) {
            if (!super.validateEntity(row, id))
                return false;

            row.ProductName = Merchandise.ProductRow.getLookup()
                .itemById[row.ProductId].Name;

            return true;
        }

    }
}