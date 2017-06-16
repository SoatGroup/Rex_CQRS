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
        private IFoyerRepository _foyerRepository;
        #endregion

        #region Constructeur
        public ChargerListeFoyerQueryHandler(IFoyerRepository foyerRepository)
        {
            _foyerRepository = foyerRepository;
        }
        #endregion

        public ChargerListeFoyerDTO Handle(ChargerListeFoyerQuery query)
        {
            ChargerListeFoyerDTO result = new ChargerListeFoyerDTO();
            result.ListeDeFoyer = _foyerRepository.GetAll();
            return result;
        }
    }
}
