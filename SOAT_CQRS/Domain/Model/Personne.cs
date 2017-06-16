using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOAT_CQRS.Domain.Model
{
    public class Personne
    {
        public string Nom { get; set; }

        public string Prenom { get; set; }

        public TypePersonne TypePersonne { get; set; }
    }

    public enum TypePersonne
    {
        ChefDeFamille,
        Conjoin,
        Enfant
    }
}
