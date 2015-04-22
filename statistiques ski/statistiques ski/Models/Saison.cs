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
        public int AnneeDebutSaison { get; set; }
        public bool SaisonSurDeuxAns { get; set; }
        public virtual ICollection<Sortie> Sorties { get; set; }

        [ForeignKey("Skieur")]
        public virtual int SkieurID { get; set; }
        public virtual Skieur Skieur { get; set; }
    }
}