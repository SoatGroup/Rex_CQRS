using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOAT_CQRS.Domain.Model
{
    public interface IFoyerRepository
    {
        IList<Foyer> GetAll();

        Foyer GetById(Guid id);

        void Add(Foyer foyer);
    }
}
