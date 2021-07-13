using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SerenMulti.Administration.Columns
{
    [ColumnsScript("Administration.Tenant")]
    [BasedOnRow(typeof(Entities.TenantRow), CheckNames = true)]
    public class TenantColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 TenantId { get; set; }
        [EditLink]
        public String TenantName { get; set; }
    }
}