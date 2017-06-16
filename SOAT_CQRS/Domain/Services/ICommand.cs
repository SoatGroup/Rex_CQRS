using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOAT_CQRS.Domain.Services
{

    /// <summary>
    /// Interface d'une commande retournant un résultat.
    /// </summary>
    /// <typeparam name="TResult">Type du résultat de la commande.</typeparam>
    public interface ICommand<out TResult> : ICommand
    {
    }

    /// <summary>
    /// Interface d'une commande.
    /// </summary>
    public interface ICommand
    {
    }
}
