using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nightpath.Models
{
    public class District
    {
        public int ID { get; set; }
        public string DistrictName { get; set; }

        public virtual ICollection<Region> Region { get; set; }



    }
}