using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace statistiques_ski.Models
{
    public class Skieur
    {
        [Display(Name = "Skieur")]
		public int SkieurID { get; set; }
		public string Nom { get; set; }
		public string Prenom { get; set; }

		public virtual ICollection<Saison> Saisons { get; set; }
		public virtual ICollection<Sortie> Sorties { get; set; }
		public virtual ICollection<CentreDeSki> CentreDeSkis { get; set; }
		public virtual ICollection<Region> Regions { get; set; }
    }
}