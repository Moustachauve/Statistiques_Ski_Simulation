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
		public int SortieID { get; set; }

		[Display(Name = "Nombre de descentes")]
		public int NbDescente { get; set; }

		[Display(Name = "Nombre de pied verticaux")]
		public int NbPiedVert { get; set; }

		[DataType(DataType.Date)]
		[Display(Name = "Date de sortie")]
		public DateTime Date { get; set; }


		[Display(Name = "Centre de ski")]
		[ForeignKey("CentreDeSki")]
		public int CentreDeSkiID { get; set; }
		public virtual CentreDeSki CentreDeSki { get; set; }

		/*[Display(Name = "Skieur")]
		[ForeignKey("Skieur")]
		public int SkieurID { get; set; }
		public virtual Skieur Skieur { get; set; }*/

		[Display(Name = "Saison")]
		[ForeignKey("Saison")]
		public int SaisonID { get; set; }
		public virtual Saison Saison { get; set; }
	}
}