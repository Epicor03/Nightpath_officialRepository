using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nightpath.Models
{
    public class Event
    {

        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }
        public int EstablishmentID { get; set; }

        public virtual Establishment Establishment { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}