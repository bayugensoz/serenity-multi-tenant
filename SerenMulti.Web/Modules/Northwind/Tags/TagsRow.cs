using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;
using System.IO;

namespace SerenMulti.Northwind.Entities
{
    [ConnectionKey("Northwind"), Module("Northwind"), TableName("tags")]
    [DisplayName("Tags"), InstanceName("Tags")]
    [ReadPermission("Administration:General")]
    [ModifyPermission("Administration:General")]
    public sealed class TagsRow : Row<TagsRow.RowFields>, IIdRow
    {
        [DisplayName("Id"), Identity, IdProperty]
        public Int32? Id
        {
            get => fields.Id[this];
            set => fields.Id[this] = value;
        }

        [DisplayName("Name"), NotNull]
        public Stream Name
        {
            get => fields.Name[this];
            set => fields.Name[this] = value;
        }

        public TagsRow()
            : base()
        {
        }

        public TagsRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field Id;
            public StreamField Name;
        }
    }
}
