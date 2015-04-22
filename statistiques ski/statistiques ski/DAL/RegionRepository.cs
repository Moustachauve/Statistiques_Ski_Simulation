using statistiques_ski.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace statistiques_ski.DAL
{
    public class RegionRepository : Repository<Region>
    {
        public RegionRepository(Statistiques_SkiContext context) : base(context) { }

        public IEnumerable<Region> Get()
        {
            return Get(includeProperties: "CentreDeSkis");
        }
    }
}