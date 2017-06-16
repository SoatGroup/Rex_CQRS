using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOAT_CQRS.Domain.Services
{
    /// <summary>
    /// Interface d'une requête retournant un résultat.
    /// </summary>
    /// <typeparam name="TResult">Type du résultat de la requête.</typeparam>
    public interface IQuery<out TResult>
    {
    }
}
