using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static  class PersonEndpoints
    {
        public static void ConfigurePersonEndpoints(this WebApplication app)
        {
            var person = app.MapGroup("people");

            person.MapGet("/", GetAll);

        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAll(IRepository<Person> personRepository)
        {
            List<Object> response = new List<Object>();
            var results = await personRepository.GetWithIncludes(q =>
    q.Include(p => p.Calculations)
     .Include(p => p.PersonSubjects)
        .ThenInclude(ps => ps.Subject));
            foreach (Person person in results)
            {
                List<Object> calculationDTO = new List<Object>();
                List<string> subjectDTO = new List<string>();

                foreach(Calculation calculation in person.Calculations)
                {
                    calculationDTO.Add(new { Created=calculation.CreationDate, A=calculation.A, B=calculation.B, Result=calculation.Result });
                }
                foreach(PersonSubject s in person.PersonSubjects)
                {
                    subjectDTO.Add(s.Subject.Name);
                }
                response.Add(new { Name=person.Name, Calculations = calculationDTO, Subjects=subjectDTO });
            }
            return TypedResults.Ok(response);
        }
    }
}
