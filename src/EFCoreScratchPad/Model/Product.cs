using System.ComponentModel.DataAnnotations;

namespace EFCoreScratchPad.Model
{
    public class Product
    {
        public int ProductId { get; set; }
        public Redress? Redress { get; set; }

        [Required]
        [StringLength(50)]
        public string? Name { get; set; }
    }
}