using Mc2.CrudTest.Shared.Domain;
using MediatR;

namespace Mc2.CrudTest.Shared.Query
{
    public record GetCustomerByIdQuery : IRequest<Customer>
    {
        public int Id { get; set; }
    }
}
