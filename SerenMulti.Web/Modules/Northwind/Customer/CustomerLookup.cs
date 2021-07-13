using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Web;
using SerenMulti.Northwind.Entities;

namespace SerenMulti.Northwind.Lookups
{
    [LookupScript]
    public class CustomerLookup : RowLookupScript<CustomerRow>
    {
        public CustomerLookup(ISqlConnections sqlConnections)
            : base(sqlConnections)
        {
            IdField = CustomerRow.Fields.CustomerID.PropertyName;
            TextField = CustomerRow.Fields.CompanyName.PropertyName;
        }
    }
}