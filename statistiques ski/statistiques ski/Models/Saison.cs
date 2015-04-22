using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace statistiques_ski.Models
{
    public class Saison
    {
        public int SaisonID { get; set; }

        [Display(Name="Année du début de la saison")]
        public int AnneeDebutSaison { get; set; }

        [Display(Name = "Saison sur deux ans?")]
        public bool SaisonSurDeuxAns { get; set; }

        public virtual ICollection<Sortie> Sorties { get; set; }

        [ForeignKey("Skieur")]
        public int SkieurID { get; set; }
        public virtual Skieur Skieur { get; set; }
    }
}