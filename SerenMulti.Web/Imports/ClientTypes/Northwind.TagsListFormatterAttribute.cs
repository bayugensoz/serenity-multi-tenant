using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace SerenMulti.Northwind
{
    public partial class TagsListFormatterAttribute : CustomFormatterAttribute
    {
        public const string Key = "SerenMulti.Northwind.TagsListFormatter";

        public TagsListFormatterAttribute()
            : base(Key)
        {
        }
    }
}
