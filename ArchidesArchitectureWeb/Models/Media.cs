using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArchidesArchitectureWeb.Models
{
    public class Media
    {
        public int MediaID { get; set; }
        public string MediaPath { get; set; }

        //foreign Keys
        public int MediaTypeID { get; set; }
        public int LlojiArkitekturaID { get; set; }
        
    }
}