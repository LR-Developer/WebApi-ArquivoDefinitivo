using ArquivoDefinitivo.Common.Domain.Specifications;
using ArquivoDefinitivo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace ArquivoDefinitivo.Domain.Specs
{
    public class AlunoPorNomeSpec : SpecificationBase<Aluno>
    {
        private readonly string _nome;

        public AlunoPorNomeSpec(string nome)
        {
            _nome = nome;
        }

        public override Expression<Func<Aluno, bool>> SpecExpression
        {
            get
            {
                return item => item.Nome == _nome;
            }
        }
    }
}
