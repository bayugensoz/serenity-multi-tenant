
namespace SerenMulti.Northwind {

    @Serenity.Decorators.registerClass()
    export class TagsGrid extends Serenity.EntityGrid<TagsRow, any> {
        protected getColumnsKey() { return 'Northwind.Tags'; }
        protected getDialogType() { return TagsDialog; }
        protected getIdProperty() { return TagsRow.idProperty; }
        protected getInsertPermission() { return TagsRow.insertPermission; }
        protected getLocalTextPrefix() { return TagsRow.localTextPrefix; }
        protected getService() { return TagsService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}