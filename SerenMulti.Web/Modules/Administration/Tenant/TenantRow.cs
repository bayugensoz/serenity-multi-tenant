using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;
using System.IO;

namespace SerenMulti.Administration.Entities
{
    [ConnectionKey("Default"), Module("Administration"), TableName("tenants"), TwoLevelCached]
    [DisplayName("Tenant"), InstanceName("Tenant")]
    //[ReadPermission("Administration:Tenants")]
    //[ModifyPermission("Administration:Tenants")]
    [ReadPermission(PermissionKeys.Tenants)]
    [ModifyPermission(PermissionKeys.Tenants)]
    [LookupScript("Administration.Tenant")]
    public sealed class TenantRow : Row<TenantRow.RowFields>, IIdRow, INameRow
    {
        [DisplayName("Tenant Id"), Identity, IdProperty]
        public Int32? TenantId
        {
            get => fields.TenantId[this];
            set => fields.TenantId[this] = value;
        }

        [DisplayName("Tenant Name"), Size(255), NotNull, QuickSearch, NameProperty]
        public String TenantName
        {
            get => fields.TenantName[this];
            set => fields.TenantName[this] = value;
        }

        public TenantRow()
            : base()
        {
        }

        public TenantRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field TenantId;
            public StringField TenantName;
        }
    }
}
