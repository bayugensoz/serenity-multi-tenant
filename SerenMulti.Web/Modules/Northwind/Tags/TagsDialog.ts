
namespace SerenMulti.Northwind {

    @Serenity.Decorators.registerClass()
    export class TagsDialog extends Serenity.EntityDialog<TagsRow, any> {
        protected getFormKey() { return TagsForm.formKey; }
        protected getIdProperty() { return TagsRow.idProperty; }
        protected getLocalTextPrefix() { return TagsRow.localTextPrefix; }
        protected getService() { return TagsService.baseUrl; }
        protected getDeletePermission() { return TagsRow.deletePermission; }
        protected getInsertPermission() { return TagsRow.insertPermission; }
        protected getUpdatePermission() { return TagsRow.updatePermission; }

        protected form = new TagsForm(this.idPrefix);

    }
}