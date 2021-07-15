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
        [Width(80), EditLink, AlignRight]
        public Int32 Id { get; set; }
        [Width(240), EditLink]
        public String Name { get; set; }
    }
}