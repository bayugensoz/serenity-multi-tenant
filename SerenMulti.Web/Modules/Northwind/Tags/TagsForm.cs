using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SerenMulti.Northwind.Forms
{
    [FormScript("Northwind.Tags")]
    [BasedOnRow(typeof(Entities.TagsRow), CheckNames = true)]
    public class TagsForm
    {
        public String Name { get; set; }
    }
}