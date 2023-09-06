using System.ComponentModel.DataAnnotations;

namespace WebApp.Data.Entities;

public sealed class Organisation
{
    [Key]
    public string OrganisationNumber { get; set; } = string.Empty;
    public string OrganisationName { get; set; } = string.Empty;
    public string AddressLine1 { get; set; } = string.Empty;
    public string? AddressLine2 { get; set; }
    public string? AddressLine3 { get; set; }
    public string? AddressLine4 { get; set; }
    public string Town { get; set; } = string.Empty;
    public string Postcode { get; set; } = string.Empty;
    
    public ICollection<Employee>? Employees { get; set; }
}