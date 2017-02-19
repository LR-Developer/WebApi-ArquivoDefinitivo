using System;
using System.Linq.Expressions;
using ArquivoDefinitivo.Common.Domain.Specifications;
using ArquivoDefinitivo.Domain.Entities;

namespace ArquivoDefinitivo.Domain.Specs
{
    public class AlunoPorRgSpec : SpecificationBase<Aluno>
    {
        private readonly string _rg;

        public AlunoPorRgSpec(string rg)
        {
            _rg = rg;
        }

        public override Expression<Func<Aluno, bool>> SpecExpression
        {
            get
            {
                return item => item.Rg == _rg;
            }
        }
    }
}
