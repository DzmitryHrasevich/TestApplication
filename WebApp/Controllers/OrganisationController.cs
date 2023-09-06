using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Business.Models;
using WebApp.Data;

namespace WebApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrganisationController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    
    public OrganisationController(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<OrganisationDto>>> GetOrganisations([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        var organisations = await _context.Organisations
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        if (!organisations.Any())
        {
            return NotFound();
        }
        
        return Ok(_mapper.Map<List<OrganisationDto>>(organisations));
    }
}