using Serenity.Abstractions;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Services;
using System.Collections.Generic;
using MyRow = SerenMulti.Northwind.Entities.TagsRow;

namespace SerenMulti
{
    [LookupScript("Northwind.Tags")]
    public class TagsLookup : MultiTenantLookup<MyRow>
    {
        public TagsLookup(ISqlConnections sqlConnections, IRequestContext context, IUserRetrieveService userRetriever) : base(sqlConnections, context, userRetriever)
        {
            IdField = "Id"; TextField = "Name";
        }

        //protected override IEnumerable<MyRow> GetItems()
        //{
        //    return GetItemsMultiTenant("SELECT Id, Name FROM tags ORDER BY Name");
        //}
    }
}
