using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    public class Calculation
    {
        //[Key]
        public int Id { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.UtcNow;
        public int A { get; set; }
        public int B { get; set; }
        public int Result { get; set; }
        //[ForeignKey("Person")]
        public int PersonId { get; set; }
        public Person Person { get; set; }
        
    }
}
