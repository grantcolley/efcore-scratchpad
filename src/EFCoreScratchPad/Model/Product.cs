using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreScratchPad.Model
{
    public class Product
    {
        public int ProductId { get; set; }
        public ProductType ProductType { get; set; }
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public int? RedressId { get; set; }
        public Redress? Redress { get; set; }

        [Required]
        [StringLength(50)]
        public string? Name { get; set; }

        [Required]
        public DateTime? StartDate { get; set; }

        [Range(3, 360)]
        public int? Duration { get; set; }

        [Column(TypeName = "decimal(4, 2)")]
        public decimal? Rate { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Value { get; set; }
    }
}