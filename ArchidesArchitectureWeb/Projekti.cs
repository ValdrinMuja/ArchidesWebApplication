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
    
    public partial class Projekti
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Projekti()
        {
            this.ProjektiMedias = new HashSet<ProjektiMedia>();
            this.ProjektiUsers = new HashSet<ProjektiUser>();
        }
    
        public int ProjektiID { get; set; }
        public string Titulli { get; set; }
        public string Lokacioni { get; set; }
        public Nullable<System.DateTime> Viti { get; set; }
        public string Madhesia { get; set; }
        public Nullable<int> KategoriaID { get; set; }
        public string Statusi { get; set; }
        public string Pershkrimi { get; set; }
        public Nullable<System.DateTime> UploadTime { get; set; }
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
