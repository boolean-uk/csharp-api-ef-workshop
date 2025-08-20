using FluentValidation;
using workshop.wwwapi.DTOs;

namespace workshop.wwwapi.Validators
{
    public class CalculatePostValidator : AbstractValidator<CalculatePost>
    {
        public CalculatePostValidator()
        {
            RuleFor(p => p.A).GreaterThan(0).WithMessage("A should be great than 0");
            RuleFor(p => p.B).GreaterThan(0).WithMessage("B should be great than 0");
            RuleFor(p => p.PersonId).GreaterThan(0).WithMessage("A valid PersonId should be provided");
            
        }
    }
}
