using SOAT_CQRS.Domain.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOAT_CQRS.Application.Query;
using SOAT_CQRS.Application.Services;
using SOAT_CQRS.Domain.Services;
using SOAT_CQRS.Infrastructure.Repositories;

namespace SOAT_CQRS.UI
{
    public class FoyerviewModel : ViewModelBase
    {
        private FoyerRepository _foyerRepository;

        private IQueryProcessor _queryProcessor;

        public ObservableCollection<Foyer> ListeDeFoyer { get; set; }
        public String NomNouveaufoyer { get; set; }

        /// <summary>
        /// Constructeur
        /// </summary>
        public FoyerviewModel()
        {
            _foyerRepository = new FoyerRepository();
            _queryProcessor = new QueryProcessor();
            ListeDeFoyer = new ObservableCollection<Foyer>();

            //Test
            NomNouveaufoyer = "Test";

            ChargerListeFoyer();
        }

        /////// <summary>
        /////// Méthode classique
        /////// </summary>
        //public void ChargerListeFoyer()
        //{
        //    //vérifications diverses

        //    //récupération des foyers
        //    var foyers = _foyerRepository.GetAll();

        //    //Autres actions

        //    //Affichage
        //    foreach (Foyer foyer in foyers)
        //    {
        //        this.ListeDeFoyer.Add(foyer);
        //    }
        //}


        public void ChargerListeFoyer()
        {
            ChargerListeFoyerQuery chargerFoyerQuerry = new ChargerListeFoyerQuery();
            this.NewTask(() =>
                {
                    ChargerListeFoyerDTO result =
                        _queryProcessor.Process<ChargerListeFoyerQuery, ChargerListeFoyerDTO>(chargerFoyerQuerry);
                    
                    return result;
                },
                (result) =>
                {
                    this.ListeDeFoyer.Clear();                    
                    foreach (var f in result.ListeDeFoyer)
                    {
                        this.ListeDeFoyer.Add(f);
                    }                                        
                },
                (ex) => { throw ex; });
        }


    }

}
