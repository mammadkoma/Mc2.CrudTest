using Mc2.CrudTest.Presentation.Server.Application.Common.Interfaces;
using Mc2.CrudTest.Shared.Command;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Presentation.Server.Application.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, int>
    {
        private IApplicationDbContext context;
        public UpdateCustomerCommandHandler(IApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<int> Handle(UpdateCustomerCommand command, CancellationToken cancellationToken)
        {
            var customer = await context.Customers.FirstOrDefaultAsync(c => c.Id == command.Id);
            if (customer == null)
                throw new Exception("This customer does not exists!");

            customer.FirstName = command.FirstName;
            customer.LastName = command.LastName;
            customer.DateOfBirth = command.DateOfBirth;
            customer.PhoneNumber = command.PhoneNumber;
            customer.Email = command.Email;
            customer.BankAccountNumber = command.BankAccountNumber;

            context.Customers.Update(customer);
            await context.SaveChangesAsync(cancellationToken);
            return customer.Id;
        }
    }
}