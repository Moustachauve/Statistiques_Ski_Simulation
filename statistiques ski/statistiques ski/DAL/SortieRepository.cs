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
			return Get(includeProperties: "CentreDeSki,Saison");
		}

        public IEnumerable<Sortie> GetOrderBy(string orderBy, bool asc)
        {
            Func<IQueryable<Sortie>, IOrderedQueryable<Sortie>> orderLambda = null;

            switch (orderBy)
            {
                case "NbPiedVert":
                    if (asc) 
                        orderLambda = x => x.OrderBy(y => y.NbPiedVert);
                    else
                        orderLambda = x => x.OrderByDescending(y => y.NbPiedVert);
                    break;
                case "NbDescente":
                    if (asc)
                        orderLambda = x => x.OrderBy(y => y.NbDescente);
                    else
                        orderLambda = x => x.OrderByDescending(y => y.NbDescente);
                    break;
                case "Date":
                    if (asc)
                        orderLambda = x => x.OrderBy(y => y.Date);
                    else
                        orderLambda = x => x.OrderByDescending(y => y.Date);
                    break;
       
            }


            return Get(includeProperties: "CentreDeSki,Saison,Skieur", orderBy: orderLambda);
        }

	}
}