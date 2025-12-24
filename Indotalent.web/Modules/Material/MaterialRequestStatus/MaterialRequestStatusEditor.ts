
namespace Indotalent.Material {

    @Serenity.Decorators.registerClass()
    export class MaterialRequestStatusEditor extends Serenity.Extensions.GridEditorBase<MaterialRequestStatusRow> {
        protected getColumnsKey() { return MaterialRequestStatusColumns.columnsKey; }
        protected getDialogType() { return MaterialRequestStatusDialog; }
        protected getLocalTextPrefix() { return MaterialRequestStatusRow.localTextPrefix; }


        constructor(container: JQuery) {
            super(container);
        }
        protected validateEntity(row: MaterialRequestStatusRow, id: number) {
            if (!super.validateEntity(row, id))
                return false;

            row.MaterialRequestStatusName = Material.StatusMasterRow.getLookup()
                .itemById[row.StatustId].MaterialRequestStatusName;

            return true;

        }

    }


}


