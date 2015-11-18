using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nightpath.Models
{
    public class Estab_Owner
    {
        public int ID { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Establishment> Establishment { get; set; }


    }

}