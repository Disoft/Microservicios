using Customer.Api.Application.Features.Customers.Commands;
using FluentValidation;

namespace Customer.Api.Application.Validators
{
    public class CreateCustomerValidator: AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerValidator()
        {
            RuleFor(x => x.Name).
                NotEmpty().WithMessage("El nombre es obligatorio.");
            RuleFor(x => x.Email).
                NotEmpty().
                EmailAddress().WithMessage("El email no es válido.");
        }
    }
}