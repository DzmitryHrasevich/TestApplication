using WebApp.Business.Models;

namespace WebApp.Business.Contracts;

public interface IOrganisationService
{
    Task<IList<OrganisationDto>> GetOrganisations(int pageNumber = 1, int pageSize = 10);
}