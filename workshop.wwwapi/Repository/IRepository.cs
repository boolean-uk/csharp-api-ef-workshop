using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Calculation>> GetAll();
        Task<Calculation> Add(Calculation calculation);
    }
}
