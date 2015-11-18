using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nightpath.Models
{
    public class Region
    {
        public int ID { get; set; }
        public string RegionName { get; set; }
        public int DistrictID { get; set; }

        public virtual District District { get; set; }

        public virtual ICollection<Establishment> Establishments { get; set; }


    }
}