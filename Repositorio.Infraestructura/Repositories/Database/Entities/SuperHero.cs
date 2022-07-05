﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Infraestructura.Repositories.Database.Entities
{
    public class SuperHero
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string FirstName { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;
        public string Place { get; set; } = String.Empty;
    }
}
