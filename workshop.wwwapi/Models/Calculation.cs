namespace workshop.wwwapi.Models
{
    public class Calculation
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.UtcNow;
        public int A { get; set; }
        public int B { get; set; }
        public int Result { get; set; }

    }
}
