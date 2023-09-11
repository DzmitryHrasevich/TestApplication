using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using WebApp.Business.Profiles;
using WebApp.Business.Services;
using WebApp.Data;
using WebApp.Data.Entities;

namespace Tests.Services;

public class OrganisationServiceTests : BaseTests
{
    private readonly ApplicationDbContext _context;
    private readonly OrganisationService _service;

    public OrganisationServiceTests()
    {
        _context = GetInMemoryDbContext();

        var mapper = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<OrganisationProfile>();
        }).CreateMapper();

        _service = new OrganisationService(_context, mapper);
    }

    [Fact]
    public async Task GetOrganisations_ReturnsList_WhenDataExists()
    {
        // Arrange
        _context.Organisations.AddRange(
            new Organisation
            {
                OrganisationNumber = "001",
                OrganisationName = "Org1",
                Employees = new List<Employee>
                {
                    new Employee
                    {
                        OrganisationNumber = "001",
                        FirstName = "John",
                        LastName = "Doe"
                    },
                    new Employee
                    {
                        OrganisationNumber = "001",
                        FirstName = "Jane",
                        LastName = "Smith"
                    }
                }
            },
            new Organisation
            {
                OrganisationNumber = "002", 
                OrganisationName = "Org2",
                Employees = new List<Employee>
                {
                    new Employee
                    {
                        OrganisationNumber = "002",
                        FirstName = "Jackie",
                        LastName = "Chan"
                    }
                }
            }
        );
        await _context.SaveChangesAsync();

        // Act
        var result = await _service.GetOrganisations();

        // Assert
        result.Count.ShouldBe(2);
        result[0].OrganisationNumber.ShouldBe("001");
        result[0].EmployeesNumber.ShouldBe(2);
        result[1].OrganisationNumber.ShouldBe("002");
        result[1].EmployeesNumber.ShouldBe(1);

        // Cleanup
        await _context.Database.EnsureDeletedAsync();
    }
}