using System.ComponentModel.DataAnnotations;

namespace Look.Dtos
{
    public class CreateProjectDto
    {
        [Required]
        [StringLength(250)]
        public string Name { get; set; }
    }
}
