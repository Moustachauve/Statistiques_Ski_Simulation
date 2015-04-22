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

		public IEnumerable<Region> GetForSkieur(int userID)
		{
			return Get(includeProperties: "CentreDeSkis", filter: x => x.SkieurID == userID);
		}

		public Region GetForSkieurByID(int id, int userID)
		{
			Region regionTrouve = GetByID(id);
			if (regionTrouve != null && regionTrouve.SkieurID == userID)
				return regionTrouve;

			return null;
		}
	}
}