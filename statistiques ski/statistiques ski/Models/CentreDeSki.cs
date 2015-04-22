using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace statistiques_ski.Models
{
    public class CentreDeSki
    {

		public int CentreDeSkiID { get; set; }

        [Display(Name="Centre de Ski")]
		[Required]
		public string Nom { get; set; }

		public string Adresse { get; set; }

		[Display(Name="Nombre de pistes")]
		public int NbPistes { get; set; }

		public float Altitude { get; set; }



		[ForeignKey("Region")]
		[Required]
		public int RegionID { get; set; }
		public virtual Region Region { get; set; }

		[ForeignKey("Skieur")]
		[Required]
		public int SkieurID { get; set; }
		public virtual Skieur Skieur { get; set; }

		public virtual ICollection<Sortie> Sorties { get; set; }
    }
}