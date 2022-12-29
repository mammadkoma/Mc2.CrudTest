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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetCustomerByIdQuery { Id = id }));
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateCustomerCommand command)
        {
            var isCustomertExistsQuery = new IsCustomerExistsQuery
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                DateOfBirth = command.DateOfBirth,
            };
            if (await Mediator.Send(isCustomertExistsQuery))
                throw new Exception("This customer is registered before.");

            var isCustomertEmailExistsQuery = new IsCustomerEmailExistsQuery { Email = command.Email };
            if (await Mediator.Send(isCustomertEmailExistsQuery))
                throw new Exception("This Email is registered before.");

            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateCustomerCommand command)
        {
            command.Id = id;
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteCustomerCommand { Id = id }));
        }
    }
}