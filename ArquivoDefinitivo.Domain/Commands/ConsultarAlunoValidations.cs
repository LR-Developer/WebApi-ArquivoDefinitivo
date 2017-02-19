using ArquivoDefinitivo.Domain.Filters;
using ArquivoDefinitivo.Domain.Validators;
using FluentValidation;

namespace ArquivoDefinitivo.Domain.Commands
{
    public static class ConsultarAlunoValidations
    {
        public static void ValidarFiltro(this ConsultarAlunoFilter filter)
        {
            var validator = new ConsultarAlunoValidator();
            validator.ValidateAndThrow(filter);
        }
    }
}
