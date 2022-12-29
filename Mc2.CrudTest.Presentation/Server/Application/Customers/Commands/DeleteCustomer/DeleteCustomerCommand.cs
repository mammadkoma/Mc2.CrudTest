using Mc2.CrudTest.Presentation.Server.Application.Common.Interfaces;
using Mc2.CrudTest.Shared.Command;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Presentation.Server.Application.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, int>
    {
        private IApplicationDbContext context;
        public DeleteCustomerCommandHandler(IApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<int> Handle(DeleteCustomerCommand command, CancellationToken cancellationToken)
        {
            var customer = await context.Customers.FirstOrDefaultAsync(c => c.Id == command.Id);
            if (customer == null)
                throw new Exception("This customer does not exists!");

            context.Customers.Remove(customer);
            await context.SaveChangesAsync(cancellationToken);
            return customer.Id;
        }
    }
}