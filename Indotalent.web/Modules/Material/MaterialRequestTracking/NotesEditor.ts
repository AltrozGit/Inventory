
namespace Indotalent.Material {

    @Serenity.Decorators.registerClass()
    export class NotesEditor extends Serenity.Extensions.GridEditorBase<MaterialRequestTrackingRow> {
        protected getColumnsKey() { return MaterialRequestTrackingColumns.columnsKey; }
        protected getDialogType() { return MaterialRequestTrackingDialog; }
        protected getLocalTextPrefix() { return MaterialRequestTrackingRow.localTextPrefix; }


        constructor(container: JQuery) {
            super(container);
        }
       

        }

    }
           
     
       
        



