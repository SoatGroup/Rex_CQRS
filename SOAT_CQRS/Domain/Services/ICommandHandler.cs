using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOAT_CQRS.Domain.Services
{
    /// <summary>
    /// Interface devant être implémenter pour le traitement d'une commande retournant un résultat.
    /// </summary>
    /// <typeparam name="TCommand">Type de la requête.</typeparam>
    /// <typeparam name="TResult">Type du résultat de la requête.</typeparam>
    public interface ICommandHandler<in TCommand, out TResult>
        where TCommand : ICommand<TResult>
    {
        /// <summary>
        /// Traite la commande <paramref name="command"/> passée en paramètre.
        /// </summary>
        /// <param name="command">Commande à traiter.</param>
        /// <returns>le résultat du traitement de la commande.</returns>
        TResult Handle(TCommand command);
    }

    /// <summary>
    /// Interface devant être implémenter pour le traitement d'une commande.
    /// </summary>
    /// <typeparam name="TCommand">Type de la commande.</typeparam>
    public interface ICommandHandler<in TCommand>
        where TCommand : ICommand
    {
        /// <summary>
        /// Traite la commande <paramref name="command"/> passée en paramètre.
        /// </summary>
        /// <param name="command">Commande à traiter.</param>
        void Handle(TCommand command);
    }
}
