using System.ComponentModel.DataAnnotations;

namespace Look.Dtos
{
    public class UpdateProjectDto
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }
    }
}
