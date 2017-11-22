using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArchidesArchitectureWeb.Models
{
    public class User
    {   
        public int UserID { get; set; }
        public string Emri { get; set; }
        public string Mbiemri { get; set; }
        public string Gjinia { get; set; }
        public string Vendlindja { get; set; }
        public DateTime Datelindja { get; set; }
        public string Email { get; set; }
        public string Telefoni { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PershkrimiPerUser { get; set; }
        public string Shkollimi { get; set; }
        public string PergaditjaProfesionale { get; set; }
        public string FotoPath { get; set; }
        public bool Aktiv { get; set; }


        //foreign key
        public int RoliID { get; set; }
    }
}