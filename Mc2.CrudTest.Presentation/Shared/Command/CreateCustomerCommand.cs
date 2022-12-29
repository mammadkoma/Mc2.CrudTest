using MediatR;
using System;

namespace Mc2.CrudTest.Shared.Command
{
    public record CreateCustomerCommand : IRequest<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public ulong BankAccountNumber { get; set; }
    }
}
