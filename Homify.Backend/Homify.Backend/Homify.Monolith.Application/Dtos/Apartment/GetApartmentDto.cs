namespace Homify.Monolith.Application.Dtos.Apartment;

public record GetApartmentDto
{
    public int ApartmentNumber { get; init; }
    public int ApartmentFloor { get; init; }
    public decimal ApartmentArea { get; init; }
    public string? UserFullName { get; init; }
}