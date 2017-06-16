using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOAT_CQRS.Domain.Services;
using SOAT_CQRS.Infrastructure;

namespace SOAT_CQRS.Application.Services
{

    /// <summary>
    /// Interface à implémenter pour effectuer le traitement de <see cref="IQuery{TResult}"/>.
    /// </summary>
    public sealed class QueryProcessor : IQueryProcessor
    {        

        #region IQueryProcessor Membres
        /// <summary>
        /// Traite la requête et retourne le résultat de cette requête.
        /// </summary>
        /// <typeparam name="TQuery">Type de la requête.</typeparam>
        /// <typeparam name="TResult">Type du résultat de la requête.</typeparam>
        /// <param name="query">Requête à traiter</param>
        /// <returns>le résultat de la requête.</returns>
        //[DebuggerStepThrough]
        public TResult Process<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>
        {
            IQueryHandler<TQuery, TResult> handler = null;            

            // Recherche de l'handler associé à la query.                       
            handler = DependencyFactory.Resolve<IQueryHandler<TQuery, TResult>>();

            // On lève une erreur si aucun handler a été trouvé.                           
            if (handler == null)
            {
                throw new Exception("Handler non trouvé");
            }

            // On appele le handler et on retourne le résultat de la commande.
            return handler.Handle(query);
        }
        #endregion
    }

}
