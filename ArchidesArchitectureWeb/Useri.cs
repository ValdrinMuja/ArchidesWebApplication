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

    public partial class Useri
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Useri()
        {
            this.Projektis = new HashSet<Projekti>();
            this.ProjektiUsers = new HashSet<ProjektiUser>();
            this.Lajmis = new HashSet<Lajmi>();
        }
        [DisplayName("Admin")]
        public int UserID { get; set; }
        [Required(ErrorMessage = "Emri is required ")]
        public string Emri { get; set; }
        [Required(ErrorMessage = "Mbiemri is required ")]
        public string Mbiemri { get; set; }
        [Required(ErrorMessage = "Gjinia is required ")]
        public string Gjinia { get; set; }
        [Required(ErrorMessage = "Vendlindja is required ")]
        public string Vendlindja { get; set; }
        [Required(ErrorMessage = "Datelindja is required ")]
        public Nullable<System.DateTime> Datelindja { get; set; }
        [Required(ErrorMessage = "Email is required ")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Telefoni is required")]
        public string Telefoni { get; set; }
        [Required(ErrorMessage = "Username is required ")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is required ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Pershkrimi { get; set; }
        public string Shkollimi { get; set; }
        public string PergaditjaProfesionale { get; set; }
        [Required(ErrorMessage = "Foto is required ")]
        public string Foto { get; set; }  
        //Kjo property nuk u kriju me entity
        public string LoginErrorMessage { get; set; }
        public Nullable<int> RoliID { get; set; }
        public Nullable<bool> Activ { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Projekti> Projektis { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProjektiUser> ProjektiUsers { get; set; }
        public virtual Roli Roli { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Lajmi> Lajmis { get; set; }
    }
}
