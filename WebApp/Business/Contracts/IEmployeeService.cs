using WebApp.Business.Models;

namespace WebApp.Business.Contracts;

public interface IEmployeeService
{
    Task<IList<EmployeeDto>> GetEmployees(int pageNumber = 1, int pageSize = 10);
}