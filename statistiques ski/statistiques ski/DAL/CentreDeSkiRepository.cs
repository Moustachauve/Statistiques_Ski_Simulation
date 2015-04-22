using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using statistiques_ski.Models;

namespace statistiques_ski.DAL
{
    public class CentreDeSkiRepository : Repository<CentreDeSki>
    {
		public CentreDeSkiRepository(Statistiques_SkiContext context) : base(context)
        {}

		public IEnumerable<CentreDeSki> Get()
		{
			return Get(includeProperties: "Region,Sorties");
		}
    }
}