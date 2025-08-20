namespace workshop.wwwapi.Models
{
    public class PersonSubject
    {
        public int PersonId { get; set; }
        public Person Person { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.UtcNow;
    }
}
