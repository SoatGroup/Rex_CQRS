using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOAT_CQRS.Domain.Model;

namespace SOAT_CQRS.Infrastructure.Repositories
{
    /// <summary>
    /// Fake Repository
    /// </summary>
    /// <remarks>Le repository n'as pas d'importance ici. Ses méthodes sont donc simplifié</remarks>
    public class FoyerRepository : IFoyerRepository
    {
        private static IList<Foyer> _tempListFoyer;

        public void Add(Foyer foyer)
        {
            _tempListFoyer.Add(foyer);
        }

        public IList<Foyer> GetAll()
        {
            
            return _tempListFoyer;
        }

        public Foyer GetById(Guid id)
        {
            return _tempListFoyer.SingleOrDefault(f => f.Id == id);
        }


        static FoyerRepository()
        {
            _tempListFoyer = new List<Foyer>();
            PoulateBase(); //Faux remplissage de base
        }

        private static void PoulateBase()
        {
            Personne chefFoyer1 = new Personne()
            {
                Nom = "Nom Foyer1",
                Prenom = "Prénom chef Foyer1",
                TypePersonne = TypePersonne.ChefDeFamille
            };
            Foyer foyer1 = new Foyer(chefFoyer1);
            foyer1.Nom = "Foyer1";
            _tempListFoyer.Add(foyer1);
            
        }
    }
}
