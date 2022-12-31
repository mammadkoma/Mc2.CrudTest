using Mc2.CrudTest.Presentation.Server.Application.Customers.Commands.CreateCustomer;
using Mc2.CrudTest.Presentation.Server.Application.Customers.Commands.DeleteCustomer;
using Mc2.CrudTest.Presentation.Server.Application.Customers.Commands.UpdateCustomer;
using Mc2.CrudTest.Shared.Command;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Mc2.CrudTest.AcceptanceTests
{
    public class BddTddTests : IClassFixture<AppDbContextFixture>
    {
        public AppDbContextFixture appDbContextFixture { get; }
        public BddTddTests(AppDbContextFixture fixture) => appDbContextFixture = fixture;

        [Fact]
        public async Task CreateCustomer_ReturnsNewCustomerId()
        {
            var command = new CreateCustomerCommand
            {
                FirstName = "Peter",
                LastName = "Schmeichel",
                DateOfBirth = new System.DateTime(1963, 11, 18),
                Email = "peterschmeichel@gmail.com",
                PhoneNumber = "+4512345679",
                BankAccountNumber = 12345678
            };
            using var db = appDbContextFixture.CreateContext();
            var handler = new CreateCustomerCommandHandler(db);
            var result = await handler.Handle(command, new CancellationToken());
            Assert.True(result > 0, "Returned new customer Id must be greater than 0 !");
        }

        [Fact]
        public async Task UpdateCustomer_ReturnsUpdatedCustomerId()
        {
            var command = new UpdateCustomerCommand
            {
                Id = 1,
                FirstName = "Mohammad 2",
                LastName = "Komaei",
                DateOfBirth = new System.DateTime(1986, 07, 28),
                Email = "komaei@live.com",
                PhoneNumber = "+989371448346",
                BankAccountNumber = 987654321
            };
            using var db = appDbContextFixture.CreateContext();
            var handler = new UpdateCustomerCommandHandler(db);
            var result = await handler.Handle(command, new CancellationToken());
            Assert.True(result > 0, "Returned customer Id must be greater than 0 !");
        }

        [Fact]
        public async Task DeleteCustomer_ReturnsDeletedCustomerId()
        {
            var command = new DeleteCustomerCommand
            {
                Id = 1
            };
            using var db = appDbContextFixture.CreateContext();
            var handler = new DeleteCustomerCommandHandler(db);
            var result = await handler.Handle(command, new CancellationToken());
            Assert.True(result > 0, "Returned customer Id must be greater than 0 !");
        }
    }
}