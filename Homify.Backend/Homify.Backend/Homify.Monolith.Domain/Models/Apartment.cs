using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Homify.Monolith.Domain.Models;

public class Apartment
{
    [Key]
    public Guid ApartmentId { get; set; }
    
    [Range(1, int.MaxValue, ErrorMessage = "Apartment number must be positive.")]
    public int ApartmentNumber { get; set; }
    
    [Range(1, 30, ErrorMessage = "Apartment floor is out of range.")]
    public int ApartmentFloor { get; set; }
    
    [Range(1, 10000, ErrorMessage = "Apartment area must be positive.")]
    [Precision(10, 2)]
    public decimal ApartmentArea { get; set; }

    public Guid? UserId { get; set; }
    public User? User { get; set; }
}