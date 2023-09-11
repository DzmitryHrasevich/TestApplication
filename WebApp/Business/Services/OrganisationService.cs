using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApp.Business.Contracts;
using WebApp.Business.Models;
using WebApp.Data;

namespace WebApp.Business.Services;

public class OrganisationService : IOrganisationService
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public OrganisationService(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IList<OrganisationDto>> GetOrganisations(int pageNumber = 1, int pageSize = 10)
    {
        var organisations = await _context.Organisations
            .Include(x => x.Employees)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        
        return _mapper.Map<List<OrganisationDto>>(organisations);
    }
}