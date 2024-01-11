namespace Look.Dtos
{
    public class CreateTimeTrackerDto
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string TimeZoneId { get; set; }

        public Guid TaskId { get; set; }

        public Guid CollaboratorId { get; set; }
    }
}
