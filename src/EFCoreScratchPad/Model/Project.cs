using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreScratchPad.Model
{
    public class Project
    {
        public int ProjectId { get; set; }
        public ProductType ProductType { get; set; }
        public List<Redress>? Redresses { get; set; }

        [Required]
        [StringLength(50)]
        public string? Name { get; set; }

        [Required]
        [StringLength(150)]
        public string? Description { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Compensation { get; set; }

        [Column(TypeName = "decimal(4, 2)")]
        public decimal? CompensatoryInterest { get; set; }
    }
}
