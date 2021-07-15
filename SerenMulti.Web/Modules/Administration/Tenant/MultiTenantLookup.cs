using Serenity.Abstractions;
using Serenity.Data;
using Serenity.Services;
using Serenity.Web;

namespace SerenMulti
{
    public class MultiTenantLookup<TRow> : RowLookupScript<TRow> where TRow : class, IRow, new()
    {
        public ISqlConnections SqlConnections;
        public IRequestContext Context;
        //public IRequestContextMultiTenant Context;
        public IUserRetrieveService UserRetriever;
        //public IMultiTenant Tenant;

        public UserDefinition userDef;
        public long TenantId;

        public MultiTenantLookup(ISqlConnections sqlConnections) : base(sqlConnections)
        {
            SqlConnections = sqlConnections;
        }

        public MultiTenantLookup(ISqlConnections sqlConnections, IRequestContext context, IUserRetrieveService userRetriever) : base(sqlConnections)
        {
            SqlConnections = sqlConnections;
            Context = context;
            UserRetriever = userRetriever;
        }
    }
}
