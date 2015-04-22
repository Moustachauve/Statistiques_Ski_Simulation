﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace statistiques_ski.Models
{
    public class CentreDeSki
    {

		public int CentreDeSkiID { get; set; }

		public string Nom { get; set; }

		public string Adresse { get; set; }

		public int NbPistes { get; set; }

		public float Altitude { get; set; }



		[ForeignKey("Region")]
		public int RegionID { get; set; }
		public virtual Region Region { get; set; }

		public virtual ICollection<Sortie> Sorties { get; set; }
    }
}