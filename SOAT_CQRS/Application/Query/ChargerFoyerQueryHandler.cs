using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOAT_CQRS.Domain.Model;
using SOAT_CQRS.Domain.Services;
using SOAT_CQRS.Infrastructure;

namespace SOAT_CQRS.Application.Query
{
    class ChargerFoyerQueryHandler : IQueryHandler<ChargerFoyerQuery, ChargerFoyerDTO>
    {

        #region Propriete

        private IFoyerRepository _foyerRepository;

        #endregion

        #region Constructeur
        public ChargerFoyerQueryHandler(IFoyerRepository foyerRepository)
        {
            _foyerRepository = foyerRepository;
        }
        #endregion

        public ChargerFoyerDTO Handle(ChargerFoyerQuery query)
        {
            ChargerFoyerDTO result = new ChargerFoyerDTO();

            result.Foyer = _foyerRepository.GetById(query.FoyerId);
                        
            return result;
        }
    }
}
