using workshop.calculator;
using workshop.wwwapi.DTOs;

namespace workshop.wwwapi.Endpoints
{
    public static class CalculationEndpoint
    {
        public static void ConfigureCalculationEndpoints(this WebApplication app)
        {
            var calculation = app.MapGroup("calculations");

            calculation.MapPost("/", Calculate);
        }

        public static async Task<IResult> Calculate(ICalculatorService service, CalculatePost model)
        {
            int result = service.Add(model.A, model.B);
            return TypedResults.Ok(new { CreationDate = DateTime.UtcNow, A=model.A, B = model.B, Result= result });
        }
    }
}
