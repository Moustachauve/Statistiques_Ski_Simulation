using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using statistiques_ski.Models;

namespace statistiques_ski.DAL
{
    public class SkieurRepository : Repository<Skieur>
    {

		public SkieurRepository(Statistiques_SkiContext context): base(context)
        {}

		public IEnumerable<Skieur> Get()
		{
			return Get(includeProperties: "Saison,Sortie,Saison,Region,CentreDeSki");
		}
    }
}