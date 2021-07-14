using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SerenMulti.Northwind.Columns
{
    [ColumnsScript("Northwind.Tags")]
    [BasedOnRow(typeof(Entities.TagsRow), CheckNames = true)]
    public class TagsColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 Id { get; set; }
        public Stream Name { get; set; }
    }
}