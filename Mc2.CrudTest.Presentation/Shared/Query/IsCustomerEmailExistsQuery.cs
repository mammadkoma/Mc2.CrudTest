using MediatR;

namespace Mc2.CrudTest.Shared.Query
{
    public record IsCustomerEmailExistsQuery : IRequest<bool>
    {
        public string Email { get; set; }
    }
}