import projNameSpace = Indotalent.Projects

namespace Indotalent.Administration {
    
    @Serenity.Decorators.registerEditor()
    export class ProjectsCheckEditor extends Serenity.CheckTreeEditor<Serenity.CheckTreeItem<any>, any> {

        private searchText: string;
       

        constructor(div: JQuery) {
            super(div);
        }

        protected createToolbarExtensions() {
            super.createToolbarExtensions();

            Serenity.GridUtils.addQuickSearchInputCustom(this.toolbar.element, (field, text) => {
                this.searchText = Select2.util.stripDiacritics(text || '').toUpperCase();
                this.view.setItems(this.view.getItems(), true);
            });
        }

        protected getButtons() {
            return [];
        }

        protected getTreeItems() {
            return projNameSpace.ProjectRow.getLookup().items.map(project => <Serenity.CheckTreeItem<any>>{
                id: project.Id.toString(),
                text: project.Name
            });
        }

        protected onViewFilter(item) {
            return super.onViewFilter(item) &&
                (Q.isEmptyOrNull(this.searchText) ||
                 Select2.util.stripDiacritics(item.text || '')
                     .toUpperCase().indexOf(this.searchText) >= 0);
        }
    }
}