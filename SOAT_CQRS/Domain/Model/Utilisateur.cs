﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOAT_CQRS.Domain.Model
{
    public class Utilisateur
    {
        public Guid Id { get; internal set; }

        public Utilisateur()
        {
            this.Id = new Guid();
        }
    }
}
