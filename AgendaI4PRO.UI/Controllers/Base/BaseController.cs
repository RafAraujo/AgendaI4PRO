using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace AgendaI4PRO.UI.Controllers.Base
{
    public abstract class BaseController : Controller
    {
        public ValidationResult Validar<T>(AbstractValidator<T> validator, T entidade)
        {
            var resultado = validator.Validate(entidade);
            return resultado;
        }
    }
}
