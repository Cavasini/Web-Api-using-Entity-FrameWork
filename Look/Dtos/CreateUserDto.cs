using System.ComponentModel.DataAnnotations;

namespace Look.Dtos
{
    public class CreateUserDto
    {
        [Required]
        [StringLength(255)]
        public string Username { get; set; }

        [Required]
        [StringLength(255)]
        public string Password { get; set; }
    }
}
