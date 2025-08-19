using Microsoft.AspNetCore.Mvc;
using workshop.calculator;
using workshop.wwwapi.DTOs;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class CalculationEndpoint
    {
        public static void ConfigureCalculationEndpoints(this WebApplication app)
        {
            var calculation = app.MapGroup("calculations");

            calculation.MapPost("/", Calculate);
            calculation.MapGet("/", GetAll);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> Calculate(ICalculatorService service, IRepository calcRepository,  CalculatePost model)
        {
            int result = service.Add(model.A, model.B);

            Calculation calc = new Calculation() { A = model.A, B = model.B, Result = result };
            
            await calcRepository.Add(calc);
            
            return TypedResults.Ok(new { CreationDate = DateTime.UtcNow, A=model.A, B = model.B, Result= result });
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAll(IRepository calcRepository)
        {
            List<Object> response = new List<Object>();
            var results = await calcRepository.GetAll();
            foreach(Calculation c in results)
            {
                response.Add(new { A=c.A, B=c.B, Created=c.CreationDate, Result=c.Result});
            }
            return TypedResults.Ok(response);
        }


    }
}
