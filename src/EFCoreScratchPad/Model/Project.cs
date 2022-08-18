using System.ComponentModel.DataAnnotations;

namespace EFCoreScratchPad.Model
{
    public class Project
    {
        public int ProjectId { get; set; }

        [Required]
        [StringLength(50)]
        public string? Name { get; set; }
    }
}
