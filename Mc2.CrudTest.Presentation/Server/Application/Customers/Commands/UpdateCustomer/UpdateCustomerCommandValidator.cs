using FluentValidation;
using Mc2.CrudTest.Presentation.Server.Application.Common.Interfaces;
using Mc2.CrudTest.Shared.Command;

namespace Mc2.CrudTest.Presentation.Server.Application.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
    {
        private readonly IStringService _stringService;

        public UpdateCustomerCommandValidator(IStringService stringService)
        {
            _stringService = stringService;

            RuleFor(c => c.FirstName).MaximumLength(50).NotNull().NotEmpty();
            RuleFor(c => c.PhoneNumber).NotNull().NotEmpty()
                .Must(_stringService.IsValidPhoneNumber)
                .WithMessage("Enter a valid US Phone number!");
        }
    }
}