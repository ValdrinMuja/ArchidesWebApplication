using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArchidesArchitectureWeb.Models
{
    public class Projekti
    {
        public int ProjektiID { get; set; }
        public string TitulliProjektit { get; set; }
        public string Lokacioni { get; set; }
        public DateTime Viti { get; set; }
        public string Madhesia { get; set; }
        public string Statusi { get; set; }
        public string Pershkrimi { get; set; }
        public DateTime UploadTime { get; set; }
        public bool Aktiv { get; set; }

        //foreign Keys
        public int KategoriaID { get; set; }
        public int UserID { get; set; }

    }
}