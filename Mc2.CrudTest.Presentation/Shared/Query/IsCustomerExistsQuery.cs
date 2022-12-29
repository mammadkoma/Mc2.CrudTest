using MediatR;
using System;

namespace Mc2.CrudTest.Shared.Query
{
    public record IsCustomerExistsQuery : IRequest<bool>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}