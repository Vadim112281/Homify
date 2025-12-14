using FluentValidation;
using Homify.Monolith.Application.Dtos.Apartment;

namespace Homify.Monolith.Application.Validators.Apartment;

public class ApartmentDtoValidator: AbstractValidator<ApartmentDto>
{
    public ApartmentDtoValidator()
    {
        RuleFor(x => x.ApartmentNumber)
            .GreaterThan(0)
            .WithMessage("Apartment number must be positive.");
        
        RuleFor(x => x.ApartmentFloor)
            .InclusiveBetween(1, 30)
            .WithMessage("Apartment floor must be between 1 and 30.");

        RuleFor(x => x.ApartmentArea)
            .GreaterThan(0)
            .WithMessage("Apartment area must be positive.")
            .LessThanOrEqualTo(10000)
            .WithMessage("Apartment area is too large.");

        When(x => x.UserId.HasValue, () =>
        {
            RuleFor(x => x.UserId)
                .NotEqual(Guid.Empty)
                .WithMessage("UserId cannot be empty GUID.");
        });
    }
}