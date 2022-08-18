using System.ComponentModel.DataAnnotations;

namespace EFCoreScratchPad.Model
{
    public class Customer
    {
        public Customer()
        {
            Product = new List<Product>();
        }

        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public List<Product> Product { get; set; }

        [Required]
        [StringLength(100)]
        public string? Name { get; set; }
    }
}