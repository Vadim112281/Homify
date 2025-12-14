using AutoMapper;
using AutoMapper.QueryableExtensions;
using Homify.Monolith.Application.Common.Results;
using Homify.Monolith.Application.Dtos.Apartment;
using Homify.Monolith.Domain.Models;
using Homify.Monolith.Infrastructure.Repositories.Apartment;
using Microsoft.EntityFrameworkCore;

namespace Homify.Monolith.Application.Services.ApartmentService;

public interface IApartmentService
{
    Task<Result<Guid>> AddApartmentAsync(ApartmentDto apartmentDto);
    Task<Result<List<GetApartmentDto>>> GetAllApartmentsAsync();
}

public class ApartmentService (IApartmentRepository apartmentRepository, IMapper mapper): IApartmentService
{
    public async Task<Result<Guid>> AddApartmentAsync(ApartmentDto apartmentDto)
    {
        try
        {
            var apartment = mapper.Map<Apartment>(apartmentDto);
            await apartmentRepository.AddApartmentAsync(apartment);

            return Result<Guid>.Success(apartment.ApartmentId);
        }
        catch (Exception ex)
        {
            return Result<Guid>.Failure(new List<string> { ex.Message });
        }
    }

    public async Task<Result<List<GetApartmentDto>>> GetAllApartmentsAsync()
    {
        try
        {
            var list = await apartmentRepository.GetAllApartments()
                .ProjectTo<GetApartmentDto>(mapper.ConfigurationProvider)
                .ToListAsync();

            return Result<List<GetApartmentDto>>.Success(list);
        }
        catch (Exception ex)
        {
            return Result<List<GetApartmentDto>>.Failure(new List<string> { ex.Message });
        }
    }
}