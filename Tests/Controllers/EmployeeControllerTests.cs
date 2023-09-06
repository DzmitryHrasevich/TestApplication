using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApp.Controllers;
using WebApp.Business.Models;
using WebApp.Data;
using Microsoft.EntityFrameworkCore;
using WebApp.Data.Entities;
using Xunit;

namespace Tests.Controllers;

public class EmployeeControllerTests
{
    private readonly EmployeeController _controller;
    private readonly Mock<ApplicationDbContext> _contextMock;
    private readonly Mock<IMapper> _mapperMock;

    public EmployeeControllerTests()
    {
        _contextMock = new Mock<ApplicationDbContext>();
        _mapperMock = new Mock<IMapper>();
        _controller = new EmployeeController(_contextMock.Object, _mapperMock.Object);
    }

    [Fact]
    public async Task GetEmployees_ReturnsOk_WhenDataExists()
    {
        // Arrange
        var employees = new List<Employee> 
        {
            new Employee 
            {
                OrganisationNumber = "123",
                FirstName = "John",
                LastName = "Doe",
                Organisation = new Organisation() // Mock the organisation
                {
                    OrganisationNumber = "123",
                    OrganisationName = "Test Org"
                }
            }
        };
        _contextMock.Setup(c => c.Employees).Returns(employees.AsQueryable().BuildMockDbSet().Object);

        var expectedDtoList = new List<EmployeeDto> 
        {
            new EmployeeDto
            {
                OrganisationNumber = "123",
                FirstName = "John",
                LastName = "Doe"
            }
        };
        _mapperMock.Setup(m => m.Map<List<EmployeeDto>>(It.IsAny<List<Employee>>())).Returns(expectedDtoList);

        // Act
        var result = await _controller.GetEmployees();

        // Assert
        Assert.IsType<OkObjectResult>(result.Result);
        var okResult = result.Result as OkObjectResult;
        var returnedEmployees = okResult.Value as List<EmployeeDto>;
        Assert.Equal(expectedDtoList.Count, returnedEmployees.Count);
    }

    [Fact]
    public async Task GetEmployees_ReturnsNotFound_WhenNoData()
    {
        // Arrange
        var employees = new List<Employee>();
        _contextMock.Setup(c => c.Employees).Returns(employees.AsQueryable().BuildMockDbSet().Object);

        // Act
        var result = await _controller.GetEmployees();

        // Assert
        Assert.IsType<NotFoundResult>(result.Result);
    }
}

// Extension method to mock DbSet from IQueryable
public static class IQueryableMockDbSetExtensions
{
    public static Mock<DbSet<T>> BuildMockDbSet<T>(this IQueryable<T> data) where T : class
    {
        var mockSet = new Mock<DbSet<T>>();
        mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(data.Provider);
        mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(data.Expression);
        mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
        return mockSet;
    }
}