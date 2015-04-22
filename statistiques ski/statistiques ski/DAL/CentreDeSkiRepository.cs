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

		public IEnumerable<CentreDeSki> GetForUser(int userID)
		{
			return Get(includeProperties: "Region,Sorties", filter: x => x.Region.SkieurID == userID);
		}

		public CentreDeSki GetForUserByID(int id, int userID)
		{
			CentreDeSki centreTrouve = GetByID(id);
			if (centreTrouve != null && centreTrouve.Region.SkieurID == userID)
				return centreTrouve;

			return null;
		}
    }
}