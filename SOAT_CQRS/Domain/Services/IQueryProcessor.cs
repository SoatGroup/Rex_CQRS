using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOAT_CQRS.Domain.Services
{
    /// <summary>
    /// Interface à implémenter pour effectuer le traitement de <see cref="IQuery{TResult}"/>.
    /// </summary>
    public interface IQueryProcessor
    {
        /// <summary>
        /// Traite la requête et retourne le résultat de cette requête.
        /// </summary>
        /// <typeparam name="TQuery">Type de la requête.</typeparam>
        /// <typeparam name="TResult">Type du résultat de la requête.</typeparam>
        /// <param name="query">Requête à traiter</param>
        /// <returns>le résultat de la requête.</returns>
        TResult Process<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>;
    }
}
