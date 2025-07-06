using FavouritesFeature.Controllers;
using FavouritesFeature.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace FavouritesFeature.Test;

public class UserControllerTests
{
    [Fact]
    public void AddFavourite_ShouldReturnOk_WhenSuccessful()
    {
        var mockService = new Mock<IUserService>();
        mockService
            .Setup(s => s.AddFavourite(1, 2))
            .Returns(AddFavouriteResult.Success);

        var controller = new UserController(mockService.Object);
        var result = controller.AddFavourite(1, 2);

        Assert.IsType<OkResult>(result);
    }

    [Fact]
    public void AddFavourite_ShouldReturnNotFound_WhenUserIdNotFound()
    {
        var mockService = new Mock<IUserService>();
        mockService
            .Setup(s => s.AddFavourite(1, 2))
            .Returns(AddFavouriteResult.UserNotFound);

        var controller = new UserController(mockService.Object);
        var result = controller.AddFavourite(1, 2);
        Assert.IsType<NotFoundObjectResult>(result);
    }

    [Fact]
    public void RemoveFavourites_ShouldReturnOk_WhenSuccessful()
    {
        var mockService = new Mock<IUserService>();
        mockService
            .Setup(s => s.RemoveFavourite(1, 1))
            .Returns(RemoveFavouriteResponse.Success);
        var controller = new UserController(mockService.Object);
        var result = controller.RemoveFavourite(1, 1);
        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public void RemoveFavourite_ShouldReturnNotFound_WhenUserIdNotFound()
    {
        var mockService = new Mock<IUserService>();
        mockService
            .Setup(s => s.RemoveFavourite(1, 2))
            .Returns(RemoveFavouriteResponse.UserNotFound);

        var controller = new UserController(mockService.Object);
        var result = controller.RemoveFavourite(1, 2);
        var notFound = Assert.IsType<NotFoundObjectResult>(result);
        Assert.Equal("User not found", notFound.Value);
    }

    [Fact]
    public void GetFavourite_ShouldReturnOK_WhenSuccessful()
    {
        var mockService = new Mock<IUserService>();
        mockService
            .Setup(s => s.GetFavouritesIds(1))
            .Returns(new List<int> { 1, 2, 3 });
        
        var controller = new UserController(mockService.Object);
        var result = controller.GetFavourites(1);
        Assert.IsType<OkObjectResult>(result);
    }
}