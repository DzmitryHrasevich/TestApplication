using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Business.Models;
using WebApp.Data;

namespace WebApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    
    public EmployeeController(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetEmployees([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        var employees = await _context.Employees
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        if (!employees.Any())
        {
            return NotFound();
        }
        
        return Ok(_mapper.Map<List<EmployeeDto>>(employees));
    }
}