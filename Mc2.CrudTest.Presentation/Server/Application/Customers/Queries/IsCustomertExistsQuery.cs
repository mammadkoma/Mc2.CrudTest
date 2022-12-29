using Mc2.CrudTest.Presentation.Server.Application.Common.Interfaces;
using Mc2.CrudTest.Shared.Query;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Presentation.Server.Application.Customers.Queries
{
    public class IsCustomertExistsQueryHandler : IRequestHandler<IsCustomerExistsQuery, bool>
    {
        private IApplicationDbContext context;
        public IsCustomertExistsQueryHandler(IApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> Handle(IsCustomerExistsQuery query, CancellationToken cancellationToken)
        {
            return await context.Customers.AnyAsync(c => c.FirstName == query.FirstName
                && c.LastName == query.LastName && c.DateOfBirth == query.DateOfBirth);
        }
    }
}