using System.ComponentModel.DataAnnotations;

namespace Look.Dtos
{
    public class CreateTimeTracker
    {
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }


        [MaxLength(200)]
        public string TimeZoneId { get; set; }

        [Required]
        public Guid TaskId { get; set; }

        [Required]
        public Guid CollaboratorId { get; set; }
    }
}
