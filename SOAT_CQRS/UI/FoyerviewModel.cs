using SOAT_CQRS.Domain.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOAT_CQRS.Application.Commands;
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
        private ICommandProcessor _commandProcessor;
        private Utilisateur _utilisateur;

        public ObservableCollection<FoyerListeModel> ListeDeFoyer { get; set; }
        public String NomNouveaufoyer { get; set; }

        public FoyerModelUI FoyerModelUi { get; private set; }
        

        /// <summary>
        /// Constructeur
        /// </summary>
        public FoyerviewModel()
        {
            _foyerRepository = new FoyerRepository();
            _queryProcessor = new QueryProcessor();
            _commandProcessor = new CommandProcessor();
            ListeDeFoyer = new ObservableCollection<FoyerListeModel>();

            this._utilisateur = new Utilisateur();
            //Test
            NomNouveaufoyer = "Test";

            ChargerListeFoyer();
        }

        ///// <summary>
        ///// Méthode classique
        ///// </summary>
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
            ChargerListeFoyerQuery chargerListeFoyerQuerry = new ChargerListeFoyerQuery();
            this.NewTask(() =>
                {
                    ChargerListeFoyerDTO result =
                        _queryProcessor.Process<ChargerListeFoyerQuery, ChargerListeFoyerDTO>(chargerListeFoyerQuerry);
                    
                    return result;
                },
                (result) =>
                {
                    this.ListeDeFoyer.Clear();                    
                    foreach (var f in result.ListeDeFoyer)
                    {
                        this.ListeDeFoyer.Add(new FoyerListeModel() {Id = f.Item1, Nom = f.Item2});
                    }                                        
                },
                (ex) => { throw ex; });
        }


        //public void CreerFoyer()
        //{
        //    if (!String.IsNullOrWhiteSpace(this.NomNouveaufoyer))
        //    {
        //        Foyer foyer = new Foyer(this.NomNouveaufoyer);
        //        _foyerRepository.Add(foyer);
        //        this.ListeDeFoyer.Add(foyer);
        //    }
        //}

        public void CreerFoyer()
        {
            if (!String.IsNullOrWhiteSpace(this.NomNouveaufoyer))
            {
                CreerFoyerCommand creerfoyerCommand = new CreerFoyerCommand() {NomFoyer = this.NomNouveaufoyer};
                this.NewTask(() =>
                {
                    _commandProcessor.Process<CreerFoyerCommand>(creerfoyerCommand);                    
                },
                    () =>
                    {
                        ChargerListeFoyer();
                    },
                    (ex) => { throw ex; });
            }
        }

        public void ChargerFoyer(Foyer FoyerSelectionner)
        {
            {
                ChargerFoyerQuery chargerFoyerQuerry = new ChargerFoyerQuery(FoyerSelectionner.Id, _utilisateur.Id );
                this.NewTask(() =>
                {
                    ChargerFoyerDTO result =
                        _queryProcessor.Process<ChargerFoyerQuery, ChargerFoyerDTO>(chargerFoyerQuerry);

                    return result;
                },
                    (result) =>
                    {
                        this.FoyerModelUi = new FoyerModelUI(result);                                             
                    },
                    (ex) => { throw ex; });
            }
        }
    }

}
