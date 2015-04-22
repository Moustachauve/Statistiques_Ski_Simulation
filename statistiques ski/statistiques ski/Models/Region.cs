using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace statistiques_ski.Models
{
    public class Region
    {
        public int RegionID { get; set; }
        public string NomRegion { get; set; }
        public virtual ICollection<CentreDeSki> CentreDeSkis { get; set; }
    }
}