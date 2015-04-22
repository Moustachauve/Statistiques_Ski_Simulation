using System;
using System.Collections.Generic;
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
    }
}