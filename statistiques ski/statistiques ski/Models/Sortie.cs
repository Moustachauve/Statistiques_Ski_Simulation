using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace statistiques_ski.Models
{
	public class Sortie
	{
		public int sortieID { get; set; }

		[Display(Name="Nombre de descente")]
		public int nbDescente { get; set; }

		[Display(Name = "Nombre de pied verticaux")]
		public int nbPiedVert { get; set; }

		[DataType(DataType.Date)]
		[Display(Name = "Date de sortie")]
		public DateTime date { get; set; }

		[ForeignKey("CentreDeSki")]
		public int centreDeSkiID { get; set; }
		public virtual CentreDeSki centreDeSki { get; set; }

		[ForeignKey("Skieur")]
		public int skieurID { get; set; }
		public virtual Skieur skieur { get; set; }

		[ForeignKey("Saison")]
		public int saisonID { get; set; }
		public virtual Saison saison { get; set; }
	}
}