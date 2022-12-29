using Mc2.CrudTest.Presentation.Server.Application.Common.Interfaces;
using Mc2.CrudTest.Shared.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Presentation.Server.Application.Customers.Queries
{
    public class GetAllCustomerQuery : IRequest<List<Customer>>
    {
        public class GetAllCustomerQueryHandler : IRequestHandler<GetAllCustomerQuery, List<Customer>>
        {
            private IApplicationDbContext context;
            public GetAllCustomerQueryHandler(IApplicationDbContext context)
            {
                this.context = context;
            }
            public async Task<List<Customer>> Handle(GetAllCustomerQuery query, CancellationToken cancellationToken)
            {
                var CustomerList = await context.Customers.ToListAsync();
                return CustomerList;
            }
        }
    }
}