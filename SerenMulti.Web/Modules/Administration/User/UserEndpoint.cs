using Microsoft.AspNetCore.Mvc;
using Serenity;
using Serenity.Abstractions;
using Serenity.Data;
using Serenity.Services;
using System.Data;
using static SerenMulti.RequestContextMultiTenant;
using MyRepository = SerenMulti.Administration.Repositories.UserRepository;
using MyRow = SerenMulti.Administration.Entities.UserRow;

namespace SerenMulti.Administration.Endpoints
{
    [Route("Services/Administration/User/[action]")]
    [ConnectionKey(typeof(MyRow)), ServiceAuthorize(typeof(MyRow))]
    public class UserController : ServiceEndpointMultiTenant
    {
        [HttpPost, AuthorizeCreate(typeof(MyRow))]
        public SaveResponse Create(IUnitOfWork uow, SaveRequest<MyRow> request)
        {
            return new MyRepository(GetContext()).Create(uow, request);
        }

        [HttpPost, AuthorizeUpdate(typeof(MyRow))]
        public SaveResponse Update(IUnitOfWork uow, SaveRequest<MyRow> request)
        {
            return new MyRepository(GetContext()).Update(uow, request);
        }

        [HttpPost, AuthorizeDelete(typeof(MyRow))]
        public DeleteResponse Delete(IUnitOfWork uow, DeleteRequest request)
        {
            return new MyRepository(GetContext()).Delete(uow, request);
        }

        [HttpPost, AuthorizeDelete(typeof(MyRow))]
        public UndeleteResponse Undelete(IUnitOfWork uow, UndeleteRequest request)
        {
            return new MyRepository(GetContext()).Undelete(uow, request);
        }

        public RetrieveResponse<MyRow> Retrieve(IDbConnection connection, RetrieveRequest request)
        {
            return new MyRepository(GetContext()).Retrieve(connection, request);
        }

        public ListResponse<MyRow> List(IDbConnection connection, ListRequest request)
        {
            return new MyRepository(GetContext()).List(connection, request);
        }

        // tambahan
        public UserController([FromServices] IUserRetrieveService userRetriever) : base(userRetriever) { }
        private IRequestContextMultiTenant GetContext()
        {
            var userDef = User.GetUserDefinition<UserDefinition>(UserRetriever);
            ContextMultiTenant = new RequestContextMultiTenant(Context, Cache, Localizer, Permissions, User, UserRetriever, new MultiTenant(userDef.TenantId));
            return ContextMultiTenant;
        }
    }
}
