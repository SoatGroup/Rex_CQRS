using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOAT_CQRS.Domain.Model;
using SOAT_CQRS.Domain.Services;

namespace SOAT_CQRS.Application.Query
{
    public class ChargerListeFoyerQueryHandler : IQueryHandler<ChargerListeFoyerQuery, ChargerListeFoyerDTO>
    {
        #region Propriete
        private IFoyerReadRepository _foyerRepository;
        #endregion

        #region Constructeur
        public ChargerListeFoyerQueryHandler(IFoyerReadRepository foyerRepository)
        {
            _foyerRepository = foyerRepository;
        }
        #endregion

        public ChargerListeFoyerDTO Handle(ChargerListeFoyerQuery query)
        {
            ChargerListeFoyerDTO result = new ChargerListeFoyerDTO();
            var foyers = _foyerRepository.GetAll()
                .Select(f => new Tuple<Guid, string>(f.Id, f.Nom))
                .ToList();
            result.ListeDeFoyer = foyers;            
            return result;
        }
    }
}
