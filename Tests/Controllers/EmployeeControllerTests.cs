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
using Shouldly;
using WebApp.Business.Contracts;
using WebApp.Data.Entities;
using Xunit;

namespace Tests.Controllers;

public class EmployeeControllerTests
{
    private readonly Mock<IEmployeeService> _mockService;
    private readonly EmployeeController _controller;

    public EmployeeControllerTests()
    {
        _mockService = new Mock<IEmployeeService>();
        _controller = new EmployeeController(_mockService.Object);
    }

    [Fact]
    public async Task GetEmployees_ReturnsList_WhenDataExists()
    {
        // Arrange
        var employeeDtos = new List<EmployeeDto>
        {
            new EmployeeDto { Id = 1, FirstName = "John", LastName = "Doe" },
            new EmployeeDto { Id = 2, FirstName = "Jane", LastName = "Smith" }
        };

        _mockService.Setup(s => s.GetEmployees(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(employeeDtos);

        // Act
        var result = await _controller.GetEmployees();

        // Assert
        result.Result.ShouldBeOfType<OkObjectResult>();
        var returnedValue = ((OkObjectResult)result.Result).Value.ShouldBeAssignableTo<IEnumerable<EmployeeDto>>();
        returnedValue?.Count().ShouldBe(2);
    }
}