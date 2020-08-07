using AgendaI4PRO.Domain.Models;
using FluentValidation;

namespace AgendaI4PRO.Application.Validation.Validators
{
    public class TelefoneValidator : AbstractValidator<Telefone>
    {
        public TelefoneValidator()
        {
            RuleFor(t => t.Numero).Length(8);
        }
    }
}
