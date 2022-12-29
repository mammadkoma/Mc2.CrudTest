using Mc2.CrudTest.Presentation.Server.Application.Customers.Queries;
using Mc2.CrudTest.Shared.Command;
using Mc2.CrudTest.Shared.Domain;
using Mc2.CrudTest.Shared.Query;
using Microsoft.AspNetCore.Mvc;
using System;
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
            var isCustomertExistsQuery = new IsCustomertExistsQuery
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                DateOfBirth = command.DateOfBirth,
            };
            if (await Mediator.Send(isCustomertExistsQuery))
                throw new Exception("This customer is registered before.");

            return await Mediator.Send(command);
        }
    }
}