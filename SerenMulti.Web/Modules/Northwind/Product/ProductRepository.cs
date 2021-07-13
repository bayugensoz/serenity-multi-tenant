﻿using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using static SerenMulti.RequestContextMultiTenant;
using MyRow = SerenMulti.Northwind.Entities.ProductRow;


namespace SerenMulti.Northwind.Repositories
{
    public class ProductRepository : BaseRepositoryMultiTenant
    {
        public ProductRepository(IRequestContextMultiTenant context)
             : base(context)
        {
        }

        private static MyRow.RowFields fld { get { return MyRow.Fields; } }

        public SaveResponse Create(IUnitOfWork uow, SaveRequest<MyRow> request)
        {
            return new MySaveHandler(Context).Process(uow, request, SaveRequestType.Create);
        }

        public SaveResponse Update(IUnitOfWork uow, SaveRequest<MyRow> request)
        {
            return new MySaveHandler(Context).Process(uow, request, SaveRequestType.Update);
        }

        public DeleteResponse Delete(IUnitOfWork uow, DeleteRequest request)
        {
            return new MyDeleteHandler(Context).Process(uow, request);
        }

        public UndeleteResponse Undelete(IUnitOfWork uow, UndeleteRequest request)
        {
            return new MyUndeleteHandler(Context).Process(uow, request);
        }

        public RetrieveResponse<MyRow> Retrieve(IDbConnection connection, RetrieveRequest request)
        {
            return new MyRetrieveHandler(Context).Process(connection, request);
        }

        public ListResponse<MyRow> List(IDbConnection connection, ListRequest request)
        {
            return new MyListHandler(Context).Process(connection, request);
        }

        private class MySaveHandler : SaveRequestHandler<MyRow, SaveRequest<MyRow>, SaveResponse>
        {
            public MySaveHandler(IRequestContext context)
                : base(context)
            {

            }

            protected override void SetInternalFields()
            {
                base.SetInternalFields();

                if (IsCreate)
                {
                    Row.TenantId = UserDef.TenantId;
                }

                if (IsUpdate)
                {

                }
            }
        }

        private class MyDeleteHandler : DeleteRequestHandler<MyRow>
        {
            public MyDeleteHandler(IRequestContext context)
                 : base(context)
            {
            }
        }

        private class MyUndeleteHandler : UndeleteRequestHandler<MyRow>
        {
            public MyUndeleteHandler(IRequestContext context)
                 : base(context)
            {
            }
        }

        private class MyRetrieveHandler : RetrieveRequestHandler<MyRow>
        {
            public MyRetrieveHandler(IRequestContext context)
                 : base(context)
            {
            }
        }

        private class MyListHandler : ListRequestHandler<MyRow>
        {
            public MyListHandler(IRequestContext context)
                 : base(context)
            {
            }

            protected override void ApplyFilters(SqlQuery query)
            {
                base.ApplyFilters(query);
                if (!Permissions.HasPermission(Administration.PermissionKeys.Tenants))
                {
                    query.Where(fld.TenantId == UserDef.TenantId);
                }
            }
        }

    }
}