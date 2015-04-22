using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace statistiques_ski.Models
{
    public class Skieur
    {
		public int SkieurID { get; set; }
		public string Nom { get; set; }
		public string Prenom { get; set; }

		public virtual ICollection<Saison> Saisons { get; set; }
		public virtual ICollection<Sortie> Sorties { get; set; }
		public virtual ICollection<CentreDeSki> CentreDeSkis { get; set; }
		public virtual ICollection<Region> Regions { get; set; }
    }
}