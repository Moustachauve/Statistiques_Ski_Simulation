using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace statistiques_ski.Models
{
    public class Region
    {
        public int RegionID { get; set; }

        [Display(Name = "Nom de la région")]
        public string NomRegion { get; set; }

        public virtual ICollection<CentreDeSki> CentreDeSkis { get; set; }

        [ForeignKey("Skieur")]
        public int SkieurID { get; set; }
        public virtual Skieur Skieur { get; set; }
    }
}