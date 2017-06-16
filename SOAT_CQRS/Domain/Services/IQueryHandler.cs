using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOAT_CQRS.Domain.Services
{
    /// <summary>
    /// Interface devant être implémenter pour le traitement d'une requête.
    /// </summary>
    /// <typeparam name="TQuery">Type de la requête.</typeparam>
    /// <typeparam name="TResult">Type du résultat de la requête.</typeparam>
    public interface IQueryHandler<in TQuery, out TResult>
        where TQuery : IQuery<TResult>
    {
        /// <summary>
        /// Traite la requête <paramref name="query"/> passée en paramètre.
        /// </summary>
        /// <param name="query">Requête à traiter.</param>
        /// <returns>le résultat du traitement de la requête.</returns>
        TResult Handle(TQuery query);
    }
}
