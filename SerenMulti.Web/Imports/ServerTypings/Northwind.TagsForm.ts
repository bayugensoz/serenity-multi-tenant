namespace SerenMulti.Northwind {
    export interface TagsForm {
        Name: Serenity.StringEditor;
    }

    export class TagsForm extends Serenity.PrefixedContext {
        static formKey = 'Northwind.Tags';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!TagsForm.init)  {
                TagsForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;

                Q.initFormType(TagsForm, [
                    'Name', w0
                ]);
            }
        }
    }
}
