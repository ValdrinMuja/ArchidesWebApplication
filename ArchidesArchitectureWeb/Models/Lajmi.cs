using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArchidesArchitectureWeb.Models
{
    public class Lajmi
    {
        public int LajmiID { get; set; }
        public string FotoPath { get; set; }
        public DateTime UploadTime { get; set; }
        public string Titulli { get; set; }
        public string Pershkrimi { get; set; }

        //foreign key
        public int UserID { get; set; }
    }
}