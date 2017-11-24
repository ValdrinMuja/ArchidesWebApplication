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
    
    public partial class Useri
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Useri()
        {
            this.Projektis = new HashSet<Projekti>();
            this.ProjektiUsers = new HashSet<ProjektiUser>();
        }
    
        public int UserID { get; set; }
        public string Emri { get; set; }
        public string Mbiemri { get; set; }
        public string Gjinia { get; set; }
        public string Vendlindja { get; set; }
        public Nullable<System.DateTime> Datelindja { get; set; }
        public string Email { get; set; }
        public string Telefoni { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Pershkrimi { get; set; }
        public string Shkollimi { get; set; }
        public string PergaditjaProfesionale { get; set; }
        public string Foto { get; set; }
        public Nullable<int> RoliID { get; set; }
        public Nullable<bool> Activ { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Projekti> Projektis { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProjektiUser> ProjektiUsers { get; set; }
        public virtual Roli Roli { get; set; }
    }
}
