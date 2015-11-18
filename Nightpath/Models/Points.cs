using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nightpath.Models
{
    public class Points
    {
        public int ID { get; set; }
        public int EstablishmentID { get; set; }
        public int ClientID { get; set; }
        public int PointsNumber { get; set; }

        public virtual Establishment Establishment { get; set; }
        public virtual Client Client { get; set; }

    }
}