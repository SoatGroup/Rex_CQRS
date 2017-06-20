using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOAT_CQRS.Domain.Model
{
    public class Foyer
    {
        public Guid Id { get; internal set; }
        
        //Renvoie le nom du chef de famille
        public string Nom { get; set; }
        
        public IList<Personne> PersonnesFoyer { get; set; }

        /// <summary>
        /// constructeur de foyé
        /// </summary>
        /// <param name="chefDeFamille"></param>
        public Foyer(Personne chefDeFamille)
        {
            this.Id = new Guid();
            PersonnesFoyer = new List<Personne>();
            this.PersonnesFoyer.Add(chefDeFamille);
        }

        public Foyer(String nomfoyer)
        {
            this.Nom = nomfoyer;
        }

    }
}
