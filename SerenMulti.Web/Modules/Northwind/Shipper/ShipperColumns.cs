using Serenity.ComponentModel;
using System;
using System.ComponentModel;

namespace SerenMulti.Northwind.Forms
{
    [ColumnsScript("Northwind.Shipper")]
    [BasedOnRow(typeof(Entities.ShipperRow), CheckNames = true)]
    public class ShipperColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 ShipperID { get; set; }
        [EditLink, Width(300)]
        public String CompanyName { get; set; }
        [Width(150)]
        public String Phone { get; set; }
        public Int32 TenantId { get; set; }
    }
}