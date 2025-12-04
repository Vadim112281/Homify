using Homify.Monolith.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Homify.Monolith.Infrastructure.Data;

public class HomifyDbContext: IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
    public HomifyDbContext(DbContextOptions<HomifyDbContext> options) : base(options)
    {
    }
    
    public DbSet<Apartment> Apartments { get; set; }
}