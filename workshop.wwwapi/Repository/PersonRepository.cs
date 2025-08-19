using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private DataContext _db;
        public PersonRepository(DataContext db)
        {
            _db = db;
        }
        public Task<Person> Add(Person person)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Person>> GetAll()
        {
            return await _db.People.Include(p => p.Calculations).ToListAsync();
        }
    }
}
