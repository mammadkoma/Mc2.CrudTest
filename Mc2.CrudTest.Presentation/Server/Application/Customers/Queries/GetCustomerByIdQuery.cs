using Mc2.CrudTest.Presentation.Server.Application.Common.Interfaces;
using Mc2.CrudTest.Shared.Domain;
using Mc2.CrudTest.Shared.Query;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Presentation.Server.Application.Customers.Queries
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, Customer>
    {
        private IApplicationDbContext context;
        public GetCustomerByIdQueryHandler(IApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<Customer> Handle(GetCustomerByIdQuery query, CancellationToken cancellationToken)
        {
            return await context.Customers.Where(a => a.Id == query.Id).FirstOrDefaultAsync();
        }
    }
}