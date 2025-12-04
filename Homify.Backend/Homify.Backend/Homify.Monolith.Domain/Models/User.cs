using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Homify.Monolith.Domain.Models;

public class User: IdentityUser<Guid>
{
    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; }
    
    [MaxLength(50)]
    public string MiddleName { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string LastName { get; set; }
    
    public List<Apartment>? Apartments { get; set; }
}