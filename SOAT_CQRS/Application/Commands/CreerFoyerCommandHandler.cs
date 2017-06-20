using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOAT_CQRS.Domain.Model;
using SOAT_CQRS.Domain.Services;

namespace SOAT_CQRS.Application.Commands
{
    public class CreerFoyerCommandHandler : ICommandHandler<CreerFoyerCommand>
    {
        private IFoyerWriteRepository _foyerWriteRepository;

        public CreerFoyerCommandHandler(IFoyerWriteRepository foyerWriteRepository)
        {
            _foyerWriteRepository = foyerWriteRepository;
        }

        public void Handle(CreerFoyerCommand command)
        {
            //Traitement du code métier ( vérification de droit ... )            
            Foyer foyer = new Foyer(command.NomFoyer);
            _foyerWriteRepository.Add(foyer);            
            //Lancement d'event...
        }
    }
}
