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
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class Projekti
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Projekti()
        {
            this.ProjektiMedias = new HashSet<ProjektiMedia>();
            this.ProjektiUsers = new HashSet<ProjektiUser>();
        }
    
        public int ProjektiID { get; set; }

        [Required(ErrorMessage = "Titulli i Projektit is required")]
        [RegularExpression("^[A-Z]+[a-zA-Z]+[0-9]*$", ErrorMessage = "Titulli i projektit start with capital letter and contains only characters, numbers are optional")]
        public string Titulli { get; set; }

        [Required(ErrorMessage = "Lokacioni i Projektit is required")]
        [RegularExpression("^[A-Z]+[a-zA-Z]+[0-9]*$", ErrorMessage = "Lokacioni i projektit start with capital letter and contains only characters, numbers are optional")]
        public string Lokacioni { get; set; }

        public Nullable<System.DateTime> Viti { get; set; }
        [Required(ErrorMessage = "Madhesia e Projektit is required")]
        public string Madhesia { get; set; }
        public Nullable<int> KategoriaID { get; set; }
        [Required(ErrorMessage = "Statusi i Projektit is required")]
        public string Statusi { get; set; }

        [Required(ErrorMessage = "Pershkrimi i Projektit is required")]
        [RegularExpression("^[A-Z]+[a-zA-Z]+[0-9]*$", ErrorMessage = "Pershrkimi i projektit start with capital letter and contains only characters, numbers are optional")]
        public string Pershkrimi { get; set; }

        public Nullable<System.DateTime> UploadTime { get; set; }
        [DisplayName("User")]
        public Nullable<int> UserID { get; set; }
        public Nullable<bool> Activ { get; set; }
    
        public virtual Kategoria Kategoria { get; set; }
        public virtual Useri Useri { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProjektiMedia> ProjektiMedias { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProjektiUser> ProjektiUsers { get; set; }
    }
}
