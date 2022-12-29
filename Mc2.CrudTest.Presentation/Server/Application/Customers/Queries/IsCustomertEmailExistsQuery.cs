using Mc2.CrudTest.Presentation.Server.Application.Common.Interfaces;
using Mc2.CrudTest.Shared.Query;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Presentation.Server.Application.Customers.Queries
{
    public class IsCustomertEmailExistsQueryHandler : IRequestHandler<IsCustomerEmailExistsQuery, bool>
    {
        private IApplicationDbContext context;
        public IsCustomertEmailExistsQueryHandler(IApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> Handle(IsCustomerEmailExistsQuery query, CancellationToken cancellationToken)
        {
            return await context.Customers.AnyAsync(c => c.Email == query.Email);
        }
    }
}