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
    
    public partial class ProjektiMedia
    {
        public int ProjektiMediaID { get; set; }
        public Nullable<int> ProjektiID { get; set; }
        public Nullable<int> MediaID { get; set; }
        public Nullable<bool> Activ { get; set; }
    
        public virtual Medium Medium { get; set; }
        public virtual Projekti Projekti { get; set; }
    }
}
