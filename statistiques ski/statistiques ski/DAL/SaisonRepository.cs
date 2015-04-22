using statistiques_ski.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace statistiques_ski.DAL
{
    public class SaisonRepository : Repository<Saison>
    {
        public SaisonRepository(Statistiques_SkiContext context) : base(context) { }

        public IEnumerable<Saison> Get()
        {
            return Get(includeProperties: "Sorties");
        }
    }
}