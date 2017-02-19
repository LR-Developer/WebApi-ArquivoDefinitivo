using ArquivoDefinitivo.Common.Domain.Specifications;
using ArquivoDefinitivo.Common.Framework.Helpers;
using System;
using System.Collections.Generic;

namespace ArquivoDefinitivo.Common.Domain.Contracts
{
    public interface IRepositoryReadOnly<TEntity> : IDisposable
            where TEntity : class
    {
        /// <summary>
        /// Obter uma Entidade do Repositório a partir do(s) valor(es) chave(s)
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        TEntity GetById(
                params object[] keys);

        /// <summary>
        /// Obter a primeira Entidade do Repositório
        /// </summary>
        /// <returns></returns>
        TEntity First();

        /// <summary>
        /// Obter a primeira Entidade do Repositório que atenda ao critério estabelecido
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        TEntity First(
            ISpecification<TEntity> predicate);

        /// <summary>
        /// Obter a última Entidade do Repositório
        /// </summary>
        /// <returns></returns>
        TEntity Last();

        /// <summary>
        /// Obter a última Entidade do Repositório que atenda ao critério estabelecido
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        TEntity Last(
            ISpecification<TEntity> predicate);

        /// <summary>
        /// Obter todas as Entidades do Repositório
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> Get();

        /// <summary>
        /// Obter todas as Entidades do Repositório sob determina(s) ordem(ns)
        /// </summary>
        /// <param name="sorts"></param>
        /// <returns></returns>
        IEnumerable<TEntity> Get(
            SortField[] sorts);

        /// <summary>
        /// Obter todas as Entidades do Repositório que atendam ao critério especificado
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IEnumerable<TEntity> Get(
            ISpecification<TEntity> predicate);

        /// <summary>
        /// Obter todas as Entidades do Repositório que atendam ao critério especificado, sob determina(s) ordem(ns)
        /// </summary>
        /// <param name="sorts"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IEnumerable<TEntity> Get(
            SortField[] sorts,
            ISpecification<TEntity> predicate);

        /// <summary>
        /// Obter todas as Entidades do Repositório sob determina(s) ordem(ns), com limitação de paginação
        /// </summary>
        /// <param name="recordCount"></param>
        /// <param name="sorts"></param>
        /// <param name="pageSize"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        IEnumerable<TEntity> Get(
            out int recordCount,
            SortField[] sorts,
            int pageSize = 10,
            int page = 1);

        /// <summary>
        /// Obter todas as Entidades do Repositório que atendam ao critério especificado, sob determina(s) ordem(ns), com limitação de paginação
        /// </summary>
        /// <param name="recordCount"></param>
        /// <param name="sorts"></param>
        /// <param name="predicate"></param>
        /// <param name="pageSize"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        IEnumerable<TEntity> Get(
            out int recordCount,
            SortField[] sorts,
            ISpecification<TEntity> predicate,
            int pageSize = 10,
            int page = 1);

        /// <summary>
        /// Obter quantidade total de Entidades do Repositório
        /// </summary>
        /// <returns></returns>
        int Count();

        /// <summary>
        /// Obter quantidade de Entidades do Repositório que atendam ao critério especificado
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        int Count(
            ISpecification<TEntity> predicate);

        /// <summary>
        /// Verificar se existe ou não Entidades que atendam ao critério especificado
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        bool Exists(
            ISpecification<TEntity> predicate);

        /// <summary>
        /// Verifica se existe uma Entidade no repositório a partir do valor chave
        /// </summary>
        /// <param name="key">Chave que será utilzada na pesquisa</param>
        /// <returns>Retorna True se localizou uma entidade com a chave informada, caso contrário False.</returns>
        bool ExistsById(params object[] keys);
    }
}
