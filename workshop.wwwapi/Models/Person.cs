namespace workshop.wwwapi.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Calculation> Calculations { get; set; } = new List<Calculation>();

    }
}
