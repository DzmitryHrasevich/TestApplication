using WebApp.Business.Contracts;

namespace WebApp.Business.Models;

public class EmployeeDto : IDto
{
    public int? Id { get; set; }
    public string OrganisationNumber { get; set; } = string.Empty;
    public string OrganisationName { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
}