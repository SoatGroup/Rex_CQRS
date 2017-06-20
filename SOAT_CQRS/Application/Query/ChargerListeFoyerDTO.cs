using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOAT_CQRS.Domain.Model;

namespace SOAT_CQRS.Application.Query
{
    public class ChargerListeFoyerDTO
    {
        public IList<Tuple<Guid,String>> ListeDeFoyer { get; set; }

        public ChargerListeFoyerDTO()
        {
            ListeDeFoyer = new List<Tuple<Guid, string>>();
        }
    }
}
