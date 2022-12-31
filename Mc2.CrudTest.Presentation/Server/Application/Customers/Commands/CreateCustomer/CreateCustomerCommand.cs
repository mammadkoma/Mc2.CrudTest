using Mc2.CrudTest.Presentation.Server.Application.Common.Interfaces;
using Mc2.CrudTest.Presentation.Server.Application.Customers.Queries;
using Mc2.CrudTest.Shared.Command;
using Mc2.CrudTest.Shared.Domain;
using Mc2.CrudTest.Shared.Query;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Presentation.Server.Application.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, int>
    {
        private IApplicationDbContext context;
        public CreateCustomerCommandHandler(IApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<int> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
        {
            var isCustomertExistsQuery = new IsCustomerExistsQuery
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                DateOfBirth = command.DateOfBirth,
            };
            var isCustomertExistsQueryHandler = new IsCustomertExistsQueryHandler(context);
            if (await isCustomertExistsQueryHandler.Handle(isCustomertExistsQuery, new CancellationToken()))
                throw new Exception("This customer is registered before.");

            var isCustomertEmailExistsQuery = new IsCustomerEmailExistsQuery
            {
                Email = command.Email
            };
            var isCustomertEmailExistsQueryHandler = new IsCustomertEmailExistsQueryHandler(context);
            if (await isCustomertEmailExistsQueryHandler.Handle(isCustomertEmailExistsQuery, new CancellationToken()))
                throw new Exception("This Email is registered before.");

            var newCustomer = new Customer
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                DateOfBirth = command.DateOfBirth,
                PhoneNumber = command.PhoneNumber,
                Email = command.Email,
                BankAccountNumber = command.BankAccountNumber,
            };

            context.Customers.Add(newCustomer);
            await context.SaveChangesAsync(cancellationToken);
            return newCustomer.Id;
        }
    }
}