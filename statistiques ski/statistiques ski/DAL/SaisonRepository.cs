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

		public IEnumerable<Saison> GetForSkieur(int userID)
		{
			return Get(includeProperties: "Sorties", filter: x => x.SkieurID == userID);
		}

		public Saison GetForSkieurByID(int id, int userID)
		{
			Saison saisonTrouve = GetByID(id);
			if (saisonTrouve != null && saisonTrouve.SkieurID == userID)
				return saisonTrouve;

			return null;
		}
    }
}