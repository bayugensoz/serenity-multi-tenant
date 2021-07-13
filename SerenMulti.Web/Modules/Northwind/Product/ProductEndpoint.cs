using Microsoft.AspNetCore.Mvc;
using Serenity;
using Serenity.Abstractions;
using Serenity.Data;
using Serenity.Reporting;
using Serenity.Services;
using Serenity.Web;
using System;
using System.Data;
using static SerenMulti.RequestContextMultiTenant;
using MyRepository = SerenMulti.Northwind.Repositories.ProductRepository;
using MyRow = SerenMulti.Northwind.Entities.ProductRow;

namespace SerenMulti.Northwind.Endpoints
{
    [Route("Services/Northwind/Product/[action]")]
    [ConnectionKey(typeof(MyRow)), ServiceAuthorize(typeof(MyRow))]
    public class ProductController : ServiceEndpointMultiTenant
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

        public RetrieveResponse<MyRow> Retrieve(IDbConnection connection, RetrieveRequest request)
        {
            return new MyRepository(GetContext()).Retrieve(connection, request);
        }

        public ListResponse<MyRow> List(IDbConnection connection, ListRequest request)
        {
            return new MyRepository(GetContext()).List(connection, request);
        }

        public FileContentResult ListExcel(IDbConnection connection, ListRequest request)
        {
            var data = List(connection, request).Entities;
            var report = new DynamicDataReport(data, request.IncludeColumns, typeof(Columns.ProductColumns), HttpContext.RequestServices);
            var bytes = ReportRepository.Render(report);
            return ExcelContentResult.Create(bytes, "ProductList_" +
                DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx");
        }

        // tambahan
        public ProductController([FromServices] IUserRetrieveService userRetriever) : base(userRetriever) { }
        private IRequestContextMultiTenant GetContext()
        {
            var userDef = User.GetUserDefinition<UserDefinition>(UserRetriever);
            ContextMultiTenant = new RequestContextMultiTenant(Context, Cache, Localizer, Permissions, User, UserRetriever, new MultiTenant(userDef.TenantId));
            return ContextMultiTenant;
        }
    }
}