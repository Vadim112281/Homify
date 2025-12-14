namespace Homify.Monolith.Application.Dtos.Apartment;

public record ApartmentDto
{
    public int ApartmentNumber { get; init; }
    public int ApartmentFloor { get; init; }
    public decimal ApartmentArea { get; init; }
    public Guid? UserId { get; init; }
}