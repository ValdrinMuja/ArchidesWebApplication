using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArchidesArchitectureWeb.Models
{
    public class ProjektiMedia
    {
        public int ProjektMediaID { get; set; }

        //foreign keys
        public int ProjektiID { get; set; }
        public int MediaID { get; set; }
    }
}