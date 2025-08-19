using Microsoft.AspNetCore.Mvc;
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
        public static async Task<IResult> GetAll(IPersonRepository personRepository)
        {
            List<Object> response = new List<Object>();
            var results = await personRepository.GetAll();
            foreach (Person person in results)
            {
                List<Object> calculationDTO = new List<Object>();
                foreach(Calculation calculation in person.Calculations)
                {
                    calculationDTO.Add(new { Created=calculation.CreationDate, A=calculation.A, B=calculation.B, Result=calculation.Result });
                }
                response.Add(new { Name=person.Name, Calculations = calculationDTO });
            }
            return TypedResults.Ok(response);
        }
    }
}
