using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nightpath.Models
{
    public class Client
    {
        public int ID { get; set; }


        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Points> Points { get; set; }
    }
}