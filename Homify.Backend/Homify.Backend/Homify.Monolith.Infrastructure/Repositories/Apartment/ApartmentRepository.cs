using System.Xml.Schema;
using Homify.Monolith.Application.Dtos.User;
using Homify.Monolith.Domain.Models;
using Homify.Monolith.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Homify.Monolith.Infrastructure.Repositories.Apartment;

public interface IApartmentRepository
{
    Task<Domain.Models.Apartment> AddApartmentAsync(Domain.Models.Apartment apartment);
    IQueryable<Domain.Models.Apartment> GetAllApartments();
}

public class ApartmentRepository (HomifyDbContext context): IApartmentRepository
{
    public async Task<Domain.Models.Apartment> AddApartmentAsync(Domain.Models.Apartment apartment)
    {
        context.Apartments.Add(apartment);
        await context.SaveChangesAsync();
        
        return apartment;
    }

    public IQueryable<Domain.Models.Apartment> GetAllApartments()
    {
        return context.Apartments.AsNoTracking();
    }
}

