using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetAll();
        Task<Person> Add(Person person);
    }
}
