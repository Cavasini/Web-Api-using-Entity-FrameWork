using System.ComponentModel.DataAnnotations;

namespace Look.Dtos
{
    public class CreateTaskDto
    {
        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(int.MaxValue)]
        public string Description { get; set; }

        [Required]
        public Guid ProjectId { get; set; }
    }
}
