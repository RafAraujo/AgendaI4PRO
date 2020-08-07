using AgendaI4PRO.Domain.Models;
using FluentValidation;

namespace AgendaI4PRO.Application.Validation.Validators
{
    public class EmailValidator : AbstractValidator<Email>
    {
        public EmailValidator()
        {
            RuleFor(e => e.Endereco).EmailAddress();
        }
    }
}
