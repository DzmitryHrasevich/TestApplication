using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using Shouldly;
using WebApp.Business.Models;
using WebApp.Business.Profiles;
using WebApp.Business.Services;
using WebApp.Data;
using WebApp.Data.Entities;

namespace Tests.Services;

public class EmployeeServiceTests : BaseTests
{
    private readonly ApplicationDbContext _context;
    private readonly EmployeeService _service;

    public EmployeeServiceTests()
    {
        _context = GetInMemoryDbContext();

        var mapper = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<EmployeeProfile>();
        }).CreateMapper();

        _service = new EmployeeService(_context, mapper);
    }

    [Fact]
    public async Task GetEmployees_ReturnsList_WhenDataExists()
    {
        // Arrange
        _context.Employees.AddRange(
            new Employee
            {
                OrganisationNumber = "001",
                FirstName = "John",
                LastName = "Doe",
                Organisation = new Organisation
                {
                    OrganisationNumber = "001",
                    OrganisationName = "Organisation 1"
                }
            },
            new Employee
            {
                OrganisationNumber = "002",
                FirstName = "Jane",
                LastName = "Smith",
                Organisation = new Organisation
                {
                    OrganisationNumber = "002",
                    OrganisationName = "Organisation 2"
                }
            }
        );
        await _context.SaveChangesAsync();

        // Act
        var result = await _service.GetEmployees();

        // Assert
        result.Count.ShouldBe(2);
        result[0].FirstName.ShouldBe("John");
        result[0].OrganisationName.ShouldBe("Organisation 1");
        result[1].FirstName.ShouldBe("Jane");
        result[1].OrganisationName.ShouldBe("Organisation 2");

        // Cleanup
        await _context.Database.EnsureDeletedAsync();
    }
}