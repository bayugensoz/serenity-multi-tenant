using Serenity;
using Serenity.Abstractions;
using Serenity.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SerenMulti
{
    public interface IMultiTenant 
    {
        public int TenantId { get; set; }
    }

    public class MultiTenant : IMultiTenant
    {
        public int TenantId { get; set; }

        public MultiTenant() { }
        public MultiTenant(int tenantId)
        {
            TenantId = tenantId;
        }
    }

    public interface IRequestContextMultiTenant : IRequestContext
    {
        public IMultiTenant Tenant { get; set; }
        public IUserRetrieveService UserRetriever { get; set; }
    }

    public class RequestContextMultiTenant : IRequestContextMultiTenant
    {
        public IMultiTenant Tenant { get; set; }
        public IUserRetrieveService UserRetriever { get; set; }

        public IBehaviorProvider Behaviors { get; set; }
        
        public IRequestContext Context { get; set; }
        public ITwoLevelCache Cache { get; }
        public ITextLocalizer Localizer { get; }
        public IPermissionService Permissions { get; }
        public ClaimsPrincipal User { get; set; }

        public RequestContextMultiTenant() { }

        public RequestContextMultiTenant(IRequestContext context, ITwoLevelCache cache, ITextLocalizer localizer, IPermissionService permissions, ClaimsPrincipal user, IUserRetrieveService userRetriever, IMultiTenant tenant)
        {
            Tenant = tenant;
            UserRetriever = userRetriever;
            Behaviors = context.Behaviors;
            Context = context;
            Cache = cache;
            Localizer = localizer;
            Permissions = permissions;
            User = user;
        }

        public abstract class ServiceEndpointMultiTenant : ServiceEndpoint
        {
            public static IUserRetrieveService UserRetriever { get; set; }
            public static IRequestContextMultiTenant ContextMultiTenant { get; set; }

            public ServiceEndpointMultiTenant(IUserRetrieveService userRetriever)
            {
                UserRetriever = userRetriever;
            }
        }

        public class BaseRepositoryMultiTenant : BaseRepository
        {
            public static IRequestContextMultiTenant ContextMultiTenant { get; set; }
            public static UserDefinition UserDef;

            public int TenantId => ContextMultiTenant.Tenant.TenantId;

            public BaseRepositoryMultiTenant(IRequestContextMultiTenant context) : base(context)
            {
                ContextMultiTenant = context;

                UserDef = context.User.GetUserDefinition<UserDefinition>(context.UserRetriever);
            }
        }
    }

}
