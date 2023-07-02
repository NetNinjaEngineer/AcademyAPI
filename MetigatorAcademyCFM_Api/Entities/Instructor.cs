namespace EF010.InitialMigration.Entities
{
    public class Instructor
    {
        public int Id { get; set; }
        public string? FName { get; set; }
        public string? LName { get; set; }

        public int? OfficeId { get; set; }
        public Office? Office { get; set; } // navigation property
        public ICollection<Section> Sections { get; set; } = new List<Section>();
    }
}