using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOAT_CQRS.Domain.Services;

namespace SOAT_CQRS.Application.Query
{
    class ChargerFoyerQuery : IQuery<ChargerFoyerDTO>
    {
        public Guid FoyerId { get; set; }

        public Guid UserId { get; set; }

        public ChargerFoyerQuery(Guid userId, Guid foyerId)
        {
            
        }
    }
}
