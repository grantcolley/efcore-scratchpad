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
    
    public partial class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int CustomerId { get; set; }
        public Nullable<int> Duration { get; set; }
        public int ProductType { get; set; }
        public Nullable<decimal> Rate { get; set; }
        public Nullable<int> RedressId { get; set; }
        public System.DateTime StartDate { get; set; }
        public Nullable<decimal> Value { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual Redress Redress { get; set; }
    }
}