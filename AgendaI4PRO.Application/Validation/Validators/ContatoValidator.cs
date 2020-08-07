using AgendaI4PRO.Domain.Models;
using FluentValidation;

namespace AgendaI4PRO.Application.Validation.Validators
{
    public class ContatoValidator : AbstractValidator<Contato>
    {
        public ContatoValidator()
        {
            RuleFor(c => c.Nome).NotNull().NotEmpty();

            RuleFor(c => c.Emails).ForEach(e => e.SetValidator(new EmailValidator()));

            RuleFor(c => c.Telefones).ForEach(t => t.SetValidator(new TelefoneValidator()));
        }
    }
}
