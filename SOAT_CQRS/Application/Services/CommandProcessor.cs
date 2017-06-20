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
    /// Cette classe permet d'effectuer le traitement de <see cref="ICommand"/>.
    /// </summary>
    public sealed class CommandProcessor : ICommandProcessor
    {
        public void Process<TCommand>(TCommand command) where TCommand : ICommand
        {
            ICommandHandler<TCommand> handler = null;

            // Recherche de l'handler associé à la query.                       
            handler = DependencyFactory.Resolve<ICommandHandler<TCommand>>();

            // On lève une erreur si aucun handler a été trouvé.                           
            if (handler == null)
            {
                throw new Exception("Handler non trouvé");
            }

            // On appele le handler et on retourne le résultat de la commande.
            handler.Handle(command);
        }

    }
}
