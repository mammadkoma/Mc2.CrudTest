using Mc2.CrudTest.Presentation.Server.Application.Common.Interfaces;
using Mc2.CrudTest.Shared.Domain;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Presentation.Server.Application.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommand : IRequest<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public ulong BankAccountNumber { get; set; }

        public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, int>
        {
            private IApplicationDbContext context;
            public CreateCustomerCommandHandler(IApplicationDbContext context)
            {
                this.context = context;
            }
            public async Task<int> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
            {
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
}