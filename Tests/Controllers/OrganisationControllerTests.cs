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

public class OrganisationControllerTests
{
    private readonly OrganisationController _controller;
    private readonly Mock<ApplicationDbContext> _contextMock;
    private readonly Mock<IMapper> _mapperMock;

    public OrganisationControllerTests()
    {
        _contextMock = new Mock<ApplicationDbContext>();
        _mapperMock = new Mock<IMapper>();
        _controller = new OrganisationController(_contextMock.Object, _mapperMock.Object);
    }

    [Fact]
    public async Task GetOrganisations_ReturnsOk_WhenDataExists()
    {
        // Arrange
        var organisations = new List<Organisation> 
        {
            new Organisation 
            {
                OrganisationNumber = "123",
                OrganisationName = "Test Org",
                AddressLine1 = "Address 1",
                Town = "TestTown",
                Postcode = "12345"
            }
        };
        _contextMock.Setup(c => c.Organisations).Returns(organisations.AsQueryable().BuildMockDbSet().Object);

        var expectedDtoList = new List<OrganisationDto> 
        {
            new OrganisationDto
            {
                OrganisationNumber = "123",
                OrganisationName = "Test Org",
                AddressLine1 = "Address 1",
                Town = "TestTown",
                Postcode = "12345"
            }
        };
        _mapperMock.Setup(m => m.Map<List<OrganisationDto>>(It.IsAny<List<Organisation>>())).Returns(expectedDtoList);

        // Act
        var result = await _controller.GetOrganisations();

        // Assert
        Assert.IsType<OkObjectResult>(result.Result);
        var okResult = result.Result as OkObjectResult;
        var returnedOrganisations = okResult.Value as List<OrganisationDto>;
        Assert.Equal(expectedDtoList.Count, returnedOrganisations.Count);
    }

    [Fact]
    public async Task GetOrganisations_ReturnsNotFound_WhenNoData()
    {
        // Arrange
        var organisations = new List<Organisation>();
        _contextMock.Setup(c => c.Organisations).Returns(organisations.AsQueryable().BuildMockDbSet().Object);

        // Act
        var result = await _controller.GetOrganisations();

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