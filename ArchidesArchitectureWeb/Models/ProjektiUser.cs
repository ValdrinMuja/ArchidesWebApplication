using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArchidesArchitectureWeb.Models
{
    public class ProjektiUser
    {
        public int ProjektiUserID { get; set; }

        //foreign keys
        public int ProjektiID { get; set; }
        public int UserID { get; set; }
    }
}