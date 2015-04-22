using statistiques_ski.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace statistiques_ski.DAL
{
	public class SortieRepository : Repository<Sortie>
	{
		public SortieRepository(Statistiques_SkiContext context) : base(context) { }

		public IEnumerable<Sortie> Get()
		{
			return Get(includeProperties: "CentreDeSki,Saison,Skieur");
		}

	}
}