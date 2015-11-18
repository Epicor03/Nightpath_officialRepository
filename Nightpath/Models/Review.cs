using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nightpath.Models
{
    public class Review
    {
        public int ID { get; set; }
        public string Comment { get; set; }
        public int EventID { get; set; }
        public int ClientID { get; set; }


        public virtual Event Event { get; set; }
        public virtual Client Client { get; set; }






    }
}