using Microsoft.AspNetCore.Mvc;
using Moq;
using Shouldly;
using WebApp.Business.Contracts;
using WebApp.Business.Models;
using WebApp.Controllers;

namespace Tests.Controllers;

public class OrganisationControllerTests
{
    private readonly Mock<IOrganisationService> _mockService;
    private readonly OrganisationController _controller;

    public OrganisationControllerTests()
    {
        _mockService = new Mock<IOrganisationService>();
        _controller = new OrganisationController(_mockService.Object);
    }

    [Fact]
    public async Task GetOrganisations_ReturnsList_WhenDataExists()
    {
        // Arrange
        var organisationDtos = new List<OrganisationDto>
        {
            new OrganisationDto { OrganisationNumber = "001", OrganisationName = "Org1" },
            new OrganisationDto { OrganisationNumber = "002", OrganisationName = "Org2" }
        };

        _mockService.Setup(s => s.GetOrganisations(It.IsAny<int>(), It.IsAny<int>()))
            .ReturnsAsync(organisationDtos);

        // Act
        var result = await _controller.GetOrganisations();

        // Assert
        result.Result.ShouldBeOfType<OkObjectResult>();
        var returnedValue = ((OkObjectResult)result.Result).Value.ShouldBeAssignableTo<IEnumerable<OrganisationDto>>();
        returnedValue?.Count().ShouldBe(2);
    }
}