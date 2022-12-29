using Mc2.CrudTest.Presentation.Server.Application.Customers.Commands.CreateCustomer;
using Mc2.CrudTest.Presentation.Server.Application.Customers.Queries.GetCustomers;
using Mc2.CrudTest.Shared.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Presentation.Server.Controllers
{
    public class CustomersController : ApiControllerBase
    {
        [HttpGet]
        public async Task<List<Customer>> GetAll()
        {
            return await Mediator.Send(new GetAllCustomerQuery());
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateCustomerCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}