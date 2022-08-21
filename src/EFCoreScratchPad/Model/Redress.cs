using System.ComponentModel.DataAnnotations;

namespace EFCoreScratchPad.Model
{
    public class Redress
    {
        public int RedressId { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public int ProjectId { get; set; }
        public Project? Project { get; set; }
    }
}