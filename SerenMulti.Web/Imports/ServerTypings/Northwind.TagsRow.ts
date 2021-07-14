namespace SerenMulti.Northwind {
    export interface TagsRow {
        Id?: number;
        Name?: number[];
    }

    export namespace TagsRow {
        export const idProperty = 'Id';
        export const localTextPrefix = 'Northwind.Tags';
        export const deletePermission = 'Administration:General';
        export const insertPermission = 'Administration:General';
        export const readPermission = 'Administration:General';
        export const updatePermission = 'Administration:General';

        export declare const enum Fields {
            Id = "Id",
            Name = "Name"
        }
    }
}
