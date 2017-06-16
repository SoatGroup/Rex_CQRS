using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOAT_CQRS.Domain.Services
{
    /// <summary>
    /// Interface à implémenter pour effectuer le traitement de <see cref="ICommand"/>.
    /// </summary>
    public interface ICommandProcessor
    {
        /// <summary>
        /// Traite la commande et retourne le résultat de cette commande.
        /// </summary>
        /// <typeparam name="TCommand">Type de la commande.</typeparam>
        /// <typeparam name="TResult">Type du résultat de la commande.</typeparam>
        /// <param name="command">Commande à traiter</param>
        /// <returns>le résultat de la commande.</returns>
        TResult Process<TCommand, TResult>(TCommand command) where TCommand : ICommand<TResult>;

        /// <summary>
        /// Traite la commande.
        /// </summary>
        /// <typeparam name="TCommand">Type de la commande.</typeparam>
        /// <param name="command">Commande à traiter</param>
        /// <returns>le résultat de la commande.</returns>
        void Process<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
