using WebApp.Data.Contracts;

namespace WebApp.Data.Repositories;

public class OrganisationRepository : IOrganisationRepository
{
    private readonly ApplicationDbContext _context;

    public OrganisationRepository(ApplicationDbContext context)
    {
        _context = context;
    }
}