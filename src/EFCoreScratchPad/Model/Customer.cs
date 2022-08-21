using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFCoreScratchPad.Model
{
    public class Customer
    {
        public Customer()
        {
            Products = new List<Product>();
        }

        public int CustomerId { get; set; }
        public List<Product> Products { get; set; }

        [Required]
        [StringLength(150)]
        public string? Name { get; set; }
    }
}