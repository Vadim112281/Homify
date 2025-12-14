using AutoMapper;
using Homify.Monolith.Application.Dtos.Apartment;
using Homify.Monolith.Domain.Models;

namespace Homify.Monolith.Application.Profiles;

public class ApartmentProfile : Profile
{
    public ApartmentProfile()
    {
        CreateMap<ApartmentDto, Apartment>();
        CreateMap<Apartment, GetApartmentDto>()
            .ForMember(
                dest => dest.UserFullName,
                opt => opt.MapFrom(
                    x => x.User != null
                        ? $"{x.User.FirstName} {x.User.LastName}"
                        : null
                )
            );
    }
}