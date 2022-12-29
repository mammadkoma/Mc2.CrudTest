using MediatR;

namespace Mc2.CrudTest.Shared.Command
{
    public record DeleteCustomerCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}