using ArquivoDefinitivo.Common.Domain.Specifications;
using ArquivoDefinitivo.Domain.Entities;
using ArquivoDefinitivo.Domain.Specs;

namespace ArquivoDefinitivo.Domain.Filters
{
    public class ConsultarAlunoFilter
    {
        public string Nome { get; set; }

        public string Rg { get; set; }
    }

    public static class ConsultarAlunoFilterExtensions
    {
        public static ISpecification<Aluno> CriarSpecification(this ConsultarAlunoFilter filter)
        {
            if (filter == null)
            {
                return null;
            }

            ISpecification<Aluno> criterio = null;
            if (!string.IsNullOrEmpty(filter.Nome))
            {
                criterio = criterio.And(new AlunoPorNomeSpec(filter.Nome));
            }

            if (!string.IsNullOrEmpty(filter.Rg))
            {
                criterio = criterio.And(new AlunoPorRgSpec(filter.Rg));
            }

            return criterio;
        }
    }
}
