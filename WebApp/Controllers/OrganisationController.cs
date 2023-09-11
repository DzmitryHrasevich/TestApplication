using Microsoft.AspNetCore.Mvc;
using WebApp.Business.Contracts;
using WebApp.Business.Models;

namespace WebApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrganisationController : ControllerBase
{
    private readonly IOrganisationService _service;

    public OrganisationController(IOrganisationService service)
    {
        _service = service;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<OrganisationDto>>> GetOrganisations([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        return Ok(await _service.GetOrganisations(pageNumber, pageSize));
    }
}