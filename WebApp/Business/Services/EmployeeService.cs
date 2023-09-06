using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApp.Business.Contracts;
using WebApp.Business.Models;
using WebApp.Data;

namespace WebApp.Business.Services;

public class EmployeeService : IEmployeeService
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public EmployeeService(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IList<EmployeeDto>> GetEmployees(int pageNumber = 1, int pageSize = 10)
    {
        var employees = await _context.Employees
            .Include(x => x.Organisation)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        
        return _mapper.Map<List<EmployeeDto>>(employees);
    }
}