//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EFCoreScratchPad.DataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class Project
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Project()
        {
            this.Redresses = new HashSet<Redress>();
        }
    
        public int ProjectId { get; set; }
        public int ProductType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<decimal> Compensation { get; set; }
        public Nullable<decimal> CompensatoryInterest { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Redress> Redresses { get; set; }
    }
}
