//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ArchidesArchitectureWeb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web;

    public partial class Lajmi
    {
        public int LajmiID { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }
        public string FotoPath { get; set; }

        public Nullable<System.DateTime> UploadTime { get; set; }

        [Required(ErrorMessage = "Titulli is required")]
        [RegularExpression("^[A-Z]+[a-zA-Z]+[0-9]*$", ErrorMessage = "Titulli start with capital letter and contains only characters, numbers are optional")]
        public string Titulli { get; set; }

        [Required(ErrorMessage = "Pershkrimi is required")]
        public string Pershkrimi { get; set; }

        public Nullable<bool> Activ { get; set; }
        public Nullable<int> UserID { get; set; }
        public virtual Useri Useri { get; set; }
    }
}
